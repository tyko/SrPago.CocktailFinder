using SrPago.CocktailFinder.Application.Interfaces;
using SrPago.CocktailFinder.Domain.Interfaces;
using SrPago.CocktailFinder.Domain.Models.Response;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SrPago.CocktailFinder.Application.Services
{
    public class CategoyOptionService : ICategoryOptionService
    {
        private readonly ICategoryOptionRepository _categoryOptionRepository;
        private IElementService ElementService { get; }

        public CategoyOptionService(ICategoryOptionRepository categoryOptionRepository, IElementService elementService)
        {
            _categoryOptionRepository = categoryOptionRepository;
            ElementService = elementService;
        }

        public async Task<IEnumerable<CategoryOptionResponse>> GetCategoryOptions()
        {
            return await _categoryOptionRepository.GetCategoryOptions();
        }
    }
}
