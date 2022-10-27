using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACM
{
    public class CustomerRepsitory
    {
        public CustomerRepsitory()
        {
            _addressRepository=new AddressRepository();

        }
        private AddressRepository _addressRepository { get; set; }
        public Customer Retrieve(int customerId)
        {
            Customer customer = new Customer(customerId);
            if (customerId == 1)
            {
                customer.Email = "aa@gmail.com";
                customer.FirstName = "ameerah";
                customer.LastName = "kmail";
                customer.AddressList = _addressRepository.RetrieveByCustomerId(customerId).ToList();
            }
            return customer;
        }
        public bool save(Customer customer)
        {
            var success = true;
            if (customer.IsValid)
            {
                if (customer.IsNew)
                {
                    //////////////////
                }
                else
                {
                    /////////////////////////
                }
            }
            else
            {
                success = false;
            }
            return success;
        }

    }
}
