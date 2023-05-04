using KrillzCardz.Services.DTO;

namespace KrillzCardz.Services
{
    public interface IOrdre
    {
        Task CreateOrdre();
        Task<List<OrdreModel>> GetOrdreByUserId(Guid id);
    }
}
