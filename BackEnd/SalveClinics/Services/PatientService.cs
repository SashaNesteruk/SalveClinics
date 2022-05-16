using SalveClinics.Models;
using SalveClinics.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SalveClinics.Services
{
    public class PatientService : IPatientService
    {
        private IPatientRepository _patientRepository;

        public PatientService(IPatientRepository patientRepository)
        {
            _patientRepository = patientRepository;
        }

        public IEnumerable<Patient> GetPatientsByCLinicId(int id)
        {
            var patients = _patientRepository.GetPatientsByCLinicId(id);

            if (!patients.Any())
            {
                throw new NullReferenceException($"Patients of Clinic with id {id} not found");
            }

            return patients;
        }
    }
}
