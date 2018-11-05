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
    [Category("ReviewApi")]
    internal static class ReviewApiTest
    {
        [TestFixture]
        [Category("ReviewApi")]
        public class GetDetailsAsync
        {
            [TestCase(296096321)]
            public void IncorrectId_ThrowsException(int id)
            {
                var d = Constants.SecureTestClient.GetApi<IReviewApi>().Value;

                Assert.Throws<AggregateException>(() => { SUT.TmdbObjects.Other.Reviews cr = d.GetDetailsAsync(id).Result; });
            }
        }
    }
}
