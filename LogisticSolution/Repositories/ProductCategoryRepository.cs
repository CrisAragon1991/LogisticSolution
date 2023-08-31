using LogisticSolution.Data;
using LogisticSolution.Models;
using LogisticSolution.Repositories.BaseRepository;

namespace LogisticSolution.Repositories
{
    public class ProductCategoryRepository : BaseRepository<ProductCategory>
    {
        public ProductCategoryRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
