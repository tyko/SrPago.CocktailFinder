using System.Threading.Tasks;

namespace SrPago.CocktailFinder.Application.ViewModels.Command
{
    public static class TaskUtilities
    {
#pragma warning disable RECS0165 // Asynchronous methods should return a Task instead of void
        public static async void FireAndForgetSafeAsync(this Task task)
#pragma warning restore RECS0165 // Asynchronous methods should return a Task instead of void
        {
            await task;
        }
    }
}