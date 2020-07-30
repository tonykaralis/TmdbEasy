﻿using NUnit.Framework;
using System.Threading.Tasks;
using TmdbEasy.Apis;
using TmdbEasy.DTO.Other;
using TmdbEasy.Interfaces;
using TmdbEasy.Tests.Integration.TestFixtures;

namespace TmdbEasy.Tests.Integration
{
    [Category("NetworkApi")]
    internal class NetworkApiTest : TestBaseForV3
    {       
        [TestCase(213)]
        public async Task GetDetailsAsync_ValidId_CustomApiKey_ReturnsValidResult(int id)
        {
            var _requestHandler = new RequestHandler(_clientWithNoApiKey);

            INetworksApi apiUnderTest = new NetworksApi(_requestHandler);

            Network result = await apiUnderTest.GetDetailsAsync(id, _userApiKey);

            Assert.IsNotNull(result);
            Assert.AreEqual(id, result.Id);
        }

        [TestCase(213)]
        public async Task GetDetailsAsync_ValidId_DefaultApiKey_ReturnsValidResult(int id)
        {
            var _requestHandler = new RequestHandler(_clientWithApiKey);

            INetworksApi apiUnderTest = new NetworksApi(_requestHandler);

            Network result = await apiUnderTest.GetDetailsAsync(id);

            Assert.IsNotNull(result);
            Assert.AreEqual(id, result.Id);
        }
    }
}
