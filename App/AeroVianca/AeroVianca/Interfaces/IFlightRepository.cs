using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace AeroVianca.Model
{
    public interface IFlightRepository
    {
        string Add(FlightModel FlightModel);
        FlightModel GetByCode(string FlightCode);
        ObservableCollection<FlightModel> GetAllFlights();
        ObservableCollection<AirlineModel> GetAllAirlines();
        ObservableCollection<CityModel> GetAllCities();

    }
}
