using System.Collections.Generic;

namespace SrPago.Infrastructure.Data.Interfaces
{
    public interface IResponse
    {
        IEnumerable<string> GetCategories();
    }
}