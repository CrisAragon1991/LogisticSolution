namespace LogisticSolution.Models
{
    public enum LocationType {
        Store = 1,
        Harbor = 2
    }
    public class Location
    {
        public int LocationId { get; set; }
        public string? Name { get; set; }
        public LocationType LocationType { get; set; }

        public virtual ICollection<DeliverySchedule>? DeliverySchedules { get; set; }
    }
}
