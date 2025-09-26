using SoundBoard.UI.ViewModel;
using System.Collections.ObjectModel;

namespace SoundBoard.UI.Page;

public partial class Playlist : ContentPage
{
    public PlaylistViewModel Items;
    public Playlist()
    {
        InitializeComponent();
        Items = new PlaylistViewModel();
        BindingContext = Items;
    }

   

}