using SrPago.Infrastructure.Data.Interfaces;
using System.Collections.Generic;

namespace SrPago.Infrastructure.Data.Response
{
    public class CategoryResponse : IResponse
    {
        public IEnumerable<Category> drinks { get; set; }

        public IEnumerable<string> GetCategories()
        {
            List<string> result = new List<string>();
            foreach (var category in drinks)
            {
                result.Add(category.strCategory);
            }

            return result;
        }
    }

    public class Category
    {
        public string strCategory { get; set; }
    }

}