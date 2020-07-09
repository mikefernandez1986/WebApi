using LeadGenAdminEntities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeadGenerationAdminDAO.ILeadGen
{
    public interface ILeadGenDAO
    {
        List<LeadGenSourceEntities> GetLeadSource();
        bool InsertLeadSource(LeadGenSourceInputEntities leadGenSourceInputEntities);
    }
}
