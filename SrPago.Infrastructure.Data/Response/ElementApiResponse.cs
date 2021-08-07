using SrPago.CocktailFinder.Domain.Models.Response;
using System.Collections.Generic;

namespace SrPago.Infrastructure.Data.Response
{
    public class ElementApiResponse
    {
        public IEnumerable<ElementResponse> drinks { get; set; }
    }
}