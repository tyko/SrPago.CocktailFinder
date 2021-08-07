using SrPago.CocktailFinder.Domain.Enumerables;
using SrPago.CocktailFinder.Domain.Interfaces;
using SrPago.CocktailFinder.Domain.Models.Response;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace SrPago.Infrastructure.Data.Repository
{
    public class CategoryOptionRepository : ICategoryOptionRepository
    {
        public CategoryOptionRepository(IHttpClientFactory clientFactory)
        {
        }

        /// <summary>
        /// Retorna las opciones de tipos de busqueda que se pueden realizar
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<CategoryOptionResponse>> GetCategoryOptions()
        {
            var response = new List<CategoryOptionResponse>
            {
                new CategoryOptionResponse
                {
                    Id = (int)EnumCategoryOption.Category,
                    Description = EnumCategoryOption.Category.ToString()
                },
                new CategoryOptionResponse
                {
                    Id = (int)EnumCategoryOption.Glass,
                    Description = EnumCategoryOption.Glass.ToString()
                },
                new CategoryOptionResponse
                {
                    Id = (int)EnumCategoryOption.Ingredient,
                    Description = EnumCategoryOption.Ingredient.ToString()
                },
                new CategoryOptionResponse
                {
                    Id = (int)EnumCategoryOption.Name,
                    Description = EnumCategoryOption.Name.ToString()
                },
            };

            return await Task.FromResult<IEnumerable<CategoryOptionResponse>>(response);
        }
    }
}
