using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SUT = TMdbEasy;

namespace TMdbEasy_Tests.APItests
{
    [Category("CompaniesApi")]
    internal static class CompaniesApiTest
    {
        [TestFixture]
        [Category("CompaniesApi")]
        public class GetDetailsAsync
        {
            [TestCase(296096321)]
            public void IncorrectId_ThrowsException(int id)
            {
                //arrange
                var obj = new SUT.EasyClient("6d4b546936310f017557b2fb498b370b");
                //assert
                Assert.Throws<AggregateException>(() => { SUT.TmdbObjects.Companies.CompanyDetails cd = obj.CompanyApi.GetDetailsAsync(id).Result; });
            }
        }

        [TestFixture]
        [Category("CompaniesApi")]
        public class GetMoviesAsync
        {
            [TestCase(254665465)]
            public void IncorrectId_ThrowsException(int id, string language = "en")
            {
                //arrange
                var obj = new SUT.EasyClient("6d4b546936310f017557b2fb498b370b");
                //assert
                Assert.Throws<AggregateException>(() => { SUT.TmdbObjects.Companies.MoviesByCompany mbc = obj.CompanyApi.GetMoviesAsync(id, language).Result; });
            }
        }
    }
}
