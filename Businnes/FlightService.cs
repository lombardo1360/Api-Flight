using DataAccess;
using DataAccess.Modelos;

namespace Businnes
{
    public class FlightService : IFlightService
    {

        public Journey GetJourney(Request request)
        {
            Journey journeyResponse = new Journey();
            FlightContext flightContext = new FlightContext();
            var flights = flightContext.GetFlightAsync();

            //Hace unna verificacion si hay vuelos directos 
            foreach (var flight in flights.Result)
            {
                if (request.Origin == flight.DepartureStation && request.Destination == flight.ArrivalStation)
                {

                    journeyResponse.Origin = request.Origin;
                    journeyResponse.Destination = request.Destination;
                    journeyResponse.Flight.Add(flight);
                    journeyResponse.Price += flight.Price;
                    return journeyResponse;
                }
            }  
            //Verifica si hay vuelos con escala en la ruta de origen y destino requerido 
            foreach (var flight1 in flights.Result)
             {
                if (request.Origin == flight1.DepartureStation && request.Destination != flight1.ArrivalStation)
                {
                    foreach (var flight2 in flights.Result)

                    {
                        if (flight1.ArrivalStation == flight2.DepartureStation && request.Destination == flight2.ArrivalStation)
                        {
                            journeyResponse.Origin = request.Origin;
                            journeyResponse.Destination = request.Destination;
                            journeyResponse.Flight.Add(flight1);
                            journeyResponse.Price += flight1.Price;
                            journeyResponse.Flight.Add(flight2);
                            journeyResponse.Price += flight2.Price;
                            return journeyResponse;
                        }
                    }

                }
             }
            
            return journeyResponse;

        }
    }
}