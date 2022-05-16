using SalveClinics.Context;
using SalveClinics.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SalveClinics.Repositories
{
    public class PatientRepository : IPatientRepository
    {
        private ApplicationContext _context;

        public PatientRepository(ApplicationContext context)
        {
            _context = context;
        }

        public IEnumerable<Patient> GetPatientsByCLinicId(int id)
        {
            return _context.Patients.Where(x => x.ClinicId == id).ToList();
        }
    }
}
