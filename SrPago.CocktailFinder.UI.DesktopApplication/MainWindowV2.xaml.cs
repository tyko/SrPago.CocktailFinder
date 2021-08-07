using SrPago.CocktailFinder.Application.Interfaces;
using SrPago.CocktailFinder.Application.ViewModels;
using System.Windows;

namespace SrPago.CocktailFinder.UI.DesktopApplication
{
    /// <summary>
    /// Interaction logic for MainWindowV2.xaml
    /// </summary>
    public partial class MainWindowV2 : Window
    {
        private MainViewModelV2 _viewModel;
        private readonly ICategoryOptionService _categoryOptionService;
        private readonly IElementService _elementService;
        private readonly IElementDetailService _elementDetailService;

        public MainWindowV2(ICategoryOptionService categoryOptionService, IElementService elementService, IElementDetailService elementDetailService)
        {
            InitializeComponent();
            _categoryOptionService = categoryOptionService;
            _elementService = elementService;
            _elementDetailService = elementDetailService;
            _viewModel = new MainViewModelV2(_categoryOptionService, _elementService, _elementDetailService);
            DataContext = _viewModel;
            Loaded += MainWindow_Loaded;
        }

        /// <summary>
        /// Metodo para realizar la carga inicial del catalogo de categorias
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            _viewModel.Load();

        }
    }
}
