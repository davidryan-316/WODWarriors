using WODWarriors.Data;
using WODWarriors.Model;
using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.Input;
using Microsoft.Maui.Controls;
using System.Windows.Input;

namespace WODWarriors.ViewModel
{
    public partial class RegistrationViewModel : BaseViewModel
    {
        private UserDataStore _userDataStore;
        private string _username;
        private string _email;
        private string _password;
        public readonly IEnumerable<char> ErrorMessage;
        public readonly bool IsRegistered;

        public string Username
        {
            get => _username;
            set => SetProperty(ref _username, value);
        }

        public string Email
        {
            get => _email;
            set => SetProperty(ref _email, value);
        }

        public string Password
        {
            get => _password;
            set => SetProperty(ref _password, value);
        }

        public RegistrationViewModel()
        {
            _userDataStore = new UserDataStore();
        }

        [RelayCommand]
        public async Task GetRegister()
        {
            if (IsBusy) return;

            IsBusy = true;
            if (string.IsNullOrEmpty(Username) || string.IsNullOrEmpty(Password) || string.IsNullOrEmpty(Email)) 
            {
                await Application.Current.MainPage.DisplayAlert("Error", "Please enter credentials", "OK");
                return;
            }
            User user = new() { Username = Username, Email = Email, Password = Password };
            bool isRegistered = await _userDataStore.RegisterUserAsync(user);
            IsBusy = false;

            if (isRegistered)
            {
                // Navigate back to the login page if successful
                await Application.Current.MainPage.Navigation.PopAsync();
            }
            else
            {
                // Display an error message
                await Application.Current.MainPage.DisplayAlert("Error", "Registration failed", "OK");
            }
        }
        [RelayCommand]
        async Task GoToLoginAsync()
        {
            await Shell.Current.GoToAsync(nameof(LoginPage));

        }
    }
}
