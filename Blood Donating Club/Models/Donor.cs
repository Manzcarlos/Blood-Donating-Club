using System;
using System.ComponentModel.DataAnnotations;

namespace Blood_Donating_Club.Models
{
    public class Donor
    {
        public int ID { get; set; }
        public string First_Name { get; set; }
        public string Last_Name { get; set; }
        public BloodType BloodType { get; set; }
        public DateTime DOB {  get; set; }
        public string Address { get; set; }
        public City City { get; set; }
        public string Identification_Number { get; set; }
        [EmailAddress]
        public string Email { get; set; }
        public DateTime LastDonation { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedOn { get; set;}
        public DateTime UpdatedAt { get; set; }
        public string UpdatedBy { get; set; }

    }
}
