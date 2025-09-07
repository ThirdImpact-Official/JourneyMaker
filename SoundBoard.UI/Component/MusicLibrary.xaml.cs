namespace SoundBoard.UI.Component;

public partial class MusicLibrary : ContentView
{
    private readonly List<SoundItem> sounds = new List<SoundItem>();
    private readonly List<SoundItemUI> soundItemUIs = new List<SoundItemUI>();

    public MusicLibrary()
    {
        InitializeComponent();
        Building_library();
    }

    public void Building_library()
    {
        sounds.AddRange(new List<SoundItem>
        {
            new SoundItem { Name = "Music 1" },
            new SoundItem { Name = "Music 2" },
            new SoundItem { Name = "Music 3" },
        });

        CreateSoundItemsUI();
        CreateAddButton();
    }

    private void CreateSoundItemsUI()
    {
        foreach (var sound in sounds)
        {
            var soundItemUI = new SoundItemUI(sound);

            // S'abonner aux événements
            soundItemUI.OnPlayRequested += OnSoundPlayRequested;
            soundItemUI.OnRemoveRequested += OnSoundRemoveRequested;

            soundItemUIs.Add(soundItemUI);
            MusicContainer.Children.Add(soundItemUI);
        }
    }

    private void CreateAddButton()
    {
        var addButton = new Button
        {
            Text = "+",
            FontSize = 24,
            BackgroundColor = Colors.Green,
            TextColor = Colors.White,
            CornerRadius = 25,
            WidthRequest = 50,
            HeightRequest = 50,
            Margin = new Thickness(10),
            Shadow = new Shadow
            {
                Brush = Colors.DarkGreen,
                Offset = new Point(3, 3),
                Radius = 8,
                Opacity = 0.5f
            }
        };

        // Ajouter l'effet d'ombre au bouton +
        addButton.Pressed += (s, e) =>
        {
            addButton.Shadow = new Shadow
            {
                Brush = Colors.Black,
                Offset = new Point(1, 1),
                Radius = 10,
                Opacity = 0.7f
            };
            addButton.Scale = 0.9;
        };

        addButton.Released += (s, e) =>
        {
            addButton.Shadow = new Shadow
            {
                Brush = Colors.DarkGreen,
                Offset = new Point(3, 3),
                Radius = 8,
                Opacity = 0.5f
            };
            addButton.Scale = 1.0;
        };

        addButton.Command = new Command(AddNewSound);
        MusicContainer.Children.Add(addButton);
    }

    private void OnSoundPlayRequested(SoundItem sound)
    {
        Console.WriteLine($"Parent received play request for: {sound.Name}");

        // Arrêter tous les autres sons
        foreach (var ui in soundItemUIs)
        {
            if (ui.SoundItem != sound)
            {
                ui.SetPlayingState(false);
            }
        }

        // Ici vous pourriez ajouter la logique de lecture audio
        PlaySoundInParent(sound);
    }

    private void OnSoundRemoveRequested(SoundItem sound)
    {
        Console.WriteLine($"Parent received remove request for: {sound.Name}");

        // Trouver et supprimer l'UI correspondante
        var uiToRemove = soundItemUIs.FirstOrDefault(ui => ui.SoundItem == sound);
        if (uiToRemove != null)
        {
            soundItemUIs.Remove(uiToRemove);
            MusicContainer.Children.Remove(uiToRemove);
            sounds.Remove(sound);
        }
    }

    private void AddNewSound()
    {
        Console.WriteLine("Ajouter un son");

        var newSound = new SoundItem { Name = $"Music {sounds.Count + 1}" };
        sounds.Add(newSound);

        var newSoundItemUI = new SoundItemUI(newSound);
        newSoundItemUI.OnPlayRequested += OnSoundPlayRequested;
        newSoundItemUI.OnRemoveRequested += OnSoundRemoveRequested;

        soundItemUIs.Add(newSoundItemUI);

        // Insérer avant le bouton "+"
        MusicContainer.Children.Insert(MusicContainer.Children.Count - 1, newSoundItemUI);
    }

    private void PlaySoundInParent(SoundItem sound)
    {
        // Logique de lecture audio ici
        Console.WriteLine($"Playing sound in parent: {sound.Name}");

        // Mettre en évidence l'élément en cours de lecture
        var playingUI = soundItemUIs.FirstOrDefault(ui => ui.SoundItem == sound);
        if (playingUI != null)
        {
            playingUI.HighlightItem(true);
            playingUI.SetPlayingState(true);

            // Simuler la fin de lecture après 3 secondes
            Device.StartTimer(TimeSpan.FromSeconds(3), () =>
            {
                playingUI.HighlightItem(false);
                playingUI.SetPlayingState(false);
                return false; // Stop timer
            });
        }
    }
}