using SrPago.CocktailFinder.Domain.Models.Response;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SrPago.CocktailFinder.Domain.Interfaces
{
    public interface ICategoryOptionRepository
    {
        Task<IEnumerable<CategoryOptionResponse>> GetCategoryOptions();
    }
}
