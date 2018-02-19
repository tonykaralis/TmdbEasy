using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SUT = TMdbEasy;
using NUnit.Framework;

namespace TMdbEasy_Tests
{
    class EasyClientTest
    {
        [TestFixture]
        [Category("Initialization")]
        public class InitializeTest
        {
            [TestCase(null)]
            [TestCase("")]
            [TestCase(" ")]
            public void EmptyApiKey_ReturnsArgumentException(string _apikey)
            {
                //Assert
                Assert.Throws<ArgumentException>(() => new SUT.EasyClient(_apikey));
            }

            [TestCase("6d4b546936310f017557b2fb498b370b")]
            public void SecuredParam_AssignsSecureUrl(string _apikey, bool secure = true)
            {
                //Arrange
                var obj = new SUT.EasyClient(_apikey, secure);

                //Assert
                Assert.AreEqual(obj.Secured, true);
                Assert.AreEqual(obj.Url, "https://api.themoviedb.org/");
            }

            [TestCase("123124", false)]
            public void SecuredParam_AssignsUnsecureUrl(string _apikey, bool secure = true)
            {
                //Arrange
                var obj = new SUT.EasyClient(_apikey, secure);

                //Assert
                Assert.AreEqual(obj.Secured, false);
                Assert.AreEqual(obj.Url, "http://api.themoviedb.org/");
          }
        }
    }
}