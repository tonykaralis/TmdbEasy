using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMdbEasy.ApiInterfaces;
using SUT = TMdbEasy;

namespace TMdbEasy_Tests.APItests
{
    [Category("CollectionApi")]
    internal static class CollectionApiTest
    {
        [TestFixture]
        [Category("CollectionApi")]
        public class GetDetailsAsync
        {
            [TestCase(296096321)]
            public void IncorrectId_ThrowsException(int id, string language = "en")
            {
                //arrange
                var obj = new SUT.EasyClient("6d4b546936310f017557b2fb498b370b");
                var d = obj.GetApi<ICollectionApi>().Value;
                //assert
                Assert.Throws<AggregateException>(() => { SUT.TmdbObjects.Collection.Collections col = d.GetDetailsAsync(id, language).Result; });
            }
        }

        [TestFixture]
        [Category("CollectionApi")]
        public class GetImagesAsync
        {
            [TestCase(296096321)]
            public void IncorrectId_ThrowsException(int id, string language = "en")
            {
                //arrange
                var obj = new SUT.EasyClient("6d4b546936310f017557b2fb498b370b");
                var d = obj.GetApi<ICollectionApi>().Value;
                //assert
                Assert.Throws<AggregateException>(() => { SUT.TmdbObjects.Images.Images ima = d.GetImagesAsync(id, language).Result; });
            }
        }
    }
}
