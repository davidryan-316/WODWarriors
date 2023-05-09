using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WODWarriors.View;

namespace WODWarriors.ViewModel;

[QueryProperty("BodyPart", "BodyPart")]
[QueryProperty("Movement", "Movement")]
public partial class WorkoutDetailsViewModel : BaseViewModel
{
    public List<BodyPart> Parts { get; set; }
    public string SelectedImage { get; }

    public WorkoutDetailsViewModel(string selectedImage)
    {
        SelectedImage = selectedImage;
    }

    public WorkoutDetailsViewModel(Movement movement)
    {
        this.movement = movement;
    }

    [ObservableProperty]
    BodyPart bodyPart;
    [ObservableProperty]
    Movement movement;


}


