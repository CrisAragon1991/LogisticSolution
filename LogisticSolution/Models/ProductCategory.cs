namespace LogisticSolution.Models
{
    public class ProductCategory
    {
        public int ProductCategoryId { get; set; }
        public string? Name { get; set; }
        public virtual ICollection<DeliverySchedule>? DeliverySchedules { get; set; }
    }
}
