using LogisticSolution.Controllers;
using LogisticSolution.Data;
using LogisticSolution.Models;
using LogisticSolution.Repositories;
using Microsoft.EntityFrameworkCore;
using Moq;

namespace LogisticSolution.Test
{
    public class DeliveryScheduleTest
    {
        private readonly ApplicationDbContext dbContext;
        public DeliveryScheduleTest()
        {
            var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();
            dbContext = new ApplicationDbContext(optionsBuilder.Options);
        }

        [Fact]
        public async void GetDeliveryScheeduleById()
        {
            
        }

        private IEnumerable<DeliverySchedule> ListDelivery()
        {
            List<DeliverySchedule> deliveryData = new List<DeliverySchedule>()
            {
                new DeliverySchedule()
                {
                    DeliveryScheduleId = 1,
                    ProductCategoryId = 1,
                    ProductQuantity = 20,
                    Discount = 50,
                    RecordDate = DateTime.Now,
                    DeliveryDate = DateTime.Now,
                    LocationId = 1,
                    Price = 5000,
                    TransportId = "123456",
                    GuideNumber = "1234567891"
                },
                new DeliverySchedule()
                {
                    DeliveryScheduleId = 2,
                    ProductCategoryId = 2,
                    ProductQuantity = 30,
                    Discount = 500,
                    RecordDate = DateTime.Now,
                    DeliveryDate = DateTime.Now,
                    LocationId = 1,
                    Price = 50000,
                    TransportId = "123457",
                    GuideNumber = "1234567892"
                }
            };
            return deliveryData;
        }
    }
}