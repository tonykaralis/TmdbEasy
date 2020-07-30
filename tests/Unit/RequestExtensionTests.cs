using NUnit.Framework;
using TmdbEasy.Configurations;
using TmdbEasy.Extensions;

namespace TmdbEasy.Tests.Unit
{
    [TestFixture]
    public class RequestExtensionTests
    {
        private readonly string _globalApiKey = "globalApikey";
        private readonly TmdbEasyOptions _defaultOptions;

        public RequestExtensionTests()
        {
            _defaultOptions = new TmdbEasyOptions(_globalApiKey);
        }

        [Test]
        public void AddRegion_ValidValue_AddsCorrectParameter()
        {
            var request = new Request(_defaultOptions);

            request.AddRegion("bla");

            Assert.AreEqual($"?region=bla", request.GetUri());
        }

        [Test]
        public void AddCountry_ValidValue_AddsCorrectParameter()
        {
            var request = new Request(_defaultOptions);

            request.AddCountry("bla");

            Assert.AreEqual($"?country=bla", request.GetUri());
        }


        [Test]
        public void AddPage_ValidValue_AddsCorrectParameter()
        {
            var request = new Request(_defaultOptions);

            request.AddPage(2);

            Assert.AreEqual($"?page=2", request.GetUri());
        }

        [Test]
        public void AddCustomQuery_ValidValue_AddsCorrectParameter()
        {
            var request = new Request(_defaultOptions);

            request.AddCustomQuery("bla");

            Assert.AreEqual($"?query=bla", request.GetUri());
        }


        [Test]
        public void AddStartDate_ValidValue_AddsCorrectParameter()
        {
            var request = new Request(_defaultOptions);

            request.AddStartDate("bla");

            Assert.AreEqual($"?start_date=bla", request.GetUri());
        }

        [Test]
        public void AddEndDate_ValidValue_AddsCorrectParameter()
        {
            var request = new Request(_defaultOptions);

            request.AddEndDate("bla");

            Assert.AreEqual($"?end_date=bla", request.GetUri());
        }

        [Test]
        public void AddIncludeAdult_AddsCorrectParameter()
        {
            var request = new Request(_defaultOptions);

            request.AddIncludeAdult();

            Assert.AreEqual($"?include_adult=true", request.GetUri());
        }


        [Test]
        public void AddYear_ValueGreaterThanZero_AddsCorrectParameter()
        {
            var request = new Request(_defaultOptions);

            request.AddYear(1000);

            Assert.AreEqual($"?year=1000", request.GetUri());
        }

        [Test]
        public void AddYear_ValueLessThanEqualZero_DoesNotAddParameter()
        {
            var request = new Request(_defaultOptions);

            request.AddYear(0);

            Assert.IsEmpty(request.GetUri());
        }

        [Test]
        public void AddPrimaryReleaseYear_ValueGreaterThanZero_AddsCorrectParameter()
        {
            var request = new Request(_defaultOptions);

            request.AddPrimaryReleaseYear(1000);

            Assert.AreEqual($"?primary_release_year=1000", request.GetUri());
        }

        [Test]
        public void AddPrimaryReleaseYear_ValueLessThanZero_DoesNotAddParameter()
        {
            var request = new Request(_defaultOptions);

            request.AddPrimaryReleaseYear(0);

            Assert.IsEmpty(request.GetUri());
        }
    }
}
