using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SalveClinics.Models
{
    public class Clinic
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public IEnumerable<Patient> Patients { get; set; }
    }
}
