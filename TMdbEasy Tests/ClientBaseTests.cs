using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using SUT = TMdbEasy;

namespace TMdbEasy_Tests
{
    class ClientBaseTests
    {
        [TestFixture]
        [Category("Http methods")]
        public class DeserializeJsonTest
        {
            [TestCase("https://api.themoviedb.org/3/search/movie/?api_key=6d4b546936310f017557b2fb498b370b&query=007")]
            public async Task CorrectQuery_DoesNotReturnNull(string query)
            {
                //arrange
                var obj = new SUT.EasyClient("6d4b546936310f017557b2fb498b370b");
                //act
                SUT.Movie mov = await obj.GetMovieInfoAsync(query);
                //assert
                Assert.IsNotNull(mov);
            }
        }
    }
}
