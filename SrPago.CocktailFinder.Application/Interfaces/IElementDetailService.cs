using SrPago.CocktailFinder.Domain.Models.Request;
using SrPago.CocktailFinder.Domain.Models.Response;
using System.Threading.Tasks;

namespace SrPago.CocktailFinder.Application.Interfaces
{
    public interface IElementDetailService
    {
        Task<ElementDetailResponse> GetDetail(ElementDetailRequest request);
    }
}