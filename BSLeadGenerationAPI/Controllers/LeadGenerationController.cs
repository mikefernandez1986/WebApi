using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using LeadGenAdminEntities.Entities;
using System.Web.Http.Description;
using LeadGenerationAdminBO.Interfaces;
using BSLeadGenerationAdminAPI.App_Start;
using LeadGenerationExceptionHandler;

namespace BSLeadGenerationAdminAPI.Controllers
{
    public class LeadGenerationController : LeadGenerationBaseApiController
    {
        private readonly ILeadGenBO _leadgenBO = null;
        public LeadGenerationController(ILeadGenBO leadgenBO)
        {
            _leadgenBO = leadgenBO;
        }

        [HttpGet]
        [Route(RouteConstants.GetLeadSource)]
        [ResponseType(typeof(List<LeadGenSourceEntities>))]
        public IHttpActionResult GetLeadSource()
        {
            List<LeadGenSourceEntities> _leadSource = new List<LeadGenSourceEntities>();
            _leadSource = _leadgenBO.GetLeadSource();
            if (_leadSource == null)
            {
                return NotFound();
            }
            return Ok(_leadSource);
        }


        [HttpPost]
        [Route(RouteConstants.InsertLeadSource)]
        [ResponseType(typeof(bool))]
        public IHttpActionResult InsertLeadSource(LeadGenSourceInputEntities leadGenSourceInputEntities)
        {
            return Ok(_leadgenBO.InsertLeadSource(leadGenSourceInputEntities));
        }


    }
}
