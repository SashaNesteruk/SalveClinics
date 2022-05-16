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
    [Route("clinics")]
    [ApiController]
    public class ClinicsController : ControllerBase
    {
        private readonly ILogger<ClinicsController> _logger;
        private readonly IClinicService _clinicService;

        public ClinicsController(IClinicService clinicService, ILogger<ClinicsController> logger)
        {
            _clinicService = clinicService;
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<Clinic> ListClinics()
        {
            return _clinicService.GetClinics();
        }
    }
}
