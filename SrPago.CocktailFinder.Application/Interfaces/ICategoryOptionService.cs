using SrPago.CocktailFinder.Domain.Models.Response;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SrPago.CocktailFinder.Application.Interfaces
{
    public interface ICategoryOptionService
    {
        Task<IEnumerable<CategoryOptionResponse>> GetCategoryOptions();

    }
}
