using Newtonsoft.Json;
using NUnit.Framework;
using System;
using TmdbEasy.Data.Reviews;
using TmdbEasy.Interfaces;

namespace TmdbEasy.Tests
{
    [TestFixture]
    internal class NewtonSoftDeserializerTests
    {
        private readonly IJsonDeserializer _serializer;

        public NewtonSoftDeserializerTests()
        {
            _serializer = new NewtonSoftDeserializer();
        }

        [Test]
        public void DeserializeTo_ValidJson_ResultIsNotNull()
        {
            Review testReview = new Review()
            {
                Iso_639_1 = "iso1",
                Author = "Testauthor",
                Content = "test content",
                Id = "test id",
                Media_id = 1,
                Media_title = "test title",
                Media_type = "test type",
                Url = "testurl"
            };

            string jsonData = JsonConvert.SerializeObject(testReview);

            var testResult = _serializer.DeserializeTo<Review>(jsonData);

            Assert.IsNotNull(testResult);
        }

        [TestCase(null)]
        [TestCase("")]
        [TestCase(" ")]
        public void DeserializeTo_NullOrEmptyJson_Throws_ArgumentNullException(string testData)
        {
            Assert.Throws<ArgumentNullException>(() => _serializer.DeserializeTo<Review>(testData));
        }
    }
}
