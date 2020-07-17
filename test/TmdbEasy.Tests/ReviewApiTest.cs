using NSubstitute;
using NUnit.Framework;
using System;
using TmdbEasy.Apis;
using TmdbEasy.Interfaces;

namespace TMdbEasy.Tests
{
    [TestFixture]
    [Category("ReviewApi")]
    internal class ReviewApiTest
    {
        private readonly ITmdbEasyClient _subClient;

        public ReviewApiTest()
        {
            _subClient = Substitute.For<ITmdbEasyClient>();
        }

        [TestCase(null)]
        [TestCase("")]
        public void GetDetailsAsync_NullOrEmpty_ThrowsException(string id)
        {
            IReviewApi serviceUnderTest = new ReviewApi(_subClient);            

            Assert.ThrowsAsync<AggregateException>(() => serviceUnderTest.GetReviewDetailsAsync(id));
        }
    }
}
