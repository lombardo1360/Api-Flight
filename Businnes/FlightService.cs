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


            foreach (var flight in flights.Result)
            {
                if (request.Origin == flight.DepartureStation )
                {
                    if (request.Destination == flight.ArrivalStation)
                    {
                        journeyResponse.Origin = request.Origin;
                        journeyResponse.Destination = request.Destination;
                        journeyResponse.Flight.Add(flight);
                        journeyResponse.Price += flight.Price;
                        return journeyResponse;
                    }
                    else
                    {
                        foreach (var flight1 in flights.Result)
                        {
                            if (flight.ArrivalStation == flight1.DepartureStation && request.Destination == flight1.ArrivalStation) 
                            {
                                journeyResponse.Origin = request.Origin;
                                journeyResponse.Destination = request.Destination;
                                journeyResponse.Flight.Add(flight);
                                journeyResponse.Price += flight.Price;
                                journeyResponse.Flight.Add(flight1);
                                journeyResponse.Price += flight1.Price;
                                return journeyResponse;
                            }
                            ;
                        }
                    }
                    
                }
                

            }

            return journeyResponse;

        }
    }
}