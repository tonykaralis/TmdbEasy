﻿using NUnit.Framework;
using System;
using TmdbEasy.Configurations;
using TmdbEasy.Constants;
using TmdbEasy.Interfaces;

namespace TmdbEasy.Tests
{
    [TestFixture]
    public class V3TmdbEasyClientTests
    {
        private readonly IJsonDeserializer _jsonDeserializer;

        public V3TmdbEasyClientTests()
        {
            _jsonDeserializer = new NewtonSoftDeserializer();
        }

        [Test]
        public void NullOptions_Throws_ArgumentNullException()
        {
            TmdbEasyOptions options = null;

            Assert.Throws<ArgumentNullException>(() => new TmdbEasyClientv3(_jsonDeserializer, options));
        }

        [Test]
        public void OptionsWithSsl_Off_SetsCorrectVersionOfUrl_NoSsl()
        {
            var options = new TmdbEasyOptions()
            {
                UseSsl = false
            };

            var client = new TmdbEasyClientv3(_jsonDeserializer, options);

            Assert.AreEqual(UrlConstants.TmdbUrl3, client.GetBaseUrl());
        }

        [Test]
        public void OptionsWithSsl_On_SetsCorrectVersionOfUrl_WithSsl()
        {
            var options = new TmdbEasyOptions()
            {
                UseSsl = true
            };

            var client = new TmdbEasyClientv3(_jsonDeserializer, options);

            Assert.AreEqual(UrlConstants.TmdbUrl3Ssl, client.GetBaseUrl());
        }

        [Test]
        [TestCase("asdjhfbakjsdhb")]
        [TestCase("")]
        [TestCase(null)]
        public void OptionsWithApiKey_SetsAndGetsApiKey(string apikey)
        {
            var options = new TmdbEasyOptions()
            {
                ApiKey = apikey
            };

            var client = new TmdbEasyClientv3(_jsonDeserializer, options);

            Assert.AreEqual(options.ApiKey, client.GetApiKey());
        }

        [Test]
        [TestCase("en")]
        [TestCase("")]
        [TestCase(null)]
        public void OptionsWithDefaultLanguage_SetsAndGetsLanguage(string language)
        {
            var options = new TmdbEasyOptions()
            {
                DefaultLanguage = language
            };

            var client = new TmdbEasyClientv3(_jsonDeserializer, options);

            Assert.AreEqual(options.DefaultLanguage, client.GetDefaultLanguage());
        }
    }
}
