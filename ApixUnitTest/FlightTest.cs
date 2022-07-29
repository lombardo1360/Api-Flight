using ApiViajes.Controllers;
using Businnes;
using DataAccess.Modelos;
using Microsoft.AspNetCore.Mvc;

namespace ApixUnitTest
{
    public class FlightTest
    {
        private readonly FlightController _controller;
        private readonly IFlightService _service;

        public FlightTest()
        {
            _service = new FlightService();
            _controller = new FlightController(_service);
        }

        [Fact]
        public void GetFlightOk()
        { 
            var respuesta = new Request();

            respuesta.Origin = "MZL";
            respuesta.Destination = "CTG";
        
            var result = _controller.GetFlight(respuesta);
            Assert.IsType<OkObjectResult>(result);
        }

        [Fact]
        public void GetQuantity()
        {
            var respuesta = new Request();

            respuesta.Origin = "MZL";
            respuesta.Destination = "CTG";

            var result = (OkObjectResult)_controller.GetFlight(respuesta);

            var flight = Assert.IsType<Journey>(result.Value);
           
        }
    }
}