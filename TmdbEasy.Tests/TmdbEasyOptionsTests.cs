using NUnit.Framework;
using TmdbEasy.Configurations;

namespace TmdbEasy.Tests
{
    [TestFixture]
    public class TmdbEasyOptionsTests
    {
        [Test]
        public void Ssl_Off_SetsCorrectVersionOfUrl_NoSsl()
        {
            var options = new TmdbEasyOptions()
            {
                UseSsl = false
            };

            string url = options.GetBaseUrl();

            Assert.IsTrue(url.StartsWith("http://"));
        }

        [Test]
        public void Ssl_On_SetsCorrectVersionOfUrl_WithSsl()
        {
            var options = new TmdbEasyOptions()
            {
                UseSsl = true
            };

            string url = options.GetBaseUrl();

            Assert.IsTrue(url.StartsWith("https://"));
        }
    }
}
