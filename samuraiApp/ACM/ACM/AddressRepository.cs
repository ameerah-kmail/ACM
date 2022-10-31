using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACM
{
    public class AddressRepository
    {
      
        public Address Retrieve(int addressId)
        {
            Address address = new Address();
            if (addressId == 1)
            {
                address.AddressType = 1;
                address.StreetLine1 = "end";
                address.StreetLine2 = "row";
                address.city = "hobbiton";
                address.State = "shire";
                address.Country = "middle earth";
                address.PostalCode = "144";
            }
            return address;
        }

        public IEnumerable<Address> RetrieveByCustomerId( int customerId)
        {
            var addresslist=new List<Address>();
            Address address = new Address(1)
            {
                AddressType = 1,
                StreetLine1 = "end",
                StreetLine2 = "row",
                city = "hobbiton",
                State = "shire",
                Country = "middle earth",
                PostalCode = "144"

            };
            addresslist.Add(address);
             address = new Address(2)
            {
                AddressType = 1,
                StreetLine1 = "end",
                StreetLine2 = "row",
                city = "hobbiton",
                State = "shire",
                Country = "middle earth",
                PostalCode = "144"

            };
            addresslist.Add(address);
            return addresslist;

        }
        public bool save(Address address)
        {
            return true;
        }
    }
}
