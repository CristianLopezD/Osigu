using AeroVianca.Model;
using System.Globalization;
using System.Windows.Input;
using AeroVianca.Repositories;
using System.Collections.ObjectModel;

namespace AeroVianca.ViewModel
{
    public class PlanningViewModel : ViewModelBase
    {
        private readonly IFlightRepository fligthRepository;

        private ObservableCollection<AirlineModel>  _airlines;
        private ObservableCollection<CityModel>     _cities;
        
        private AirlineModel _sairline;
        private CityModel    _scityOrg;
        private CityModel    _scityDest;

        private FlightModel _flightModel = new();

        private string _resultMessage;
        private string _validFormMessage;


        public ObservableCollection<AirlineModel> Airlines
        {
            get { return _airlines; }
            set { _airlines = value; }
        }
        public ObservableCollection<CityModel> Cities
        {
            get { return _cities; }
            set { _cities = value; }
        }

        public AirlineModel? sAirline
        {
            get { return _sairline; }
            set
            {
                _sairline = value;
                OnPropertyChanged(nameof(_sairline));
            }
        }

        public CityModel? sCityOrg
        {
            get { return _scityOrg; }
            set 
            { 
                _scityOrg = value;
                OnPropertyChanged(nameof(_scityOrg));
            }
        }
        public CityModel? sCityDest
        {
            get { return _scityDest; }
            set
            {
                _scityDest = value;
                OnPropertyChanged(nameof(_scityDest));
            }
        }

        public FlightModel FlightModel
        {
            get { return _flightModel; }
            set 
            { 
                _flightModel = value;
                OnPropertyChanged(nameof(FlightModel));
            }
        }


        public string ResultMessage
        {
            get
            {
                return _resultMessage;
            }

            set
            {
                _resultMessage = value;
                OnPropertyChanged(nameof(ResultMessage));
            }
        }

        public string ValidFormMessage
        {
            get
            {
                return _validFormMessage;
            }

            set
            {
                _validFormMessage = value;
                OnPropertyChanged(nameof(ValidFormMessage));
            }
        }

        //-> Commands
        public ICommand createPlanningCommand { get; }
        public ICommand AddUserCommand { get; }

        //Constructor
        public PlanningViewModel()
        {
            fligthRepository = new FlightRepository();

            Airlines = fligthRepository.GetAllAirlines();
            Cities   = fligthRepository.GetAllCities();

            createPlanningCommand = new ViewModelCommand(ExecuteCreatePlanningCommand, CanExecuteCreatePlanningCommand);
        }

        private bool CanExecuteCreatePlanningCommand(object obj)
        {
            if (FlightModel.Fecha == null || FlightModel.NumeroVuelo == null || sCityOrg == null || sCityDest == null || sAirline == null) return false;

            if (sCityDest?.Equals(sCityOrg) ?? false && sCityOrg != null || sCityDest != null) 
            {
                ValidFormMessage = "** Error Ciudad Destino y origen no pueden ser iguales";
                return false;
            }
            ValidFormMessage = string.Empty;
            return true;
        }

        private void ExecuteCreatePlanningCommand(object obj)
        {
            try
            {
                string fechaString;

                if (!IsValidDateFormat(FlightModel.Fecha, "MM/dd/yyyy"))
                {
                    DateTime fechaHora = DateTime.ParseExact(FlightModel.Fecha, "dddd, d 'de' MMMM 'de' yyyy h:mm:ss tt", new CultureInfo("es-ES"));
                    fechaString = fechaHora.ToString("MM/dd/yyyy");
                }
                else
                {
                    fechaString = FlightModel.Fecha;
                }

                FlightModel.NumeroVuelo = $"V{FlightModel.NumeroVuelo}";
                FlightModel.EstadoVuelo = "P";
                FlightModel.CiudadOrigen = sCityOrg.Id;
                FlightModel.CiudadDestino = sCityDest.Id;
                FlightModel.Aerolinea = sAirline.Id;
                FlightModel.Fecha = fechaString;

                string isValidUser = fligthRepository.Add(FlightModel);
                ResultMessage = isValidUser.Equals(string.Empty) ? $"Vuelo: {FlightModel.NumeroVuelo} Creado Correctamente" : $"** {isValidUser}";
                CleanData();
            }
            catch (Exception ex)
            {
                ResultMessage = $"** ERROR: {ex.Message}";
                CleanData();
            }
        }

        private void CleanData()
        {
            FlightModel = new();
            sCityOrg    = null;
            sCityDest   = null;
            sAirline    = null;
        }

        private bool IsValidDateFormat(string input, string format) => DateTime.TryParseExact(input, format, null, DateTimeStyles.None, out DateTime _);

    }
}
