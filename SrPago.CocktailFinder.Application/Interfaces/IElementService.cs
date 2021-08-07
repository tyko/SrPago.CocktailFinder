using SrPago.CocktailFinder.Domain.Models.Request;
using SrPago.CocktailFinder.Domain.Models.Response;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SrPago.CocktailFinder.Application.Interfaces
{
    public interface IElementService
    {
        Task<IEnumerable<ElementResponse>> GetSearchResult(SearchRequest request);
    }
}
