using Newtonsoft.Json;
using SrPago.CocktailFinder.Domain.Interfaces;
using SrPago.CocktailFinder.Domain.Models.Request;
using SrPago.CocktailFinder.Domain.Models.Response;
using SrPago.Infrastructure.Data.Response;
using System.Net.Http;
using System.Threading.Tasks;

namespace SrPago.Infrastructure.Data.Repository
{
    public class ElementDetailtRepository : BaseRepository, IElementDetailRepository
    {
        public ElementDetailtRepository(IHttpClientFactory clientFactory) : base(clientFactory)
        {
        }

        /// <summary>
        /// Obtiene los detalles de la receta
        /// </summary>
        /// <param name="request">Contiene el ID de la receta a buscar</param>
        /// <returns></returns>
        public async Task<ElementDetailResponse> GetElementDetailAsync(ElementDetailRequest request)
        {
            var client = ClientFactory.CreateClient();
            var response = await client.GetAsync($"http://thecocktaildb.com/api/json/v1/1/lookup.php?i={request.Id}");
            var result = await response.Content.ReadAsStringAsync();
            var recipeResponse = JsonConvert.DeserializeObject<DetailResponse>(result);

            return recipeResponse.GetRecipe();
        }


    }
}
