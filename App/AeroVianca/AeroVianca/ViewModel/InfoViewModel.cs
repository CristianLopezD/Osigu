using AeroVianca.Model;
using AeroVianca.Repositories;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace AeroVianca.ViewModel
{
    public class InfoViewModel : ViewModelBase
    {
        private readonly IFlightRepository fligthRepository;
        
        private ObservableCollection<FlightModel> _flights;
        
        private FlightModel _flightModel = new();

        private string _resultMessage;
        
        private string _codeToSearch;


        public ObservableCollection<FlightModel> Flights
        {
            get { return _flights; }
            set 
            { 
                _flights = value;
                OnPropertyChanged(nameof(_flights));
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

        public string CodeToSearch
        {
            get
            {
                return _codeToSearch;
            }
            set
            {
                _codeToSearch = value;
                OnPropertyChanged(nameof(CodeToSearch));
            }
        }

        public ICommand SearchCommand { get; }
        public ICommand ResetCommand { get; }

        //Constructor
        public InfoViewModel()
        {
            fligthRepository = new FlightRepository();

            Flights = fligthRepository.GetAllFlights();

            SearchCommand = new ViewModelCommand(ExecuteSearchCommand, CanExecuteSearchCommand);
            ResetCommand  = new ViewModelCommand(ExecuteResetCommand);
        }
        
        private bool CanExecuteSearchCommand(object obj) => !(CodeToSearch == null || CodeToSearch == string.Empty);
        private void ExecuteResetCommand(object obj)
        {
            Flights.Clear();
            fligthRepository.GetAllFlights().ToList().ForEach(newFlight => Flights.Add(newFlight));
        }
        private void ExecuteSearchCommand(object obj)
        {
            try
            {
                FlightModel fligth = fligthRepository.GetByCode($"V{CodeToSearch}");
                if(fligth == null)
                {
                    ResultMessage = $"Codigo de Vuelo: {CodeToSearch} No Encontrado";
                }
                else
                {
                    ResultMessage = $"Codigo de Vuelo: {CodeToSearch} Encontrado correctamente";
                    Flights.Clear();
                    Flights.Add(fligth);
                }
            }
            catch (Exception ex)
            {
                ResultMessage = $"** ERROR: {ex.Message}";
            }
        }
    }
}
