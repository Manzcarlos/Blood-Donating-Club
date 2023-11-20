namespace Blood_Donating_Club.Models
{
    public class Donation
    {
        public int ID { get; set; }
        public Donor Donor { get; set; }
        public Campaign Campaign { get; set; }
        public DateTime date { get; set; }
    }
}
