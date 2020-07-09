using LeadGenAdminEntities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeadGenerationAdmin.BO.UnitTest.TestCaseCreator
{
    public class InsertLeadSourceNegativeTestCaseCreator
    {
        #region Private Variables
        private static LeadGenSourceInputEntities _leadGenSourceInputEntities_NullRequest = null;

        private static LeadGenSourceInputEntities _leadGenSourceInputEntities_WithoutUserId = new LeadGenSourceInputEntities
        {
            Sourcename = "Test"
        };
        private static LeadGenSourceInputEntities _leadGenSourceInputEntities_WithoutSourceName = new LeadGenSourceInputEntities
        {
            UserId = 1
        };

        #endregion

        #region Public Methods

        public static readonly List<object[]> InsertLeadSourceValidationTest = new List<object[]> {
            new object[] { _leadGenSourceInputEntities_NullRequest , "Required Input Parameters Not Passed" },
            new object[] { _leadGenSourceInputEntities_WithoutSourceName, "Source name is Required" },
            new object[] { _leadGenSourceInputEntities_WithoutUserId, "User Id 0 is not valid user" }
        };

        public static IEnumerable<object[]> InsertLeadSourceValidationIndex
        {
            get
            {
                List<object[]> _leadInsertValidationTest = new List<object[]>();
                for(int i = 0; i < InsertLeadSourceValidationTest.Count; i++)
                {
                    _leadInsertValidationTest.Add(new object[] { i });
                }
                return _leadInsertValidationTest;
            }
        }

        #endregion
    }
}
