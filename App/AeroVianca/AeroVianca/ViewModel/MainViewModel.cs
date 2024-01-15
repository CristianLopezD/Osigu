using AeroVianca.Interfaces;
using AeroVianca.Model;
using AeroVianca.Repositories;
using FontAwesome.Sharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace AeroVianca.ViewModel
{
    public class MainViewModel : ViewModelBase
    {
        //Fields
        private UserAccountModel _currentUserAccount;
        private ViewModelBase _currentChildView;
        private string _caption;
        private IconChar _icon;

        private IUserRepository userRepository;

        //Properties
        public UserAccountModel CurrentUserAccount
        {
            get
            {
                return _currentUserAccount;
            }
            set
            {
                _currentUserAccount = value;
                OnPropertyChanged(nameof(CurrentUserAccount));
            }
        }

        public ViewModelBase CurrentChildView
        {
            get
            {
                return _currentChildView;
            }

            set
            {
                _currentChildView = value;
                OnPropertyChanged(nameof(CurrentChildView));
            }
        }

        public string Caption
        {
            get
            {
                return _caption;
            }

            set
            {
                _caption = value;
                OnPropertyChanged(nameof(Caption));
            }
        }

        public IconChar Icon
        {
            get
            {
                return _icon;
            }

            set
            {
                _icon = value;
                OnPropertyChanged(nameof(Icon));
            }
        }

        //--> Commands
        public ICommand ShowHomeViewCommand     { get; }
        public ICommand ShowPlannerViewCommand  { get; }
        public ICommand ShowInfoViewCommand     { get; }
        public ICommand CloseCommand            { get; }

        public MainViewModel()
        {
            userRepository = new UserRepository();
            CurrentUserAccount = new UserAccountModel();

            //Initialize commands
            ShowHomeViewCommand     = new ViewModelCommand(ExecuteShowHomeViewCommand);
            ShowPlannerViewCommand  = new ViewModelCommand(ExecuteShowPlannerViewCommand);
            ShowInfoViewCommand     = new ViewModelCommand(ExecuteShowInfoViewCommand);
            CloseCommand            = new ViewModelCommand(ExecuteClose);

            //Default view
            ExecuteShowHomeViewCommand(null);

            LoadCurrentUserData();
        }

        private void ExecuteShowPlannerViewCommand(object obj)
        {
            CurrentChildView = new PlanningViewModel();
            Caption = "Programar Vuelos";
            Icon = IconChar.Plane;
        }

        private void ExecuteShowHomeViewCommand(object obj)
        {
            CurrentChildView = new HomeViewModel();
            Caption = "Dashboard";
            Icon = IconChar.Home;
        }
        private void ExecuteShowInfoViewCommand(object obj)
        {
            CurrentChildView = new InfoViewModel();
            Caption = "Informacion de Vuelos";
            Icon = IconChar.Info;
        }

        private void ExecuteClose(object obj) => Application.Current.Shutdown();

        private void LoadCurrentUserData()
        {
            var user = userRepository.GetByUsername(Thread.CurrentPrincipal.Identity.Name);
            if (user == null) return;
                
            CurrentUserAccount.Username = user.Username;
            CurrentUserAccount.DisplayName = user.Name;
        }
    }
}
