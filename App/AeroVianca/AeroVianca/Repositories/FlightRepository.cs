using System.Net;
using AeroVianca.Model;
using System.Data.SqlClient;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;
using System.Collections.ObjectModel;

namespace AeroVianca.Repositories
{
    public class FlightRepository : RepositoryBase, IFlightRepository
    {
        public string Add(FlightModel FlightModel)
        {
            try
            {
                string queryString = $"EXEC sp_InsertVuelo '{FlightModel.CiudadOrigen}'  , " +
                                                        $" '{FlightModel.CiudadDestino}' , " +
                                                        $" '{FlightModel.Fecha}'         , " +
                                                        $" '{FlightModel.HoraSalida}'    , " +
                                                        $" '{FlightModel.HoraLlegada}'   , " +
                                                        $" '{FlightModel.NumeroVuelo}'   , " +
                                                        $" '{FlightModel.Aerolinea}'     , " +
                                                        $" '{FlightModel.EstadoVuelo}'   ";

                using var connection = GetConnection();
                using var command = new SqlCommand();
                connection.Open();
                command.Connection = connection;
                command.CommandText = queryString;

                var execute = command.ExecuteNonQuery();
                return string.Empty;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        

        public FlightModel? GetByCode(string FlightCode)
        {
            try
            {
                string queryString = $"select * from [v_Vuelos] where NumeroVuelo = '{FlightCode}' ";
                return ExecuteQueryFlight(queryString);
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        private FlightModel? ExecuteQueryFlight(string pQueryString)
        {
            try
            {
                using var connection = GetConnection();
                using var command = new SqlCommand();
                connection.Open();
                command.Connection = connection;
                command.CommandText = pQueryString;

                using var reader = command.ExecuteReader();
                FlightModel? flight = null;
                if (reader.Read())
                {
                    flight = new FlightModel()
                    {
                        CiudadOrigen    = reader.GetString(0),
                        CiudadDestino   = reader.GetString(1),
                        Fecha           = reader.GetDateTime(2).ToString(),
                        HoraSalida      = reader.GetTimeSpan(3).ToString(),
                        HoraLlegada     = reader.GetTimeSpan(4).ToString(),
                        NumeroVuelo     = reader.GetString(5),
                        Aerolinea       = reader.GetString(6),
                        EstadoVuelo     = reader.GetString(7)
                    };
                }
                return flight;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        private List<FlightModel> ExecuteQueryFlights(string pQueryString)
        {

            try
            {
                var flights = new List<FlightModel>();
                using var connection = GetConnection();
                using var command = new SqlCommand(pQueryString, connection);
                connection.Open();
                using var reader = command.ExecuteReader();
                while (reader.Read())
                {
                    var flight = new FlightModel
                    {
                        CiudadOrigen    = reader.GetString(0),
                        CiudadDestino   = reader.GetString(1),
                        Fecha           = reader.GetString(2),
                        HoraSalida      = reader.GetString(3),
                        HoraLlegada     = reader.GetString(4),
                        NumeroVuelo     = reader.GetString(5),
                        Aerolinea       = reader.GetString(6),
                        EstadoVuelo     = reader.GetString(7)
                    };

                    flights.Add(flight);
                }
                return flights;
            }
            catch (Exception ex)
            {
                return null;
            }
        }


        public ObservableCollection<AirlineModel> GetAllAirlines()
        {
            return GetAllRecords("Aerolineas", reader => new AirlineModel
            {
                Id = reader.GetString(0),
                Name = reader.GetString(1)
            });
        }

        public ObservableCollection<CityModel> GetAllCities()
        {
            return GetAllRecords("Ciudades", reader => new CityModel
            {
                Id = reader.GetString(0),
                Name = reader.GetString(1)
            });
        }

        public ObservableCollection<FlightModel> GetAllFlights()
        {
            return GetAllRecords("v_vuelos", reader => new FlightModel
            {
                CiudadOrigen    = reader.GetString(0),
                CiudadDestino   = reader.GetString(1),
                Fecha           = reader.GetDateTime(2).ToString(),
                HoraSalida      = reader.GetTimeSpan(3).ToString(),
                HoraLlegada     = reader.GetTimeSpan(4).ToString(),
                NumeroVuelo     = reader.GetString(5),
                Aerolinea       = reader.GetString(6),
                EstadoVuelo     = reader.GetString(7)
            });
        }

        public ObservableCollection<T> GetAllRecords<T>(string tableName, Func<SqlDataReader, T> mapFunction)
        {
            try
            {
                string queryString = $"SELECT * FROM {tableName}";

                ObservableCollection<T> records = new ObservableCollection<T>();
                using var connection = GetConnection();
                using var command = new SqlCommand(queryString, connection);
                connection.Open();
                using var reader = command.ExecuteReader();
                while (reader.Read())
                {
                    var record = mapFunction(reader);
                    records.Add(record);
                }
                return records;
            }
            catch (Exception ex)
            {
                return [];
            }
        }

    }
}
