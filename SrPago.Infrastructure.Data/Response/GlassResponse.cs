using SrPago.Infrastructure.Data.Interfaces;
using System.Collections.Generic;

namespace SrPago.Infrastructure.Data.Response
{

    public class GlassResponse : IResponse

    {
        public IEnumerable<Glass> drinks { get; set; }

        public IEnumerable<string> GetCategories()
        {
            List<string> result = new List<string>();
            foreach (var category in drinks)
            {
                result.Add(category.strGlass);
            }

            return result;
        }
    }

    public class Glass
    {
        public string strGlass { get; set; }
    }


}