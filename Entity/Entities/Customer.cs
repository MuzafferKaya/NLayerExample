﻿namespace EntityLayer.Entities
{
    public class Customer
    {
        public int Id { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public char Gender { get; set; }
        public int YearOfBirth { get; set; }
        public string StreetAddress { get; set; } = string.Empty;
        public string PostalCode { get; set; } = string.Empty;
        public string City { get; set; } = string.Empty;
    }
}
