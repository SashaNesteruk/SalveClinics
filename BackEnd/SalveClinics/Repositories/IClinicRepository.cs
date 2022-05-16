using SalveClinics.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SalveClinics.Repositories
{
    public interface IClinicRepository
    {
        IEnumerable<Clinic> GetClinics();
    }
}