using Autofac.Extras.Moq;
using LeadGenerationAdminDAO.ILeadGen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Moq;
using LeadGenAdminEntities.Entities;
using LeadGenerationAdminBO;
using Newtonsoft.Json;
using LeadGenerationAdmin.BO.UnitTest.TestCaseCreator;
using LeadGenAdminEntities.Error;

namespace LeadGenerationAdmin.BO.UnitTest
{
    public class InsertLeadSourceTestCases
    {
        #region Private variables

        private bool _success = true;
        private LeadGenSourceInputEntities leadGenSourceInputEntities = new LeadGenSourceInputEntities
        {
            Sourcename = "Test",
            UserId = 1
        };

        #endregion

        #region Public Methods

        #region Positive Test Cases

        [Fact]
        public void TestGetLeadSource_ShouldReturn_Success()
        {
            using (var mock = AutoMock.GetLoose())
            {
                mock.Mock<ILeadGenDAO>().Setup(x => x.GetLeadSource()).Returns(GetLeadGenSourceList());
                var _leadGenBo = mock.Create<LeadGenBO>();
                var _actual = _leadGenBo.GetLeadSource();
                Assert.Equal(JsonConvert.SerializeObject(GetLeadGenSourceList()), JsonConvert.SerializeObject(_actual));
            }
        }
        [Fact]
        public void TestInsertLeadSource_ShouldReturn_Success()
        {
            using(var mock = AutoMock.GetLoose())
            {
                mock.Mock<ILeadGenDAO>().Setup(x => x.InsertLeadSource(It.IsAny<LeadGenSourceInputEntities>())).Returns(_success);
                var _leadGenBo = mock.Create<LeadGenBO>();
                var _actual = _leadGenBo.InsertLeadSource(leadGenSourceInputEntities);
                Assert.Equal(_success, _actual);
            }
        }

        #endregion

        #region Negative Test Cases

        [Theory]
        [MemberData(nameof(InsertLeadSourceNegativeTestCaseCreator.InsertLeadSourceValidationIndex),
            MemberType = typeof(TestCaseCreator.InsertLeadSourceNegativeTestCaseCreator))]
        public void InsertLeadSource_ValidationTest(int input)
        {
            string _expected = string.Empty;

            var _request = InsertLeadSourceNegativeTestCaseCreator.InsertLeadSourceValidationTest[input];

            _expected = (string)_request[1];
            LeadGenSourceInputEntities _leadGenSourceInputEntities = new LeadGenSourceInputEntities();
            _leadGenSourceInputEntities = (LeadGenSourceInputEntities)_request[0];

            using (var mock = AutoMock.GetLoose())
            {
                mock.Mock<ILeadGenDAO>().Setup(x => x.InsertLeadSource(It.IsAny<LeadGenSourceInputEntities>())).Returns(_success);
                var _leadGenBo = mock.Create<LeadGenBO>();
                var _actual = Assert.Throws<LeadGenerationValidationException>(() => _leadGenBo.InsertLeadSource(_leadGenSourceInputEntities));

                Assert.Equal(_expected, _actual.Message);
            }
        }

        #endregion

        #endregion

        #region Private methods

        private List<LeadGenSourceEntities> GetLeadGenSourceList()
        {
            List<LeadGenSourceEntities> _leadGenerationSourceCollection = new List<LeadGenSourceEntities>();

            LeadGenSourceEntities leadGenSourceEntities1 = new LeadGenSourceEntities
            {
                LeadId = 1,
                Sourcename = "ATM"
            };
            _leadGenerationSourceCollection.Add(leadGenSourceEntities1);
            LeadGenSourceEntities leadGenSourceEntities2 = new LeadGenSourceEntities
            {
                LeadId = 2,
                Sourcename = "Internet"
            };
            _leadGenerationSourceCollection.Add(leadGenSourceEntities2);

            return _leadGenerationSourceCollection;
        }

        #endregion

    }
}
