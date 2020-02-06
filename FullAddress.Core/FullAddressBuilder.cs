using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;

namespace FullAddress.Core
{
    public static class FullAddressBuilder
    {
        public static string ToFullAddressString(this Address address)
        {
            // Order to place address details in the full string
            List<string> addressDetailOrder = new List<string>() {
                nameof(Address.AddressLine1),
                nameof(Address.AddressLine2),
                nameof(Address.AddressLine3),
                nameof(Address.AddressLine4),
                nameof(Address.AddressLine5),
                nameof(Address.AddressLine6),
                nameof(Address.AddressLine7),
                nameof(Address.AddressLine8),
                nameof(Address.AddressLine9),
                nameof(Address.AddressLine10),
                nameof(Address.Town),
                nameof(Address.County),
                nameof(Address.Country),
                nameof(Address.Eircode),
                nameof(Address.Postcode),
            };

            string fullAddress = string.Empty;

            foreach (var addressDetailName in addressDetailOrder)
            {
                string addressDetailValue = typeof(Address).GetProperty(addressDetailName).GetValue(address) as string;

                if (!string.IsNullOrWhiteSpace(addressDetailValue))
                {
                    string addressDetailValueTitleCased = addressDetailValue.ToTitleCase();

                    // If the address detail is Town, County, Country, Eircode, or Postcode - prevent duplicate detail in full address
                    if ((addressDetailName == nameof(address.Town)
                        || addressDetailName == nameof(address.County)
                        || addressDetailName == nameof(address.Country)
                        || addressDetailName == nameof(address.Eircode))
                        || addressDetailName == nameof(address.Postcode)
                        && fullAddress.Contains($"{addressDetailValueTitleCased}, "))
                    {
                        // Remove the duplicate address detail from the full address string
                        fullAddress = fullAddress.Replace($"{addressDetailValueTitleCased}, ", "");

                        // If the address detail is Eircode or Postcode - capitalise the detail
                        if (addressDetailName == nameof(address.Eircode) || addressDetailName == nameof(address.Postcode))
                            fullAddress += $"{addressDetailValueTitleCased.ToUpper()}, ";
                        // Else - append it to the full address string
                        else
                            fullAddress += $"{addressDetailValueTitleCased}, ";
                    }
                    else
                        fullAddress += $"{addressDetailValueTitleCased}, ";
                }
            }

            return (!string.IsNullOrWhiteSpace(fullAddress) ? fullAddress.Substring(0, fullAddress.Length - 2) : string.Empty);
        }

        public static string ToTitleCase(this string input)
        {
            // Split the address line into sections to title case individually
            string[] inputSections = input.Split(Convert.ToChar(" "));

            for (int i = 0; i < inputSections.Length; i++)
            {
                // If the section begins with a number, do not format. i.e. '1st' street
                if (Regex.IsMatch(inputSections[i], @"^\d"))
                    continue;
                // Title case other sections
                else
                    inputSections[i] = Thread.CurrentThread.CurrentCulture.TextInfo.ToTitleCase(inputSections[i]);
            }

            // Return the formatted address line
            return string.Join(" ", inputSections);
        }

        public class Address
        {
            public string AddressLine1 { get; set; }
            public string AddressLine2 { get; set; }
            public string AddressLine3 { get; set; }
            public string AddressLine4 { get; set; }
            public string AddressLine5 { get; set; }
            public string AddressLine6 { get; set; }
            public string AddressLine7 { get; set; }
            public string AddressLine8 { get; set; }
            public string AddressLine9 { get; set; }
            public string AddressLine10 { get; set; }

            public string Town { get; set; }
            public string County { get; set; }
            public string Country { get; set; }
            public string Eircode { get; set; }
            public string Postcode { get; set; }
        }
    }
}
