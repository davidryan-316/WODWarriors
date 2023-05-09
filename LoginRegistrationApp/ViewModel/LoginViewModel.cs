using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WODWarriors.Data;
using WODWarriors.Model;
using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.Input;
using Microsoft.Maui.Controls;
using System.Windows.Input;
using WODWarriors.View;
using CommunityToolkit.Mvvm.Input;
using WODWarriors.View;

namespace WODWarriors.ViewModel;

public partial class LoginViewModel : BaseViewModel
{
    private readonly UserDataStore _userDataStore;
    private string _username;
    private string _password;
    private string _selectedAction;
    private string welcomeMessage;

    public string Username { get => _username; set => SetProperty(ref _username, value); }

    public string Password { get => _password; set => SetProperty(ref _password, value); }
    public string SelectedAction { get => _selectedAction; set => SetProperty(ref _selectedAction, value); }

    public LoginViewModel()
    {
        _userDataStore = new UserDataStore();
    }

    [RelayCommand]
    async Task Navigate()
    {
        await Task.Delay(50);

        switch (SelectedAction)
        {
            case "Register":
                await Shell.Current.GoToAsync(nameof(RegistrationPage));
                break;
            case "Modify User":
                await Shell.Current.GoToAsync(nameof(ModifyUserPage));
                break;
        }
    }


    [RelayCommand]
    async Task GoToDetailsAsync()
{
    await Task.Delay(100);

    if (IsBusy) return;

    if (string.IsNullOrEmpty(Username) || string.IsNullOrEmpty(Password))
    {
        await Application.Current.MainPage.DisplayAlert("Error", "Please enter your username and password", "OK");
        return;
    }

    IsBusy = true;
    var user = await _userDataStore.GetUserByUsernameAndPasswordAsync(Username, Password);
    IsBusy = false;

    if (user != null)
    {
        string welcomeMessage = $"Welcome, {Username}!";
        await Application.Current.MainPage.DisplayAlert("Success", welcomeMessage, "OK");
        await Shell.Current.GoToAsync($"{nameof(DetailsPage)}");
    }
    else
    {
        await Application.Current.MainPage.DisplayAlert("Error", "Invalid credentials. Have you registered?", "OK");
    }
}

}

