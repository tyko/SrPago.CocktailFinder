using System.Net.Http;

namespace SrPago.Infrastructure.Data.Repository
{
    public abstract class BaseRepository
    {
        protected readonly IHttpClientFactory ClientFactory;

        protected BaseRepository(IHttpClientFactory clientFactory)
        {
            ClientFactory = clientFactory;
        }
    }
}
