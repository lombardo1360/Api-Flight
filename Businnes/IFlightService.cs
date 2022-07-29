using DataAccess.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Businnes
{
    public interface IFlightService
    {
        public Journey GetJourney(Request request);
    }
}
