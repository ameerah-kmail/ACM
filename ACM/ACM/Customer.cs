﻿namespace ACM 
{
    public class Customer
    {
        public List<Address> AddressList { get; set; }
        public Address WorkAddress { get; set; }
        public int CustomerId { get; private set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        private string _lastName;
        public int CustomerType { get; set; }
        internal string LastName
        { 
            get { return _lastName; }   
            set { _lastName = value; }
        }
        public string FullNmae {
            get
            {
                if(string.IsNullOrWhiteSpace(LastName) )
                    return FirstName;
                else if (string.IsNullOrWhiteSpace(FirstName))
                    return LastName;
                return LastName+"  "+FirstName;
            }
        }

        public static int InstanceCount { get; set; }
        public Customer() :this(0)
        {
            
        }
        public Customer(int customerId)//ctor
        {
            AddressList =new List<Address>();
            CustomerId = customerId;
        }

        public bool Validate()
        {
            var isValid = true;
            if(string.IsNullOrWhiteSpace(LastName)) 
                isValid = false;
            if (string.IsNullOrWhiteSpace(FirstName))
                isValid = false;
            return isValid;

        }

    }
}  