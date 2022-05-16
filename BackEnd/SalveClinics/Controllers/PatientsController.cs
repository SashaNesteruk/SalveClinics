using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SalveClinics.Models;
using SalveClinics.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SalveClinics.Controllers
{
    [Route("ClinicPatients")]
    [ApiController]
    public class PatientsController : ControllerBase
    {
        private readonly ILogger<PatientsController> _logger;
        private readonly IPatientService _patientService;

        public PatientsController(IPatientService patientService, ILogger<PatientsController> logger)
        {
            _patientService = patientService;
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<Patient> GetClinicPatients([FromQuery]int clinicId)
        {
            return _patientService.GetPatientsByCLinicId(clinicId);
        }
    }
}
