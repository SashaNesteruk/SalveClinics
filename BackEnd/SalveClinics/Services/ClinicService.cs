using SalveClinics.Models;
using SalveClinics.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SalveClinics.Services
{
    public class ClinicService : IClinicService
    {
        private IClinicRepository _clinicRepository;

        public ClinicService(IClinicRepository clinicRepository)
        {
            _clinicRepository = clinicRepository;
        }

        public IEnumerable<Clinic> GetClinics()
        {
            return _clinicRepository.GetClinics();
        }
    }
}
