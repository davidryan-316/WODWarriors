using Microsoft.Toolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WODWarriors.ViewModel;
public class BaseViewModel : CommunityToolkit.Mvvm.ComponentModel.ObservableObject
{
    //[ObservableProperty]
    //string title;

    //[ObservableProperty]
    private string name;

    private bool _isBusy;
    public bool IsBusy
    {
        get => _isBusy;
        set => SetProperty(ref _isBusy, value);
    }

  
}
