using SrPago.CocktailFinder.Application.Annotations;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace SrPago.CocktailFinder.Application.ViewModels
{
    public class ViewModelBase : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
