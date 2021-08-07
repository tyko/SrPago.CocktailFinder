namespace SrPago.CocktailFinder.Domain.Models.Response
{
    public class ElementResponse
    {
        private string _strDrinkThumb; public string strDrink { get; set; }
        public string strDrinkThumb
        {
            get => $"{_strDrinkThumb}/preview";
            set => _strDrinkThumb = value;
        }
        public string idDrink { get; set; }
    }
}
