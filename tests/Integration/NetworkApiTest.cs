using NUnit.Framework;
using System.Threading.Tasks;
using TmdbEasy.Apis;
using TmdbEasy.DTO.Other;
using TmdbEasy.Interfaces;
using TmdbEasy.Tests.Integration.TestFixtures;

namespace TmdbEasy.Tests.Integration
{
    [Category("NetworkApi")]
    internal class NetworkApiTest : TestBase
    {       
        [TestCase(213)]
        public async Task GetDetailsAsync_ValidId_CustomApiKey_ReturnsValidResult(int id)
        {
            INetworksApi apiUnderTest = new NetworksApi(_clientWithNoApiKey);

            Network result = await apiUnderTest.GetDetailsAsync(id, _userApiKey);

            Assert.IsNotNull(result);
            Assert.AreEqual(id, result.Id);
        }

        [TestCase(213)]
        public async Task GetDetailsAsync_ValidId_DefaultApiKey_ReturnsValidResult(int id)
        {
            INetworksApi apiUnderTest = new NetworksApi(_clientWithApiKey);

            Network result = await apiUnderTest.GetDetailsAsync(id);

            Assert.IsNotNull(result);
            Assert.AreEqual(id, result.Id);
        }
    }
}
