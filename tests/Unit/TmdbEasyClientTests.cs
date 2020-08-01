using NUnit.Framework;
using System;
using TmdbEasy.Configurations;
using TmdbEasy.Interfaces;

namespace TmdbEasy.Tests.Unit
{
    [TestFixture]
    public class TmdbEasyClientTests
    {
        private readonly IJsonDeserializer _jsonDeserializer;

        public TmdbEasyClientTests()
        {
            _jsonDeserializer = new NewtonSoftDeserializer();
        }

        [Test]
        public void NullOptions_Throws_ArgumentNullException()
        {
            TmdbEasyOptions options = null;

            Assert.Throws<ArgumentNullException>(() => new TmdbEasyClient(_jsonDeserializer, options));
        }
    }
}
