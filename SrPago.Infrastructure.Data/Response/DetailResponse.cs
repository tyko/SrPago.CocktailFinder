using SrPago.CocktailFinder.Domain.Models.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace SrPago.Infrastructure.Data.Response
{
    public class DetailResponse
    {
        public IEnumerable<Ingredients> drinks { get; set; }

        public ElementDetailResponse GetRecipe()
        {
            var result = new List<ElementDetailResponse>();
            foreach (var drink in drinks)
            {
                var recipe = new ElementDetailResponse
                {
                    DrinkName = drink.strDrink,
                    Category = drink.strCategory,
                    Glass = drink.strGlass,
                    Instructions = drink.strInstructions,
                    IsAlcoholicDrink = drink.strAlcoholic,
                    Thumbnail = drink.strDrinkThumb,
                    Ingredients = GetIngredients()
                };

                result.Add(recipe);
            }

            return result.First();
        }

        //private IEnumerable<Tuple<string, string>> GetIngredients()
        private string GetIngredients()

        {
            //var result = new List<Tuple<string, string>>();
            var result = string.Empty;
            Type myType = drinks.First().GetType();
            IList<PropertyInfo> props = new List<PropertyInfo>(myType.GetProperties());


            for (int i = 1; i < 16; i++)
            {
                var ingredientProperty = props.First(p => p.Name.Equals($"strIngredient{i}"));
                var measureProperty = props.First(p => p.Name.Equals($"strMeasure{i}"));

                var ingredient = (string)ingredientProperty.GetValue(drinks.First(), null);
                var measure = (string)measureProperty.GetValue(drinks.First(), null);
                if (ingredient != null || measure != null)
                {
                    //result.Add(new Tuple<string, string>(ingredient,measure));
                    result += $"{ingredient} => {measure}{Environment.NewLine}";
                }
            }

            return result;
        }
    }

    public class Ingredients
    {
        public string idDrink { get; set; }
        public string strDrink { get; set; }
        public object strDrinkAlternate { get; set; }
        public string strTags { get; set; }
        public object strVideo { get; set; }
        public string strCategory { get; set; }
        public string strIBA { get; set; }
        public string strAlcoholic { get; set; }
        public string strGlass { get; set; }
        public string strInstructions { get; set; }
        public object strInstructionsES { get; set; }
        public string strInstructionsDE { get; set; }
        public object strInstructionsFR { get; set; }
        public string strInstructionsIT { get; set; }
        public object strInstructionsZHHANS { get; set; }
        public object strInstructionsZHHANT { get; set; }
        public string strDrinkThumb { get; set; }
        public string strIngredient1 { get; set; }
        public string strIngredient2 { get; set; }
        public string strIngredient3 { get; set; }
        public string strIngredient4 { get; set; }
        public string strIngredient5 { get; set; }
        public string strIngredient6 { get; set; }
        public string strIngredient7 { get; set; }
        public object strIngredient8 { get; set; }
        public object strIngredient9 { get; set; }
        public object strIngredient10 { get; set; }
        public object strIngredient11 { get; set; }
        public object strIngredient12 { get; set; }
        public object strIngredient13 { get; set; }
        public object strIngredient14 { get; set; }
        public object strIngredient15 { get; set; }
        public string strMeasure1 { get; set; }
        public string strMeasure2 { get; set; }
        public string strMeasure3 { get; set; }
        public string strMeasure4 { get; set; }
        public string strMeasure5 { get; set; }
        public string strMeasure6 { get; set; }
        public string strMeasure7 { get; set; }
        public object strMeasure8 { get; set; }
        public object strMeasure9 { get; set; }
        public object strMeasure10 { get; set; }
        public object strMeasure11 { get; set; }
        public object strMeasure12 { get; set; }
        public object strMeasure13 { get; set; }
        public object strMeasure14 { get; set; }
        public object strMeasure15 { get; set; }
        public string strImageSource { get; set; }
        public string strImageAttribution { get; set; }
        public string strCreativeCommonsConfirmed { get; set; }
        public string dateModified { get; set; }
    }

}