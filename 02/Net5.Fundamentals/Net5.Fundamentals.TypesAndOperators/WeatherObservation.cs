using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Net5.Fundamentals.TypesAndOperators
{
    public class WeatherObservation
    {
        public DateTime RecordeAt { get; init; }
        public decimal TemperatureInCelcius { get; init; }
        public decimal PressureInMillibars { get; init; }
    }
}
