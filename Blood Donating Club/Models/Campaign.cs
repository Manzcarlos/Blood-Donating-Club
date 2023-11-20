namespace Blood_Donating_Club.Models
{
    public class Campaign
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DonatingCenter DonatingCenter { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        public CampaignStatus Status { get; set; }
    }
}
