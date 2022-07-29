using Businnes;
using DataAccess.Modelos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text.Json;

namespace ApiViajes.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FlightController : ControllerBase
    {

        private IFlightService _flithgService;

        public FlightController(IFlightService flightService)
        {
            _flithgService = flightService;
        }


        [HttpPost]
        public IActionResult GetFlight(Request request)
        {
            var response = _flithgService.GetJourney(request);

            if (response == null)
            {
                return NotFound();
            }

            return Ok(response);
        }
    }
}
