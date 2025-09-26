using System.Collections.ObjectModel;

namespace SoundBoard.UI.Component;

public partial class MusicLibrary : ContentView
{
    private readonly ObservableCollection<SoundItem> sounds = new ObservableCollection<SoundItem>();
    private readonly ObservableCollection<SoundItemUI> soundItemUIs = new ObservableCollection<SoundItemUI>();

    public MusicLibrary()
    {
        InitializeComponent();
     
    }
   
}