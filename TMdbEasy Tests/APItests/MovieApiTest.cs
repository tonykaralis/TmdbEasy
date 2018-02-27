using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SUT = TMdbEasy;

namespace TMdbEasy_Tests.APItests
{
    internal static class MovieApiTest
    {
        [TestFixture]
        [Category("MovieApi")]
        public class GetDetailsAsync
        {
            [TestCase(296096321)]
            public void IncorrectId_ThrowsException(int id, string language = "en")
            {
                //arrange
                var obj = new SUT.EasyClient("6d4b546936310f017557b2fb498b370b");
                //assert
                Assert.Throws<AggregateException>(() => { SUT.TmdbObjects.Movies.MovieDetails mov = obj.MovieApi.GetDetailsAsync(id).Result; });
            }
        }

        [TestFixture]
        [Category("MovieApi")]
        public class GetImagesAsync
        {
            [TestCase(296096321)]
            public void IncorrectId_ThrowsException(int id, string language = "en")
            {
                //arrange
                var obj = new SUT.EasyClient("6d4b546936310f017557b2fb498b370b");
                //assert
                Assert.Throws<AggregateException>(() => { SUT.TmdbObjects.Images.Images ima = obj.MovieApi.GetImagesAsync(id).Result; });
            }
        }

        [TestFixture]
        [Category("MovieApi")]
        public class GetAlternativetitlesAsync
        {
            [TestCase(296096321)]
            public void IncorrectId_ThrowsException(int id, string language = "en")
            {
                //arrange
                var obj = new SUT.EasyClient("6d4b546936310f017557b2fb498b370b");
                //assert
                Assert.Throws<AggregateException>(() => { SUT.TmdbObjects.Movies.AlternativeTitle tit = obj.MovieApi.GetAlternativeTitlesAsync(id).Result; });
            }
        }
    }
}
