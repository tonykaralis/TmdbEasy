using NUnit.Framework;
using System.Threading.Tasks;
using TmdbEasy.Apis;
using TmdbEasy.Data.Changes;
using TmdbEasy.Data.Reviews;
using TmdbEasy.DTO;
using TmdbEasy.Enums;
using TmdbEasy.Integration.Tests.TestFixtures;
using TmdbEasy.Interfaces;

namespace TMdbEasy.Integration.Tests.v3
{
    [TestFixture]
    [Category("ChangesApi")]
    public class ChangesApiTest : TestBaseForV3
    {
        [Test]
        public async Task GetChangeListAsync_SpecificDateRange_ReturnsChangeList()
        {
            ITmdbEasyClient client = GetTestV3Client();

            string userApiKey = GetApiKey();

            IChangesApi serviceUnderTest = new ChangesApi(client);

            var request = new ChangeListRequest()
            {
                UserApiKey = userApiKey,
                Start_date = "25/07/2020",
                End_date = "26/07/2020"
            };

            ChangeList changeList = await serviceUnderTest.GetChangeListAsync(request);

            Assert.IsNotNull(changeList);
            Assert.IsNotEmpty(changeList.Results);
        }

        [Test]
        public async Task GetChangeListAsync_SpecificType_ReturnsChangeList()
        {
            ITmdbEasyClient client = GetTestV3Client();

            string userApiKey = GetApiKey();

            IChangesApi serviceUnderTest = new ChangesApi(client);

            var request = new ChangeListRequest()
            {
                UserApiKey = userApiKey,
                Start_date = "25/07/2020",
                End_date = "26/07/2020",
                Type = ChangeType.TV
            };

            ChangeList changeList = await serviceUnderTest.GetChangeListAsync(request);

            Assert.IsNotNull(changeList);
            Assert.IsNotEmpty(changeList.Results);
        }
    }
}
