using FullAddress.Core;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using static FullAddress.Core.FullAddressBuilder;

namespace FullAddress.Tests
{
    [TestClass]
    public class FullAddressTests
    {
        [TestMethod]
        public void Build_Full_Address_String()
        {
            var address = new Address()
            {
                AddressLine1 = "Address Line 1",
                AddressLine2 = "Address Line 2",
                AddressLine3 = "Address Line 3",
                AddressLine4 = "Address Line 4",
                AddressLine5 = "Address Line 5",
                Eircode = "E1R C0D3"
            };
            
            string fullAddress = FullAddressBuilder.ToFullAddressString(address);

            Assert.AreEqual("Address Line 1, Address Line 2, Address Line 3, Address Line 4, Address Line 5, E1R C0D3", fullAddress);
        }

        [TestMethod]
        public void Build_Full_Address_String_Whitespace()
        {
            var address = new Address()
            {
                AddressLine1 = "Address Line 1",
                AddressLine2 = "Address Line 2",
                AddressLine3 = "Address Line 3",
                AddressLine4 = "Address Line 4",
                AddressLine8 = " ",
                Eircode = "E1R C0D3"
            };

            string fullAddress = FullAddressBuilder.ToFullAddressString(address);

            Assert.AreEqual("Address Line 1, Address Line 2, Address Line 3, Address Line 4, E1R C0D3", fullAddress);
        }

        [TestMethod]
        public void Build_Full_Address_String_Empty()
        {
            var address = new Address()
            {
                AddressLine1 = "Address Line 1",
                AddressLine2 = "Address Line 2",
                AddressLine3 = "Address Line 3",
                AddressLine4 = "Address Line 4",
                AddressLine7 = string.Empty,
                Eircode = "E1R C0D3"
            };
            
            string fullAddress = FullAddressBuilder.ToFullAddressString(address);

            Assert.AreEqual("Address Line 1, Address Line 2, Address Line 3, Address Line 4, E1R C0D3", fullAddress);
        }

        [TestMethod]
        public void Build_Full_Address_String_Null()
        {
            var address = new Address()
            {
                AddressLine1 = "Address Line 1",
                AddressLine2 = "Address Line 2",
                AddressLine3 = "Address Line 3",
                AddressLine4 = "Address Line 4",
                AddressLine6 = null,
                Eircode = "E1R C0D3"
            };

            string fullAddress = FullAddressBuilder.ToFullAddressString(address);

            Assert.AreEqual("Address Line 1, Address Line 2, Address Line 3, Address Line 4, E1R C0D3", fullAddress);
        }

        [TestMethod]
        public void Build_Full_Address_String_Town_County_Eircode()
        {
            var address = new Address()
            {
                AddressLine1 = "Address Line 1",
                AddressLine2 = "Address Line 2",
                AddressLine3 = "Address Line 3",
                AddressLine4 = "Address Line 4",
                Town = "Town",
                County = "Co. County",
                Eircode = "E1R C0D3"
            };

            string fullAddress = FullAddressBuilder.ToFullAddressString(address);

            Assert.AreEqual("Address Line 1, Address Line 2, Address Line 3, Address Line 4, Town, Co. County, E1R C0D3", fullAddress);
        }

        [TestMethod]
        public void Build_Full_Address_String_Country_Postcode()
        {
            var address = new Address()
            {
                AddressLine1 = "Address Line 1",
                AddressLine2 = "Address Line 2",
                AddressLine3 = "Address Line 3",
                AddressLine4 = "Address Line 4",
                Country = "Country",
                Postcode = "P05TC0D3",
            };

            string fullAddress = FullAddressBuilder.ToFullAddressString(address);

            Assert.AreEqual("Address Line 1, Address Line 2, Address Line 3, Address Line 4, Country, P05TC0D3", fullAddress);
        }

        [TestMethod]
        public void Build_Full_Address_String_Town_County_Country_Eircode()
        {
            var address = new Address()
            {
                AddressLine1 = "Address Line 1",
                AddressLine2 = "Address Line 2",
                Town = "Town",
                County = "Co. County",
                Country = "Country",
                Eircode = "E1R C0D3"
            };

            string fullAddress = FullAddressBuilder.ToFullAddressString(address);

            Assert.AreEqual("Address Line 1, Address Line 2, Town, Co. County, Country, E1R C0D3", fullAddress);
        }

        [TestMethod]
        public void Build_Full_Address_Eircode_Duplicate()
        {
            var address = new Address()
            {
                AddressLine1 = "Address Line 1",
                AddressLine2 = "Address Line 2",
                AddressLine3 = "E1R C0D3",
                Eircode = "E1R C0D3"
            };

            string fullAddress = FullAddressBuilder.ToFullAddressString(address);

            Assert.AreEqual("Address Line 1, Address Line 2, E1R C0D3", fullAddress);
        }

        [TestMethod]
        public void Build_Full_Address_Eircode_Duplicate_With_Town()
        {
            var address = new Address()
            {
                AddressLine1 = "Address Line 1",
                AddressLine2 = "Address Line 2",
                AddressLine3 = "E1R C0D3",
                Town = "Town",
                Eircode = "E1R C0D3"
            };

            string fullAddress = FullAddressBuilder.ToFullAddressString(address);

            Assert.AreEqual("Address Line 1, Address Line 2, Town, E1R C0D3", fullAddress);
        }

        [TestMethod]
        public void Build_Full_Address_Address_Lines_Title_Casing()
        {
            var address = new Address()
            {
                AddressLine1 = "aDDress line 1",
                AddressLine2 = "address lIne 2",
                AddressLine3 = "E1R C0D3",
                Town = "town",
                Eircode = "E1R C0D3"
            };

            string fullAddress = FullAddressBuilder.ToFullAddressString(address);

            Assert.AreEqual("Address Line 1, Address Line 2, Town, E1R C0D3", fullAddress);
        }

        [TestMethod]
        public void Build_Full_Address_Eircode_Capitalization()
        {
            var address = new Address()
            {
                AddressLine1 = "Address Line 1",
                AddressLine2 = "Address Line 2",
                AddressLine3 = "e1r c0d3",
                Town = "Town",
                Eircode = "e1r c0d3"
            };

            string fullAddress = FullAddressBuilder.ToFullAddressString(address);

            Assert.AreEqual("Address Line 1, Address Line 2, Town, E1R C0D3", fullAddress);
        }

        [TestMethod]
        public void Build_Full_Address_1st_2nd_3rd_Capitalization()
        {
            var address = new Address()
            {
                AddressLine1 = "1st house",
                AddressLine2 = "address line 2",
                AddressLine3 = "e1r c0d3",
                Town = "Town",
                Eircode = "e1r c0d3"
            };

            string fullAddress = FullAddressBuilder.ToFullAddressString(address);

            System.Console.WriteLine(fullAddress);

            Assert.AreEqual("1st House, Address Line 2, Town, E1R C0D3", fullAddress);
        }

        [TestMethod]
        public void Build_Full_Address_No_Address_Lines()
        {
            string fullAddress = FullAddressBuilder.ToFullAddressString(new Address());

            System.Console.WriteLine(fullAddress);

            Assert.AreEqual("", fullAddress);
        }
    }
}
