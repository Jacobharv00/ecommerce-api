using Microsoft.AspNetCore.Mvc.Filters;

namespace EcommerceAPI.Filters
{
    public class StatsFilter : IActionFilter
    {
        public void OnActionExecuting(ActionExecutingContext context)
        {
            DateTime reference = new DateTime(2024, 1, 1);
            TimeSpan time = DateTime.Now - reference;

            Console.WriteLine("[StatusFilter] OnActionExecuting - Time=" +
                time.TotalMilliseconds + "ms");
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
            DateTime reference = new DateTime(2024, 1, 1);
            TimeSpan time = DateTime.Now - reference;

            Console.WriteLine("[StatusFilter] OnActionExecuted - Time=" +
                time.TotalMilliseconds + "ms");
        }
    }
}
