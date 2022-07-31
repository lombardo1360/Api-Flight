using DataAccess.Modelos;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace DataAccess
{
    public class FlightContext
    {
        public async Task<List<Flight>> GetFlightAsync()
        {

            string url = "https://recruiting-api.newshore.es/api/flights/1";

            using(var client = new HttpClient())
            {
                var httpResponse = await client.GetAsync(url);
                try
                {
                    if (httpResponse.IsSuccessStatusCode)
                    {
                        var content = await httpResponse.Content.ReadAsStringAsync();
                        List<Flight> flights = JsonConvert.DeserializeObject<List<Flight>>(content);
                        return flights;

                    }
                }
                catch (Exception ex)
                {

                    throw new Exception("Ocurrio un error en la consulta");
                }

               
            }

            return null;
        }

      
    }

}
