using SalveClinics.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SalveClinics.Services
{
    public interface IClinicService
    {
        IEnumerable<Clinic> GetClinics();
    }
}
