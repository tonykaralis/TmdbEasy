using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using TMdbEasy.ApiInterfaces;
using TMdbEasy.ApiObjects;
using SUT = TMdbEasy;

namespace TMdbEasy_Tests
{
    internal static class RequestEngineTest
    {
        [TestFixture]
        [Category("RequestEngine")]
        public class InitializeTest
        {
            [TestCase(null)]
            [TestCase("")]
            [TestCase(" ")]
            [TestCase("kjysudgfi8764")]
            public void InvalidApiKey_ReturnsArgumentException(string _apikey)
            {
                //Assert
                Assert.Throws<Exception>(() => new SUT.EasyClient(_apikey));
            }

            [TestCase(Constants.ValidApiKey)]
            public void SecuredParam_AssignsSecureUrl(string _apikey, bool secure = true)
            {
                //Arrange
                var obj = new SUT.EasyClient(_apikey, secure);

                //Assert
                Assert.AreEqual(SUT.REngine.Secured, true);
                Assert.AreEqual(SUT.REngine.Url, "https://api.themoviedb.org/3/");
            }

            [TestCase(Constants.ValidApiKey, false)]
            public void UnSecuredParam_AssignsUnsecureUrl(string _apikey, bool secure = false)
            {
                //Arrange
                var obj = new SUT.EasyClient(_apikey, secure);

                //Assert
                Assert.AreEqual(SUT.REngine.Secured, false);
                Assert.AreEqual(SUT.REngine.Url, "http://api.themoviedb.org/3/");
            }
        }

        [TestFixture]
        [Category("Json")]
        public class DeserializeJsonTest
        {
            [TestCase(296096)]
            public async Task CorrectQuery_DoesNotReturnNull(int id)
            {
                //arrange
                var obj = new SUT.EasyClient(Constants.ValidApiKey);
                var d = obj.GetApi<IMovieApi>().Value;
                //act
                SUT.TmdbObjects.Movies.MovieFullDetails mov = await d.GetDetailsAsync(id).ConfigureAwait(false);
                //assert
                Assert.IsNotNull(mov);
            }
        }
    }
}
