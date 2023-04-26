using Microsoft.EntityFrameworkCore;
using NZWalks2.API.Data;
using NZWalks2.API.Models.Domain;

namespace NZWalks2.API.Repositories
{
    public class SQLRegionRepository : IRegionRepository
    {
        private readonly NZWalks2DbContext dbContext;
        public SQLRegionRepository(NZWalks2DbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public async Task<List<Region>> GetAllAsync()
        {
            return await dbContext.Regions.ToListAsync();
        }

        public async Task<Region?> GetById(Guid id)
        {
            dbContexxt
        }
    }
}
