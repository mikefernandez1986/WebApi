using System.Web.Http.Controllers;
using System.Web.Http.Filters;

namespace LeadGenerationExceptionHandler
{
    public class LeadGenerationApiActionFilterAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(HttpActionContext actionContext)
        {
            //setting up the controller for future use to get the tokens or identify the user
            LeadGenerationBaseApiController controller = (LeadGenerationBaseApiController)actionContext.ControllerContext.Controller;

            //string user = Convert.ToString(controller.User);
        }
    }
}
