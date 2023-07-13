using Infrastructure.Entities;
using System;
using System.Collections.Generic;

namespace API.Response
{
    public class CustomerResponse
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public IEnumerable<CustomerPhoneResponse> PhoneNumbers { get; set; } = Array.Empty<CustomerPhoneResponse>();
        public AccountManagerResponse AccountManager { get; set; }
    }

    public class CustomerPhoneResponse
    {
        public int Id { get; set; }
        public string PhoneNumber { get; set; }
    }

    public class AccountManagerResponse
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
    }
}
