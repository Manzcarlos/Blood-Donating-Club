namespace Blood_Donating_Club.Models
{
    public class DonatingCenter
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public City City { get; set; }
        public string BusinessHours { get; set; }
        public string PhoneNumber { get; set; }
        public string ManagerName { get; set; }

    }
}
