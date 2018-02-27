using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SUT = TMdbEasy;

namespace TMdbEasy_Tests.APItests
{
    internal static class ChangesApiTest
    {
        [TestFixture]
        [Category("ChangesApi")]
        public class GetMovieChangeListAsync
        {
            [TestCase("15091990")]
            [TestCase("20/02/2018", "2/02/2018")]
            public void IncorrectDate_ThrowsException(string end_date = null, string start_date = null, int page = 1)
            {
                //arrange
                var obj = new SUT.EasyClient("6d4b546936310f017557b2fb498b370b");
                //assert
                Assert.Throws<AggregateException>(() => { SUT.TmdbObjects.Changes.ChangeList ch
                    = obj.ChangeApi.GetMovieChangeListAsync(end_date,start_date,page).Result; });
            }
        }

        [TestFixture]
        [Category("ChangesApi")]
        public class GetPersonChangeListAsync
        {
            [TestCase("15091990")]
            [TestCase("20/02/2018", "24/022018")]
            public void IncorrectDate_ThrowsException(string end_date = null, string start_date = null, int page = 1)
            {
                //arrange
                var obj = new SUT.EasyClient("6d4b546936310f017557b2fb498b370b");
                //assert
                Assert.Throws<AggregateException>(() =>
                {
                    SUT.TmdbObjects.Changes.ChangeList ch
                        = obj.ChangeApi.GetPersonChangeListAsync(end_date, start_date, page).Result;
                });
            }
        }

        [TestFixture]
        [Category("ChangesApi")]
        public class GetTvChangeListAsync
        {
            [TestCase("15091990")]
            [TestCase("20/02/2018", "2602/2018")]
            public void IncorrectDate_ThrowsException(string end_date = null, string start_date = null, int page = 1)
            {
                //arrange
                var obj = new SUT.EasyClient("6d4b546936310f017557b2fb498b370b");
                //assert
                Assert.Throws<AggregateException>(() =>
                {
                    SUT.TmdbObjects.Changes.ChangeList ch
                        = obj.ChangeApi.GetTVChangeListAsync(end_date, start_date, page).Result;
                });
            }
        }
    }
}
