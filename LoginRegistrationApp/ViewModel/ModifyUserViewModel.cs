using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WODWarriors.Data;
using WODWarriors.Model;
using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.Input;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;

namespace WODWarriors.ViewModel;
public partial class ModifyUserViewModel : BaseViewModel
{
    public ObservableCollection<User> Users { get; } = new();

    private readonly UserDataStore _userDataStore;

    private User _selectedUser;
    public User SelectedUser
    {
        get => _selectedUser;
        set
        {
            _selectedUser = value;
            OnPropertyChanged(nameof(SelectedUser));
        }
    }
    public ModifyUserViewModel()
    {
        _userDataStore = new UserDataStore();
        _ = LoadUsersAsync();
    }

    [RelayCommand]
    public async Task DeleteSelectedUsers()
    {
        await Task.Delay(50);

        // Display a popup to prompt the user for an admin password
        var password = await Application.Current.MainPage.DisplayPromptAsync("Delete Users", "Enter the admin password", "OK", "Cancel", "", -1, Keyboard.Default, "");

        // Check if the entered password is correct (e.g. hardcoded to "admin" for this example)
        if (password != "admin")
        {
            await Application.Current.MainPage.DisplayAlert("Delete Users", "Incorrect password", "OK");
            return;
        }

        var selectedUsers = Users.Where(user => user.IsSelected).ToList();
        foreach (var user in selectedUsers)
        {
            _ = _userDataStore.DeleteUserAsync(user.Id);
            Users.Remove(user);
        }
    }
    async Task LoadUsersAsync()
    {
        var users = await _userDataStore.GetAllUsersAsync();
        Users.Clear();
        foreach (var user in users)
        {
            Users.Add(user);
        }
    }   

}
   
