using AutoFixture;
using Moq;
using SalveClinics.Models;
using SalveClinics.Repositories;
using SalveClinics.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace SalveClinics.UnitTests
{
    public class PatientServiceUnitTest
    {
        private PatientService _sut;
        private Mock<IPatientRepository> _patientRepository;

        private readonly Fixture _fixture;

        public PatientServiceUnitTest()
        {
            _fixture = new Fixture();
            _patientRepository = new Mock<IPatientRepository>();
            _sut = new PatientService(_patientRepository.Object);
        }

        [Fact]
        public void GetPatientsByClinicIdReturnsResult()
        {
            // Arrange
            var clinic = _fixture.Create<Clinic>();
            var patients = _fixture.Build<Patient>()
                                    .With(x => x.ClinicId, clinic.Id)
                                   .CreateMany(100);

            _patientRepository.Setup(x => x.GetPatientsByCLinicId(clinic.Id)).Returns(patients);

            // Act 
            var result = _sut.GetPatientsByCLinicId(clinic.Id);

            // Assert
            Assert.True(result.Any());
            Assert.Equal(result.First().ClinicId, clinic.Id);
            _patientRepository.Verify(x => x.GetPatientsByCLinicId(clinic.Id), Times.Once);

        }

        [Fact]
        public void GetPatientsByClinicIdThrowsException_GivenNonExistentClinicId()
        {
            // Arrange
            var clinic = _fixture.Build<Clinic>()
                                 .With(c => c.Id, 1)
                                 .Create();

            _patientRepository.Setup(x => x.GetPatientsByCLinicId(It.IsAny<int>())).Returns(Array.Empty<Patient>());

            // Act and Assert
            var ex = Assert.Throws<NullReferenceException>(() => _sut.GetPatientsByCLinicId(2));
            Assert.Contains($"Patients of Clinic with id {2} not found", ex.Message);
            _patientRepository.Verify(x => x.GetPatientsByCLinicId(It.IsAny<int>()), Times.Once);

        }
    }
}
