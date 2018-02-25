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
            [TestCase(296096321)]
            public void IncorrectId_ThrowsException(int id, string language = "en")
            {
                //arrange
                var obj = new SUT.EasyClient("6d4b546936310f017557b2fb498b370b");
                //assert
                Assert.Throws<AggregateException>(() => { SUT.TmdbObjects.Movies.MovieDetails mov = obj.MovieApi.GetDetailsAsync(id).Result; });
            }
        }
    }
}
