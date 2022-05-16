using AutoFixture;
using Moq;
using SalveClinics.Models;
using SalveClinics.Repositories;
using SalveClinics.Services;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace SalveClinics.UnitTests
{
    public class ClinicServiceUnitTests
    {
        private ClinicService _sut;
        private Mock<IClinicRepository> _clinicRepository;

        private readonly Fixture _fixture;

        public ClinicServiceUnitTests()
        {
            _fixture = new Fixture();
            _clinicRepository = new Mock<IClinicRepository>();
            _sut = new ClinicService(_clinicRepository.Object);
        }

        [Fact]
        public void ListClinicsReturnsResults()
        {
            // Arrange
            var clinics = _fixture.CreateMany<Clinic>();

            _clinicRepository.Setup(x => x.GetClinics()).Returns(clinics);

            // Act 
            var result = _sut.GetClinics();

            // Assert
            Assert.Equal(result, clinics);
            _clinicRepository.Verify(x => x.GetClinics(), Times.Once);

        }
    }
}
