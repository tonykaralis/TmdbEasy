using NUnit.Framework;
using System;
using TmdbEasy.Configurations;

namespace TmdbEasy.Tests.Unit
{
    [TestFixture]
    public class TmdbEasyClientTests
    {
        [Test]
        public void NullOptions_Throws_ArgumentNullException()
        {
            TmdbEasyOptions options = null;

            Assert.Throws<ArgumentNullException>(() => new TmdbEasyClient(options));
        }
    }
}
