using NZWalks2.API.Models.Domain;

namespace NZWalks2.API.Repositories
{
    public interface IRegionRepository
    {
    
        Task<List<Region>> GetAllAsync();


        Task<Region?> GetById(Guid id);

    
    
    }

}
