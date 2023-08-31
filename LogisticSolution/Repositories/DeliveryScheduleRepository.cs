using LogisticSolution.Data;
using LogisticSolution.DTOs;
using LogisticSolution.Models;
using LogisticSolution.Repositories.BaseRepository;
using Microsoft.EntityFrameworkCore.Infrastructure.Internal;

namespace LogisticSolution.Repositories
{
    public class DeliveryScheduleRepository : BaseRepository<DeliverySchedule>
    {
        public DeliveryScheduleRepository(ApplicationDbContext context) : base(context)
        {
        }

        internal async Task<DeliverySchedule> CreateNewDeliverySchedule(DeliveryScheduleDto deliverySchedule)
        {
            var location = await dbContext.FindAsync<Location>(new object[] {deliverySchedule.LocationId});
            if (location == null)
            {
                throw new Exception("Resource Not found");
            }
            var newSchedule = new DeliverySchedule()
            {
                ProductQuantity = deliverySchedule.ProductQuantity,
                Price = deliverySchedule.Price,
                Discount = deliverySchedule.ProductQuantity > 10 ? location.LocationType == LocationType.Store ? (deliverySchedule.Price / 100) * 5 : (deliverySchedule.Price / 100) * 3 : 0,
                ProductCategoryId = deliverySchedule.ProductCategoryId,
                RecordDate = DateTime.Now,
                DeliveryDate = deliverySchedule.DeliveryDate,
                LocationId = location.LocationId,
                TransportId = deliverySchedule.TransportId,
                GuideNumber = deliverySchedule.GuideNumber,
                UserId = deliverySchedule.UserId
            };
            return await this.CreateEntity(newSchedule);
        }

        internal async Task<DeliverySchedule> UpdateDeliverySchedule(int id, DeliveryScheduleDto deliverySchedule)
        {
            var location = await dbContext.FindAsync<Location>(new object[] { deliverySchedule.LocationId });
            if (location == null)
            {
                throw new Exception("Resource Not found");
            }
            var oldSchedule = await dbContext.FindAsync<DeliverySchedule>(new object[] { id });
            if (oldSchedule == null)
            {
                throw new Exception("Resource Not found");
            }
            var newSchedule = new DeliverySchedule()
            {
                DeliveryScheduleId = id,
                ProductQuantity = deliverySchedule.ProductQuantity,
                Price = deliverySchedule.Price,
                Discount = deliverySchedule.ProductQuantity > 10 ? location.LocationType == LocationType.Store ? (deliverySchedule.Price / 100) * 5 : (deliverySchedule.Price / 100) * 3 : 0,
                ProductCategoryId = deliverySchedule.ProductCategoryId,
                RecordDate = oldSchedule.RecordDate,
                DeliveryDate = deliverySchedule.DeliveryDate,
                LocationId = location.LocationId,
                TransportId = deliverySchedule.TransportId,
                GuideNumber = deliverySchedule.GuideNumber,
                UserId = deliverySchedule.UserId
            };
            return await this.UpdateEntity(id, newSchedule);
        }
    }
}
