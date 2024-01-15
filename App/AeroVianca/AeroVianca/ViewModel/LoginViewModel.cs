using System.Net;
using System.Security;
using AeroVianca.Model;
using System.Windows.Input;
using System.Security.Principal;
using AeroVianca.Repositories;
using AeroVianca.Interfaces;

namespace AeroVianca.ViewModel
{
    public class LoginViewModel : ViewModelBase
    {
        //Fields
        private string _username;
        private SecureString _password;
        private string _name;
        private string _email;

        private string _errorMessage;
        private bool _isViewVisible = true;
        private bool _isRegisterVisible = true;

        private readonly IUserRepository userRepository;

        //Properties
        public string Username
        {
            get
            {
                return _username;
            }

            set
            {
                _username = value;
                OnPropertyChanged(nameof(Username));
            }
        }
        public string Name
        {
            get
            {
                return _name;
            }

            set
            {
                _name = value;
                OnPropertyChanged(nameof(Name));
            }
        }
        public string Email
        {
            get
            {
                return _email;
            }

            set
            {
                _email = value;
                OnPropertyChanged(nameof(Email));
            }
        }

        public SecureString Password
        {
            get
            {
                return _password;
            }

            set
            {
                _password = value;
                OnPropertyChanged(nameof(Password));
            }
        }

        public string ErrorMessage
        {
            get
            {
                return _errorMessage;
            }

            set
            {
                _errorMessage = value;
                OnPropertyChanged(nameof(ErrorMessage));
            }
        }

        public bool IsViewVisible
        {
            get
            {
                return _isViewVisible;
            }

            set
            {
                _isViewVisible = value;
                OnPropertyChanged(nameof(IsViewVisible));
            }
        }
        public bool IsRegisterVisible
        {
            get
            {
                return _isRegisterVisible;
            }

            set
            {
                _isRegisterVisible = value;
                OnPropertyChanged(nameof(IsRegisterVisible));
            }
        }

        //-> Commands
        public ICommand LoginCommand { get; }
        public ICommand AddUserCommand { get; }

        //Constructor
        public LoginViewModel()
        {
            userRepository      = new UserRepository();
            LoginCommand        = new ViewModelCommand(ExecuteLoginCommand, CanExecuteLoginCommand);
            AddUserCommand      = new ViewModelCommand(ExecuteAddUserCommand, CanExecuteAddCommand);
        }

        private bool CanExecuteLoginCommand(object obj)
        {
            bool validData = true;
            if (string.IsNullOrWhiteSpace(Username) || Username.Length < 3 || Password == null || Password.Length < 3)
                validData = false;
            return validData;
        }    

        private void ExecuteLoginCommand(object obj)
        {
            string isValidUser = userRepository.AuthenticateUser(new NetworkCredential(Username, Password));
            if (isValidUser.Equals(string.Empty))
            {
                Thread.CurrentPrincipal = new GenericPrincipal(new GenericIdentity(Username), null);
                IsViewVisible = false;
            }
            else
            {
                ErrorMessage = isValidUser;
            }
        }

        private bool CanExecuteAddCommand(object obj)
        {
            bool validData = true;
            if (string.IsNullOrWhiteSpace(Username) || Username.Length  < 3 ||
                string.IsNullOrWhiteSpace(Name)     || Name.Length      < 3 ||
                string.IsNullOrWhiteSpace(Email)    || Email.Length     < 3 ||
                Password == null || Password.Length < 3)
                validData = false;
            return validData;
        }

        private void ExecuteAddUserCommand(object obj)
        {
            UserModel user = new()
            {
                Username = Username,
                Name     = Name,
                Password = new NetworkCredential(string.Empty, Password).Password,
                Email    = Email,
            };
            string isValidUser = userRepository.Add(user);
            if (isValidUser.Equals(string.Empty))
            {
                IsRegisterVisible   = false;
                IsViewVisible       = true;
            }
            else
            {
                Username = string.Empty;
                Name = string.Empty;
                Password = new SecureString();
                Email = string.Empty;

                ErrorMessage = isValidUser;
            }
        }
    }
}
