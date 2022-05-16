using Microsoft.EntityFrameworkCore;
using SalveClinics.Context;
using SalveClinics.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SalveClinics.Repositories
{
    public class ClinicRepository : IClinicRepository
    {
        private ApplicationContext _context;
        public ClinicRepository(ApplicationContext context)
        {
            _context = context;
        }

        public IEnumerable<Clinic> GetClinics()
        {
            return _context.Clinics.ToList();
        }
    }
}
