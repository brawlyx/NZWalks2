using NZWalks2.API.Models.Domain;

namespace NZWalks2.API.Repositories
{
    public class InMemoryRegionRepository : IRegionRepository
    {
        public async Task<List<Region>> GetAllAsync()
        {
            return new List<Region>()
                {
                new Region()
                {
                    Id = Guid.NewGuid(),
                    Code = "Test",
                    Name = "Test",

                }
            };
        }
    }
}
