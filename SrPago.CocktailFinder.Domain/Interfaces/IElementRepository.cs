using SrPago.CocktailFinder.Domain.Models.Request;
using SrPago.CocktailFinder.Domain.Models.Response;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SrPago.CocktailFinder.Domain.Interfaces
{
    public interface IElementRepository
    {
        Task<IEnumerable<ElementResponse>> GetResultAsync(SearchRequest request);
    }
}
