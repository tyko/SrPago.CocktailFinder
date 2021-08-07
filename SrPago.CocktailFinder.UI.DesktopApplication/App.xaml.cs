using Microsoft.Extensions.DependencyInjection;
using SrPago.CocktailFinder.Application.Interfaces;
using SrPago.CocktailFinder.Infrastructure.IoC;
using System.Windows;

namespace SrPago.CocktailFinder.UI.DesktopApplication
{
    public partial class App : System.Windows.Application
    {
        private readonly ServiceProvider _serviceProvider;
        public App()
        {
            var serviceCollection = new ServiceCollection();
            ConfigureServices(serviceCollection);
            _serviceProvider = serviceCollection.BuildServiceProvider();
        }

        /// <summary>
        /// Configuracion de la inyeccion de dependencias
        /// </summary>
        /// <param name="services"></param>
        private void ConfigureServices(IServiceCollection services)
        {
            DependencyContainer.RegisterServices(services);
        }

        /// <summary>
        /// Se inyectan las dependencias a la ventana principal
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnStartup(object sender, StartupEventArgs e)
        {
            var mainWindow = new MainWindowV2(
                _serviceProvider.GetService<ICategoryOptionService>(),
                _serviceProvider.GetService<IElementService>(),
                _serviceProvider.GetService<IElementDetailService>());
            mainWindow.Show();
        }
    }
}
