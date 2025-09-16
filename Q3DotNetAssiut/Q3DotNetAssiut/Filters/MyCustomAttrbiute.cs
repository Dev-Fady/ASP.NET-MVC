using Microsoft.AspNetCore.Mvc.Filters;

namespace Q3DotNetAssiut.Filters
{
    public class MyCustomAttrbiute : Attribute,IActionFilter
    {
        public void OnActionExecuted(ActionExecutedContext context)
        {
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
        }
    }
}
