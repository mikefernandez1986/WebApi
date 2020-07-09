using LeadGenAdminEntities.Entities;
using LeadGenerationAdminBO.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LeadGenerationAdminDAO.ILeadGen;
using LeadGenAdminEntities.Error;

namespace LeadGenerationAdminBO
{
    public class LeadGenBO: ILeadGenBO
    {
        #region Private Variables
        private readonly ILeadGenDAO _leadgenDAO = null;

        #endregion

        public LeadGenBO(ILeadGenDAO leadgenDAO)
        {
            _leadgenDAO = leadgenDAO;
        }

        #region Public Methods
        public List<LeadGenSourceEntities> GetLeadSource()
        {
            List<LeadGenSourceEntities> _leadDetails = _leadgenDAO.GetLeadSource();
            return _leadDetails;
        }
        
        public bool InsertLeadSource(LeadGenSourceInputEntities leadGenSourceInputEntities)
        {
            ValidateLeadGenSourceInput(leadGenSourceInputEntities);
            bool _isInsertSuccess = _leadgenDAO.InsertLeadSource(leadGenSourceInputEntities);
            return _isInsertSuccess;
        }

        #endregion


        #region Private methods

        private void ValidateLeadGenSourceInput(LeadGenSourceInputEntities leadGenSourceInputEntities)
        {
            string errorMesssage;
            if (leadGenSourceInputEntities == null)
            {
                errorMesssage = "Required Input Parameters Not Passed";
                throw new LeadGenerationValidationException("Error-LGAdmin-100", errorMesssage);
            }
            if (string.IsNullOrEmpty(leadGenSourceInputEntities.Sourcename))
            {
                errorMesssage = "Source name is Required";
                throw new LeadGenerationValidationException("Error-LGAdmin-101", errorMesssage);
            }
            if(leadGenSourceInputEntities.UserId <= 0)
            {
                errorMesssage = string.Format("User Id {0} is not valid user", leadGenSourceInputEntities.UserId);
                throw new LeadGenerationValidationException("Error-LGAdmin-102", errorMesssage);
            }
        }

        #endregion
    }
}
