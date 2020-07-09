using LeadGenerationExceptionHandler;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

namespace LeadGenerationExceptionHandler
{

    [LeadGenerationApiActionFilterAttribute]
    [LeadGenerationApiExceptionFilterAttribute]
    public abstract class LeadGenerationBaseApiController : ApiController
    {
        protected LeadGenerationBaseApiController()
        {

        }
    }
}
