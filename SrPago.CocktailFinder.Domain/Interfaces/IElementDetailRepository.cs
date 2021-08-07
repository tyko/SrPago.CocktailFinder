using SrPago.CocktailFinder.Domain.Models.Request;
using SrPago.CocktailFinder.Domain.Models.Response;
using System.Threading.Tasks;

namespace SrPago.CocktailFinder.Domain.Interfaces
{
    public interface IElementDetailRepository
    {
        public Task<ElementDetailResponse> GetElementDetailAsync(ElementDetailRequest request);
    }
}
