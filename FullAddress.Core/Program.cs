using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading;
using static FullAddress.Core.FullAddressBuilder;

namespace FullAddress.Core
{
    class Program
    {
        static void Main(string[] args)
        {
            var address = new Address()
            {
                AddressLine1 = "Address Line 1",
                AddressLine2 = "Address Line 2",
                AddressLine3 = "Address Line 3",
                AddressLine4 = "POST CODE",
                AddressLine9 = "Address Line 7",
                AddressLine7 = "E1R C0D3",
                Town = "Town",
                County = "Co. County",
                Country = "Ireland",
                Eircode = "E1R C0D3",
                Postcode = "POST CODE"
            };

            Console.WriteLine(FullAddressBuilder.ToFullAddressString(address));

            Console.Read();
        }

    }
}
