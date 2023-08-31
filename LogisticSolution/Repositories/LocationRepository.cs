using LogisticSolution.Data;
using LogisticSolution.Models;
using LogisticSolution.Repositories.BaseRepository;

namespace LogisticSolution.Repositories
{
    public class LocationRepository : BaseRepository<Location>
    {
        public LocationRepository(ApplicationDbContext context) : base(context)
        {         
        }
    }
}
