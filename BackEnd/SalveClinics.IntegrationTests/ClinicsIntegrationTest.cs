using AutoFixture;
using Newtonsoft.Json;
using SalveClinics.Models;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using Xunit;

namespace SalveClinics.IntegrationTests
{
    [Collection("Clinic collection")]
    public class ClinicsIntegrationTest
    {

        private readonly Fixture _fixture;
        private readonly HttpClient _client;

        public ClinicsIntegrationTest(TestFixture testFixture)
        {
            _client = testFixture.Client;
            _fixture = testFixture.Fixture;
        }

        [Fact]
        public async void ListClinicsReturnsResults()
        {
            // Arrange

            // Act
            var response = await _client.GetAsync("/clinics");

            // Assert
            var responseAsString = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<List<Clinic>>(responseAsString);

            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            Assert.NotNull(result);
            Assert.Equal(2, result.Count);
        }
    }
}
