using Newtonsoft.Json;
using SrPago.CocktailFinder.Domain.Enumerables;
using SrPago.CocktailFinder.Domain.Interfaces;
using SrPago.CocktailFinder.Domain.Models.Request;
using SrPago.CocktailFinder.Domain.Models.Response;
using SrPago.Infrastructure.Data.Interfaces;
using SrPago.Infrastructure.Data.Response;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace SrPago.Infrastructure.Data.Repository
{
    public class ElementRepository : BaseRepository, IElementRepository
    {
        public ElementRepository(IHttpClientFactory clientFactory) : base(clientFactory)
        {
        }

        /// <summary>
        /// Obtiene los resultados de la API cuando se busca por tipo de vaso, categoria o ingrediente
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<IEnumerable<ElementResponse>> GetResultAsync(SearchRequest request)
        {
            return await GetCategoryListAsync(request); ;
        }

        private async Task<IEnumerable<ElementResponse>> GetCategoryListAsync(SearchRequest request)
        {
            IEnumerable<string> categoryList;
            IEnumerable<ElementResponse> drinkList = new List<ElementResponse>();
            switch (request.SearchType)
            {
                case (int)EnumCategoryOption.Category:
                    categoryList = await GetCategories<CategoryResponse>(request, "http://thecocktaildb.com/api/json/v1/1/list.php?c=list");
                    drinkList = await GetDrinksAsync(categoryList, "http://thecocktaildb.com/api/json/v1/1/filter.php?c=");
                    break;
                case (int)EnumCategoryOption.Glass:
                    categoryList = await GetCategories<GlassResponse>(request, "http://thecocktaildb.com/api/json/v1/1/list.php?g=list");
                    drinkList = await GetDrinksAsync(categoryList, "http://thecocktaildb.com/api/json/v1/1/filter.php?g=");
                    break;
                case (int)EnumCategoryOption.Ingredient:
                    categoryList = await GetCategories<IngredientResponse>(request, "http://thecocktaildb.com/api/json/v1/1/list.php?i=list");
                    drinkList = await GetDrinksAsync(categoryList, "http://thecocktaildb.com/api/json/v1/1/filter.php?i=");
                    break;
                case (int)EnumCategoryOption.Name:
                    categoryList = new List<string> { request.NameToSearch };
                    drinkList = await GetDrinksAsync(categoryList, "http://thecocktaildb.com/api/json/v1/1/search.php?s=");
                    break;
            }

            return drinkList;

        }

        /// <summary>
        /// Obtiene todas las categosrias dependiendo del tipo de busqueda
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="request"></param>
        /// <param name="url"></param>
        /// <returns></returns>
        private async Task<IEnumerable<string>> GetCategories<T>(SearchRequest request, string url) where T : IResponse
        {
            var client = ClientFactory.CreateClient();
            var response = await client.GetAsync(url);
            if (response.IsSuccessStatusCode)
            {
                var result = await response.Content.ReadAsStringAsync();
                var objCategories = JsonConvert.DeserializeObject<T>(result);

                return objCategories.GetCategories();
            }

            return new List<string>();
        }

        /// <summary>
        /// Obtiene todas las bebidas de cada una de las categorias
        /// </summary>
        /// <param name="categories"></param>
        /// <param name="url"></param>
        /// <returns></returns>
        private async Task<IEnumerable<ElementResponse>> GetDrinksAsync(IEnumerable<string> categories, string url)
        {
            var client = ClientFactory.CreateClient();
            var drinkList = new List<ElementResponse>();
            foreach (var category in categories)
            {
                var response = await client.GetAsync($"{url}{category}");
                var result = await response.Content.ReadAsStringAsync();
                var dto = JsonConvert.DeserializeObject<ElementApiResponse>(result);
                drinkList.AddRange(dto.drinks);
            }

            return drinkList;
        }
    }
}
