using SrPago.CocktailFinder.Application.Interfaces;
using SrPago.CocktailFinder.Domain.Interfaces;
using SrPago.CocktailFinder.Domain.Models.Request;
using SrPago.CocktailFinder.Domain.Models.Response;
using System.Threading.Tasks;

namespace SrPago.CocktailFinder.Application.Services
{
    public class ElementDetailService : IElementDetailService
    {
        private readonly IElementDetailRepository _elementDetailRepository;

        public ElementDetailService(IElementDetailRepository elementDetailRepository)
        {
            _elementDetailRepository = elementDetailRepository;
        }

        public async Task<ElementDetailResponse> GetDetail(ElementDetailRequest request)
        {
            return await _elementDetailRepository.GetElementDetailAsync(request);
        }
    }
}