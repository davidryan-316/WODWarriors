using System;
using System.Collections.Generic;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using WODWarriors.Model;
using Newtonsoft.Json;
using WODWarriors.Services;
using WODWarriors.ViewModel;
using WODWarriors.View;
using System.Linq;

namespace WODWarriors.ViewModel;

public partial class MainViewModel : BaseViewModel
{

    [RelayCommand]
    async Task GoToLoginAsync()
    {
        await Shell.Current.GoToAsync(nameof(LoginPage));

    }
}
