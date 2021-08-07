using SrPago.Infrastructure.Data.Interfaces;
using System.Collections.Generic;

namespace SrPago.Infrastructure.Data.Response
{
    public class IngredientResponse : IResponse
    {
        public IEnumerable<Ingredient> drinks { get; set; }

        public IEnumerable<string> GetCategories()
        {
            List<string> result = new List<string>();
            foreach (var category in drinks)
            {
                result.Add(category.strIngredient1);
            }
            return result;
        }
    }

    public class Ingredient
    {
        public string strIngredient1 { get; set; }
    }

}