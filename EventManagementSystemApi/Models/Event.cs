namespace EventManagementSystemApi.Models
{
    public class Event
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public string Location { get; set; }
        public int? Capacity { get; set; }
        public bool Visibility { get; set; }
        public int CreatedByUserId { get; set; }
        
        public ICollection<Participant> Participants { get; set; }


    }
}
