using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace TmdbEasy.Tests
{
    [TestFixture]
    public class RequestTests
    {
        private readonly string _globalApiKey = "globalApikey";
        private readonly string _defaultLanguage = "en";
        private readonly string _baseUrl = "https://baseurl";

        [Test]
        public void RequestConstructor_ValidParams_Creates_NonNullInstance()
        {
            var request = new Request(_baseUrl, _globalApiKey, _defaultLanguage);

            Assert.IsNotNull(request);
        }

        [Test]
        public void RequestConstructor_InValidParams_Creates_NonNullInstance()
        {
            var request = new Request(null, null, null);

            Assert.IsNotNull(request);
        }

        [Test]
        public void AddUrlSegment_ValidSegment_AddsSegment()
        {
            var request = new Request(null, null, null);

            string segment = "testSegment";

            request.AddUrlSegment(segment);

            Assert.AreEqual($"{request.GetUri()}", $"/{segment}");
        }

        [Test]
        [TestCase(null)]
        [TestCase("")]
        public void AddUrlSegment_NullOrEmptyParams_DoesNotAddSegment(string segment)
        {
            var request = new Request(null, null, null);

            request.AddUrlSegment(segment);

            Assert.IsEmpty(request.GetUri());
        }

        [Test]
        public void AddParameter_NonNUllOrEmptyValues_AddsParameter()
        {
            var request = new Request(null, null, null);

            string parameterKey = "testParameterKey";
            string parameterValue = "testParameterValue";

            request.AddParameter(parameterKey, parameterValue);

            Assert.AreEqual($"{request.GetUri()}", $"?{parameterKey}={parameterValue}");
        }

        [Test]
        [TestCase(null)]
        [TestCase("")]
        public void AddParameter_NullOrEmptyKey_DoesNotAddParameter(string key)
        {
            var request = new Request(null, null, null);

            string parameterValue = "testParameterValue";

            request.AddParameter(key, parameterValue);

            Assert.IsEmpty(request.GetUri());
        }

        [Test]
        [TestCase(null)]
        [TestCase("")]
        public void AddParameter_NullOrEmptyValue_DoesNotAddParameter(string value)
        {
            var request = new Request(null, null, null);

            string parameterKey = "testParameterKey";

            request.AddParameter(parameterKey, value);

            Assert.IsEmpty(request.GetUri());
        }

        [Test]
        public void AddParameter_FirstParameter_AppendsCorrectPrefix()
        {
            var request = new Request(null, null, null);

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
            var request = new Request(null, null, null);

            string parameterKey1 = "key1";
            string parameterValue1 = "value1";
            string parameterKey2 = "testParameterKey2";
            string parameterValue2 = "testParameterValue2";

            request.AddParameter(parameterKey1, parameterValue1);
            request.AddParameter(parameterKey2, parameterValue2);

            int expectedPositionOfPrefix = 12;

            Assert.AreEqual($"{request.GetUri()}", $"?{parameterKey1}={parameterValue1}&{parameterKey2}={parameterValue2}");
            Assert.AreEqual(expectedPositionOfPrefix, request.GetUri().IndexOf("&"));
        }

        [Test]
        public void AddApiKey_GlobalApiKeySet_UserApiKeyUsed_SetsUserApiKey()
        {
            var request = new Request(_baseUrl, _globalApiKey, _defaultLanguage);

            string userApiKey = "userkey";

            request.AddApiKey(userApiKey);

            Assert.IsTrue(request.GetUri().Contains($"?api_key={userApiKey}"));
        }

        [Test]
        public void AddApiKey_GlobalApiKeySet_NoUserApiKeyProvided_SetsGlobalApiKey()
        {
            var request = new Request(_baseUrl, _globalApiKey, _defaultLanguage);

            request.AddApiKey();

            Assert.IsTrue(request.GetUri().Contains($"?api_key={_globalApiKey}"));
        }

        [Test]
        public void AddLanguage_DefaultLanguageSet_LocalLanguageUsed_SetsLocalLanguage()
        {
            var request = new Request(_baseUrl, _globalApiKey, _defaultLanguage);

            string localLanguage = "localLang";

            request.AddLanguage(localLanguage);

            Assert.IsTrue(request.GetUri().Contains($"?language={localLanguage}"));
        }

        [Test]
        public void AddLanguage_DefaultLanguageSet_NoLocalLanguageUsed_SetsDefaultLanguage()
        {
            var request = new Request(_baseUrl, _globalApiKey, _defaultLanguage);
            
            request.AddLanguage(); ;

            Assert.IsTrue(request.GetUri().Contains($"?language={_defaultLanguage}"));
        }
    }
}
