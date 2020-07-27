using NUnit.Framework;
using System.Threading.Tasks;
using TmdbEasy.Apis;
using TmdbEasy.DTO;
using TmdbEasy.DTO.Changes;
using TmdbEasy.Enums;
using TmdbEasy.Integration.Tests.TestFixtures;
using TmdbEasy.Interfaces;

namespace TmdbEasy.Integration.Tests.v3
{
    [TestFixture]
    [Category("ChangesApi")]
    public class ChangesApiTest : TestBaseForV3
    {
        [Test]
        public async Task GetChangeListAsync_SpecificDateRange_ReturnsChangeList()
        {
            IChangesApi apiUnderTest = new ChangesApi(_client);

            var request = new ChangeListRequest()
            {
                UserApiKey = _userApiKey,
                Start_date = "25/07/2020",
                End_date = "26/07/2020"
            };

            ChangeList changeList = await apiUnderTest.GetChangeListAsync(request);

            Assert.IsNotNull(changeList);
            Assert.IsNotEmpty(changeList.Results);
        }

        [Test]
        public async Task GetChangeListAsync_SpecificType_ReturnsChangeList()
        {
            IChangesApi apiUnderTest = new ChangesApi(_client);

            var request = new ChangeListRequest()
            {
                UserApiKey = _userApiKey,
                Start_date = "25/07/2020",
                End_date = "26/07/2020",
                Type = ChangeType.TV
            };

            ChangeList changeList = await apiUnderTest.GetChangeListAsync(request);

            Assert.IsNotNull(changeList);
            Assert.IsNotEmpty(changeList.Results);
        }
    }
}
