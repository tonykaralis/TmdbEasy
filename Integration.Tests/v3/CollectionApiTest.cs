using NUnit.Framework;
using System.Threading.Tasks;
using TmdbEasy.Apis;
using TmdbEasy.DTO;
using TmdbEasy.DTO.Images;
using TmdbEasy.DTO.Other;
using TmdbEasy.Integration.Tests.TestFixtures;
using TmdbEasy.Interfaces;

namespace TmdbEasy.Integration.Tests.v3
{
    [TestFixture]
    [Category("ChangesApi")]
    public class CollectionApiTest : TestBaseForV3
    {
        private readonly ITmdbEasyClient _client;
        private readonly string _userApiKey;

        public CollectionApiTest()
        {
            _client = GetTestV3Client();
            _userApiKey = GetApiKey();
        }

        [TestCase(10)]
        public async Task GetDetailsAsync_ValidId_ReturnsValidResult(int id)
        {        
            ICollectionApi apiUnderTest = new CollectionApi(_client);

            var request = new IdRequest()
            {
                UserApiKey = _userApiKey,
                Id = id
            };

            Collections collections = await apiUnderTest.GetDetailsAsync(request);

            Assert.IsNotNull(collections);
            Assert.AreEqual(id, collections.Id);
            Assert.IsNotEmpty(collections.Parts);
        }

        [TestCase(10)]
        public async Task GetImagesAsync_ValidId_ReturnsValidResult(int id)
        {
            ICollectionApi apiUnderTest = new CollectionApi(_client);

            var request = new IdRequest()
            {
                UserApiKey = _userApiKey,
                Id = id
            };

            Images images= await apiUnderTest.GetImagesAsync(request);

            Assert.IsNotNull(images);
            Assert.AreEqual(id, images.Id);
            Assert.IsNotEmpty(images.Posters);
            Assert.IsNull(images.Stills);
            Assert.IsNotEmpty(images.Backdrops);            
        }
    }
}
