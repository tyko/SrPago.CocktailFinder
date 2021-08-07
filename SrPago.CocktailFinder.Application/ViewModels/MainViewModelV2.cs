using SrPago.CocktailFinder.Application.Interfaces;
using SrPago.CocktailFinder.Application.ViewModels.Command;
using SrPago.CocktailFinder.Domain.Models.Request;
using SrPago.CocktailFinder.Domain.Models.Response;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;

namespace SrPago.CocktailFinder.Application.ViewModels
{
    public class MainViewModelV2 : ViewModelBase
    {
        private readonly ICategoryOptionService _categoryOptionService;
        private readonly IElementDetailService _elementDetailService;
        private readonly IElementService _elementService;
        private CategoryOptionResponse _categoryOptionSelected;
        private ElementResponse _drinkSelected;
        private ElementDetailResponse _drinkDetail;
        private Cursor _cursorWait;

        public IEnumerable<CategoryOptionResponse> CategoryOptions { get; set; }
        public string NameDrinkToSearch { get; set; }
        public SearchRequest SearchRequest { get; set; }
        public IEnumerable<ElementResponse> DrinkListResult { get; set; }

        public ElementDetailResponse DrinkDetail
        {
            get => _drinkDetail;
            set
            {
                if (_drinkDetail != value)
                {
                    _drinkDetail = value;
                    OnPropertyChanged();
                }
            }
        }
        public CategoryOptionResponse CategoryOptionSelected
        {
            get => _categoryOptionSelected;
            set
            {
                if (_categoryOptionSelected != value)
                {
                    _categoryOptionSelected = value;
                    NameDrinkToSearch = string.Empty;
                    OnPropertyChanged();
                    OnPropertyChanged(nameof(NameDrinkToSearch));
                    OnPropertyChanged(nameof(CanSearchByName));
                }
            }
        }
        public ElementResponse DrinkSelected
        {
            get => _drinkSelected;
            set
            {
                if (_drinkSelected != value)
                {
                    _drinkSelected = value;
                    if (_drinkSelected != null)
                    {
                        Task.Run(Detail).Wait();
                        OnPropertyChanged(nameof(DrinkDetail));
                    }
                    OnPropertyChanged();
                }
            }
        }
        public bool CanSearchByName => CategoryOptionSelected?.Id == 4;
        public bool AreDrinkResult => DrinkListResult?.Any() ?? false;
        public bool IsDrinkSelected => DrinkDetail != null;
        public Cursor CursorWait
        {
            get => _cursorWait;
            set
            {
                if (_cursorWait != value)
                {
                    _cursorWait = value;
                    OnPropertyChanged();
                }
            }
        }

        //Constructor
        public MainViewModelV2(ICategoryOptionService categoryOptionService, IElementService elementService, IElementDetailService elementDetailService)
        {
            _categoryOptionService = categoryOptionService;
            _elementDetailService = elementDetailService;
            _elementService = elementService;
            LoadCommandAsync = new AsyncCommand(Load);
            SearchCommand = new AsyncCommand(Search);
        }

        //Commands

        /// <summary>
        /// Realiza la carga inicial de la ventana
        /// </summary>
        public AsyncCommand LoadCommandAsync { get; }

        /// <summary>
        /// Realiza la busqueda de bebidas dependiendo de los criterios de busqueda seleccionados
        /// </summary>
        public AsyncCommand SearchCommand { get; }


        /// <summary>
        /// Se ejecuta cuando se cargan los catalogos
        /// </summary>
        /// <returns></returns>
        public async Task Load()
        {
            CategoryOptions = await _categoryOptionService.GetCategoryOptions();
            OnPropertyChanged(nameof(CategoryOptions));
            OnPropertyChanged(nameof(IsDrinkSelected));
        }

        /// <summary>
        /// Se ejecuta para realizar la busqueda de bebidas
        /// </summary>
        /// <returns></returns>
        public async Task Search()
        {
            CursorWait = Cursors.Wait;
            OnPropertyChanged(nameof(CursorWait));

            var request = new SearchRequest
            {
                SearchType = CategoryOptionSelected.Id,
                NameToSearch = NameDrinkToSearch
            };
            DrinkListResult = await _elementService.GetSearchResult(request);
            OnPropertyChanged(nameof(DrinkListResult));
            OnPropertyChanged(nameof(AreDrinkResult));

            CursorWait = Cursors.Arrow;
            OnPropertyChanged(nameof(CursorWait));
        }

        /// <summary>
        /// Se ejecuta para obtener los detalles de una bebida
        /// </summary>
        /// <returns></returns>
        public async Task Detail()
        {
            var request = new ElementDetailRequest
            {
                Id = DrinkSelected.idDrink
            };
            DrinkDetail = await _elementDetailService.GetDetail(request);
            OnPropertyChanged(nameof(DrinkDetail));
            OnPropertyChanged(nameof(IsDrinkSelected));
        }
    }
}