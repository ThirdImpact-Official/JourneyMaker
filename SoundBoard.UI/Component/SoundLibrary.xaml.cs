namespace SoundBoard.UI.Component;

public partial class SoundLibrary : ContentView
{
	private readonly List<SoundItem> _sounds = new List<SoundItem>();
	
	private readonly List<SoundItemUI> _soundItemUIs = new List<SoundItemUI>();

	public SoundLibrary()
	{
		InitializeComponent();
		Load_Sound_From_Library();

    }
	/// <summary>
	/// Load the Sound  with their Items
	/// </summary>
	public void Load_Sound_From_Library()
	{
		_sounds.AddRange(new List<SoundItem> {
			new SoundItem {
				Name="Sound 1"
			},
			new SoundItem {
				Name="Sound 2"
			},
			new SoundItem {
				Name="Sound3"  }
		});
		
		CreateSoundComponent();
	}

	/// <summary>
	/// 
	/// </summary>
	private void PlaySound(SoundItem soundItem)
	{
		Console.WriteLine("played"+soundItem.Name);
	}
	/// <summary>
	/// 
	/// </summary>
	private void CreateSoundComponent()
	{
		foreach(var item in _sounds) 
		{
			SoundItemUI itemUI = new SoundItemUI(item);

			_soundItemUIs.Add(itemUI);
			SoundsContainer.Children.Add(itemUI);
		}
	}

    private void OnSoundPlayRequested(SoundItem sound)
    {
        Console.WriteLine($"Parent received play request for: {sound.Name}");

        // Arrêter tous les autres sons
        foreach (var ui in _soundItemUIs)
        {
            if (ui.SoundItem != sound)
            {
               
            }
        }

        // Ici vous pourriez ajouter la logique de lecture audio
        PlaySoundInParent(sound);
    }

    private void OnSoundRemoveRequested(SoundItem sound)
    {
        Console.WriteLine($"Parent received remove request for: {sound.Name}");

        // Trouver et supprimer l'UI correspondante
        var uiToRemove = _soundItemUIs.FirstOrDefault(ui => ui.SoundItem == sound);
        if (uiToRemove != null)
        {
            _soundItemUIs.Remove(uiToRemove);
            SoundsContainer.Children.Remove(uiToRemove);
            _sounds.Remove(sound);
        }
    }
    private void PlaySoundInParent(SoundItem sound)
    {
        // Logique de lecture audio ici
        Console.WriteLine($"Playing sound in parent: {sound.Name}");

        // Mettre en évidence l'élément en cours de lecture
        var playingUI = _soundItemUIs.FirstOrDefault(ui => ui.SoundItem == sound);
        if (playingUI != null)
        {
          

            // Simuler la fin de lecture après 3 secondes
            Device.StartTimer(TimeSpan.FromSeconds(3), () =>
            {
               
                return false; // Stop timer
            });
        }
    }
}