using System;
using NUnit.Framework;
using TmdbEasy.Configurations;

namespace TmdbEasy.Tests.Unit
{
    [TestFixture]
    public class RequestTests
    {
        private readonly string _globalApiKey = "globalApikey";
        private readonly string _defaultLanguage = "en";

        [Test]
        public void RequestConstructor_ValidParams_Creates_NonNullInstance()
        {
            var options = new TmdbEasyOptions(_globalApiKey);

            var request = new Request(options);

            Assert.IsNotNull(request);
        }

        [Test]
        public void RequestConstructor_InValidParams_ThrowsArgumentNullException()
        {
            var exception = Assert.Throws<ArgumentNullException>(() => new Request(null));
            Assert.That(exception.Message, Is.EqualTo("Value cannot be null. (Parameter 'options')"));
        }

        [Test]
        public void AddUrlSegment_ValidSegment_AddsSegment()
        {
            var request = new Request(GetPlaceholderOptions());

            string segment = "testSegment";

            request.AddUrlSegment(segment);

            Assert.AreEqual(segment, request.GetUri());
        }

        [Test]
        public void AddUrlSegment_WhenCalledSecondTime_ShouldPrefixSecondSegmentWithSlash()
        {
            var request = new Request(GetPlaceholderOptions());

            request.AddUrlSegment("users");
            request.AddUrlSegment("6");

            Assert.AreEqual("users/6", request.GetUri());
        }

        [Test]
        [TestCase(null)]
        [TestCase("")]
        public void AddUrlSegment_NullOrEmptyParams_DoesNotAddSegment(string segment)
        {
            var request = new Request(GetPlaceholderOptions());

            request.AddUrlSegment(segment);

            Assert.IsEmpty(request.GetUri());
        }

        [Test]
        public void AddParameter_NonNUllOrEmptyValues_AddsParameter()
        {
            var request = new Request(GetPlaceholderOptions());

            string parameterKey = "testParameterKey";
            string parameterValue = "testParameterValue";

            request.AddParameter(parameterKey, parameterValue);

            Assert.AreEqual(request.GetUri(), $"?{parameterKey}={parameterValue}");
        }

        [Test]
        [TestCase(null)]
        [TestCase("")]
        public void AddParameter_NullOrEmptyKey_DoesNotAddParameter(string key)
        {
            var request = new Request(GetPlaceholderOptions());

            string parameterValue = "testParameterValue";

            request.AddParameter(key, parameterValue);

            Assert.IsEmpty(request.GetUri());
        }

        [Test]
        [TestCase(null)]
        [TestCase("")]
        public void AddParameter_NullOrEmptyValue_DoesNotAddParameter(string value)
        {
            var request = new Request(GetPlaceholderOptions());

            string parameterKey = "testParameterKey";

            request.AddParameter(parameterKey, value);

            Assert.IsEmpty(request.GetUri());
        }

        [Test]
        public void AddParameter_FirstParameter_AppendsCorrectPrefix()
        {
            var request = new Request(GetPlaceholderOptions());

            string parameterKey = "testParameterKey";
            string parameterValue = "testParameterValue";

            request.AddParameter(parameterKey, parameterValue);

            int expectedPositionOfPrefix = 0;

            Assert.AreEqual(expectedPositionOfPrefix, request.GetUri().IndexOf("?"));
            Assert.AreEqual("?", request.GetUri().Substring(0, 1));
        }

        [Test]
        public void AddParameter_SecondParameter_AppendsCorrectPrefix()
        {
            var request = new Request(GetPlaceholderOptions());

            string parameterKey1 = "key1";
            string parameterValue1 = "value1";
            string parameterKey2 = "testParameterKey2";
            string parameterValue2 = "testParameterValue2";

            request.AddParameter(parameterKey1, parameterValue1);
            request.AddParameter(parameterKey2, parameterValue2);

            int expectedPositionOfPrefix = 12;

            Assert.AreEqual(request.GetUri(), $"?{parameterKey1}={parameterValue1}&{parameterKey2}={parameterValue2}");
            Assert.AreEqual(expectedPositionOfPrefix, request.GetUri().IndexOf("&"));
        }

        [Test]
        public void AddApiKey_GlobalApiKeySet_UserApiKeyUsed_SetsUserApiKey()
        {
            var options = new TmdbEasyOptions(_globalApiKey);
            var request = new Request(options);

            string userApiKey = "userkey";

            request.AddApiKey(userApiKey);

            Assert.IsTrue(request.GetUri().Contains($"?api_key={userApiKey}"));
        }

        [Test]
        public void AddApiKey_GlobalApiKeySet_NoUserApiKeyProvided_SetsGlobalApiKey()
        {
            var options = new TmdbEasyOptions(_globalApiKey);
            var request = new Request(options);

            request.AddApiKey();

            Assert.IsTrue(request.GetUri().Contains($"?api_key={_globalApiKey}"));
        }

        [Test]
        public void AddApiKey_GlobalApiKeyUnset_NoUserApiKeyProvided_ThrowsArgumentNullException()
        {
            var options = new TmdbEasyOptions();
            var request = new Request(options);

            var exception = Assert.Throws<ArgumentNullException>(() => request.AddApiKey());
            Assert.That(exception.Message, Is.EqualTo("No per-request nor global API key set! (Parameter 'apiKey')"));
        }

        [Test]
        public void AddLanguage_DefaultLanguageSet_LocalLanguageUsed_SetsLocalLanguage()
        {
            var options = new TmdbEasyOptions("apiKey", useSsl: true, _defaultLanguage);
            var request = new Request(options);

            string localLanguage = "localLang";

            request.AddLanguage(localLanguage);

            Assert.IsTrue(request.GetUri().Contains($"?language={localLanguage}"));
        }

        [Test]
        public void AddLanguage_DefaultLanguageSet_NoLocalLanguageUsed_SetsDefaultLanguage()
        {
            var options = new TmdbEasyOptions("apiKey", useSsl: true, _defaultLanguage);
            var request = new Request(options);

            request.AddLanguage(); ;

            Assert.IsTrue(request.GetUri().Contains($"?language={_defaultLanguage}"));
        }

        private static TmdbEasyOptions GetPlaceholderOptions()
        {
            return new TmdbEasyOptions(apiKey: "secret");
        }
    }
}
