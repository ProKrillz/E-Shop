using KrillzCardz.Services.DTO;

namespace KrillzCardz.Services
{
    public class RepositoryOrdre : IOrdre
    {
        private readonly HttpClient _HttpClient;
        public RepositoryOrdre(HttpClient httpClient)
        {
            _HttpClient = httpClient;
        }
        public async Task CreateOrdre()
        {

        }
        public async Task<List<OrdreModel>> GetOrdreByUserId(Guid id)
        {
            return new List<OrdreModel>();
        }
    }
}
