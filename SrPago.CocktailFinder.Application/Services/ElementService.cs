using SrPago.CocktailFinder.Application.Interfaces;
using SrPago.CocktailFinder.Domain.Interfaces;
using SrPago.CocktailFinder.Domain.Models.Request;
using SrPago.CocktailFinder.Domain.Models.Response;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SrPago.CocktailFinder.Application.Services
{
    public class ElementService : IElementService
    {
        private readonly IElementRepository _elementRepository;
        private readonly IElementDetailService _elementDetailService;

        public ElementService(IElementRepository elementRepository, IElementDetailService elementDetailService)
        {
            _elementRepository = elementRepository;
            _elementDetailService = elementDetailService;
        }

        public async Task<IEnumerable<ElementResponse>> GetSearchResult(SearchRequest request)
        {
            return await _elementRepository.GetResultAsync(request);
        }
    }
}