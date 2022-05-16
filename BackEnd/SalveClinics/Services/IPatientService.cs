using SalveClinics.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SalveClinics.Services
{
    public interface IPatientService
    {
        IEnumerable<Patient> GetPatientsByCLinicId(int id);
    }
}
