using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SUT = TMdbEasy;
using System.Threading.Tasks;

namespace TMdbEasy_Tests.APItests
{
    class MovieApiTest
    {
        [TestFixture]
        [Category("")]
        public class GetDetailsAsync
        {
            [TestCase(296096)]
            public async Task IncorrectQuery_ReturnsNull(int id, string language = "en")
            {
                //arrange
                var obj = new SUT.EasyClient("6d4b546936310f017557b2fb498b370b");
                //act
                SUT.TmdbObjects.Movies.MovieDetails mov = await obj.MovieApi.GetDetailsAsync(id);
                //assert
                Assert.IsNotNull(mov);
            }
        }

        [TestFixture]
        [Category("")]
        public class GetImagesAsync
        {
            [TestCase(296096)]
            public async Task CorrectQuery_DoesNotReturnNull(int id)
            {
                //arrange
                var obj = new SUT.EasyClient("6d4b546936310f017557b2fb498b370b");
                //act
                SUT.TmdbObjects.Movies.MovieDetails mov = await obj.MovieApi.GetDetailsAsync(id);
                //assert
                Assert.IsNotNull(mov);
            }

        }

        [TestFixture]
        [Category("")]
        public class GetAlternativeTitlesAsync(int id, string country = "en")
        {
            [TestCase(296096)]
        public async Task CorrectQuery_DoesNotReturnNull(int id)
        {
            //arrange
            var obj = new SUT.EasyClient("6d4b546936310f017557b2fb498b370b");
            //act
            SUT.TmdbObjects.Movies.MovieDetails mov = await obj.MovieApi.GetDetailsAsync(id);
            //assert
            Assert.IsNotNull(mov);
        }
    }
}
