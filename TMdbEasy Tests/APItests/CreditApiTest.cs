using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using TMdbEasy.ApiInterfaces;
using SUT = TMdbEasy;

namespace TMdbEasy_Tests.APItests
{
    [Category("CreditApi")]
    internal static class CreditApiTest
    {
        [TestFixture]
        [Category("CreditApi")]
        public class GetDetailsAsync
        {
            [TestCase(296096321)]
            public void IncorrectId_ThrowsException(int id)
            {
                var d = Constants.SecureTestClient.GetApi<ICreditApi>().Value;

                Assert.Throws<AggregateException>(() => { SUT.TmdbObjects.Other.Credits cr = d.GetDetailsAsync(id).Result; });
            }
        }
    }
}
