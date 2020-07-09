using LeadGenAdminEntities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeadGenerationAdminBO.Interfaces
{
    public interface ILeadGenBO
    {
        List<LeadGenSourceEntities> GetLeadSource();

        bool InsertLeadSource(LeadGenSourceInputEntities leadGenSourceInputEntities);
    }
}
