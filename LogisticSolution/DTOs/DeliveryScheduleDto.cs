using LogisticSolution.Models;

namespace LogisticSolution.DTOs
{
    public class DeliveryScheduleDto
    {
        public int DeliveryScheduleId { get; set; }
        public int ProductCategoryId { get; set; }
        public int ProductQuantity { get; set; }
        public DateTime RecordDate { get; set; }
        public DateTime DeliveryDate { get; set; }
        public int LocationId { get; set; }
        public decimal Price { get; set; }
        public string? TransportId { get; set; }
        public string? GuideNumber { get; set; }
        public int UserId { get; set; }
    }
}
