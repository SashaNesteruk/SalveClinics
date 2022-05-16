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
    public class PatientsIntegrationTest
    {

        private readonly Fixture _fixture;
        private readonly HttpClient _client;

        public PatientsIntegrationTest(TestFixture testFixture)
        {
            _client = testFixture.Client;
            _fixture = testFixture.Fixture;
        }

        [Fact]
        public async void GetClinicOnePatients_GivenValidId()
        {
            // Arrange

            // Act
            var response = await _client.GetAsync("ClinicPatients?clinicId=1");

            // Assert
            var responseAsString = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<List<Patient>>(responseAsString);

            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            Assert.NotNull(result);
            Assert.Equal(200, result.Count);
        }

        [Fact]
        public async void GetClinicOnePatients_GivenInValidId()
        {
            // Arrange

            // Act
            var response = await _client.GetAsync("ClinicPatients?clinicId=5");

            // Assert

            Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
        }
    }
}
