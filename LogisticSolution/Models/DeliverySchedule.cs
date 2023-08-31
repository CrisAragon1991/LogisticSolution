namespace LogisticSolution.Models
{
    public class DeliverySchedule
    {
        public int DeliveryScheduleId { get; set; }
        public int ProductCategoryId { get; set; }
        public int ProductQuantity { get; set; }
        public decimal Discount { get; set; }
        public DateTime RecordDate { get; set; }
        public DateTime DeliveryDate { get; set; }
        public int LocationId { get; set; }
        public decimal Price { get; set; }
        public string? TransportId { get; set; }
        public string?  GuideNumber { get; set; }
        public int UserId { get; set; }
        public virtual User? User { get; set; }
        public virtual ProductCategory? ProductCategory { get; set; }
        public virtual Location? Location { get; set; }

    }
}
