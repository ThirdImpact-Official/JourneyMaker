namespace SoundBoard.UI.Component;

public partial class SoundItemUI : ContentView
{
    private Button _playButton;
    private Button _removeButton;
    private Label _label;
    private Frame _containerFrame;
    private SoundItem _soundItem;

    // Propriété pour définir le SoundItem
    public SoundItem SoundItem
    {
        get => _soundItem;
        set
        {
            _soundItem = value;
            UpdateUI();
        }
    }

    // Events pour communiquer avec le parent
    public event Action<SoundItem> OnPlayRequested;
    public event Action<SoundItem> OnRemoveRequested;

    public SoundItemUI()
    {
        InitializeComponent();
        Create_SoundItemUI();
    }

    // Constructeur avec SoundItem
    public SoundItemUI(SoundItem soundItem) : this()
    {
        SoundItem = soundItem;
    }

    public void Create_SoundItemUI()
    {
        // Créer le label
        _label = new Label
        {
            FontAttributes = FontAttributes.Bold,
            HorizontalOptions = LayoutOptions.Center,
            TextColor = Colors.White,
            FontSize = 16
        };

        // Créer le bouton play
        _playButton = new Button
        {
            Text = "▶ Play",
            BackgroundColor = Colors.White,
            TextColor = Colors.Crimson,
            CornerRadius = 8,
            Shadow = new Shadow
            {
                Brush = Colors.Gray,
                Offset = new Point(2, 2),
                Radius = 5,
                Opacity = 0.3f
            }
        };

        // Créer le bouton remove
        _removeButton = new Button
        {
            Text = "🗑",
            BackgroundColor = Colors.Transparent,
            TextColor = Colors.White,
            FontSize = 12,
            CornerRadius = 5,
            Padding = new Thickness(5),
            Shadow = new Shadow
            {
                Brush = Colors.Black,
                Offset = new Point(1, 1),
                Radius = 3,
                Opacity = 0.2f
            }
        };

        // Configurer les commandes (sans paramètre pour éviter null)
        _playButton.Command = new Command(OnPlayButtonClicked);
        _removeButton.Command = new Command(OnRemoveButtonClicked);

        // Ajouter les effets d'ombre
        AddShadowEffects();

        // Créer le layout
        CreateLayout();
    }

    private void CreateLayout()
    {
        // Container principal
        _containerFrame = new Frame
        {
            BackgroundColor = Colors.Crimson,
            HasShadow = true,
            CornerRadius = 15,
            Padding = new Thickness(15),
            Margin = new Thickness(5),
            Shadow = new Shadow
            {
                Brush = Colors.DarkRed,
                Offset = new Point(3, 3),
                Radius = 10,
                Opacity = 0.4f
            }
        };

        // Stack principal
        var mainStack = new StackLayout
        {
            Spacing = 10
        };

        // Stack pour les boutons (horizontal)
        var buttonStack = new StackLayout
        {
            Orientation = StackOrientation.Horizontal,
            HorizontalOptions = LayoutOptions.Center,
            Spacing = 10
        };

        // Ajouter les éléments
        buttonStack.Children.Add(_playButton);
        buttonStack.Children.Add(_removeButton);

        mainStack.Children.Add(_label);
        mainStack.Children.Add(buttonStack);

        _containerFrame.Content = mainStack;

        // Ajouter le frame au ContentView
        Content = _containerFrame;
    }

    private void AddShadowEffects()
    {
        // Effet d'ombre sur le bouton play
        _playButton.Pressed += (s, e) =>
        {
            _playButton.Shadow = new Shadow
            {
                Brush = Colors.DarkGray,
                Offset = new Point(1, 1),
                Radius = 3,
                Opacity = 0.8f
            };
            _playButton.Scale = 0.95;
        };

        _playButton.Released += (s, e) =>
        {
            _playButton.Shadow = new Shadow
            {
                Brush = Colors.Gray,
                Offset = new Point(2, 2),
                Radius = 5,
                Opacity = 0.3f
            };
            _playButton.Scale = 1.0;
        };

        // Effet d'ombre sur le bouton remove
        _removeButton.Pressed += (s, e) =>
        {
            _removeButton.Shadow = new Shadow
            {
                Brush = Colors.Red,
                Offset = new Point(1, 1),
                Radius = 5,
                Opacity = 0.6f
            };
            _removeButton.Scale = 0.9;
        };

        _removeButton.Released += (s, e) =>
        {
            _removeButton.Shadow = new Shadow
            {
                Brush = Colors.Black,
                Offset = new Point(1, 1),
                Radius = 3,
                Opacity = 0.2f
            };
            _removeButton.Scale = 1.0;
        };
    }

    private void UpdateUI()
    {
        if (_soundItem != null && _label != null)
        {
            _label.Text = _soundItem.Name;
        }
    }

    private void OnPlayButtonClicked()
    {
        if (_soundItem != null)
        {
            PlaySound(_soundItem);
            // Notifier le parent si nécessaire
            OnPlayRequested?.Invoke(_soundItem);
        }
    }

    private void OnRemoveButtonClicked()
    {
        if (_soundItem != null)
        {
            RemoveSound(_soundItem);
            // Notifier le parent si nécessaire
            OnRemoveRequested?.Invoke(_soundItem);
        }
    }

    private async void PlaySound(SoundItem sound)
    {
        Console.WriteLine("Sounditem, Playsound " + sound.Name);

        // Effet visuel de lecture
        var originalColor = _playButton.BackgroundColor;
        _playButton.BackgroundColor = Colors.LightGreen;
        _playButton.Text = "⏸ Stop";

        // Animation de pulse
        await _containerFrame.ScaleTo(1.05, 100);
        await _containerFrame.ScaleTo(1.0, 100);

        // Simuler la lecture (à remplacer par votre logique)
        await Task.Delay(2000);

        // Restaurer l'état normal
        _playButton.BackgroundColor = originalColor;
        _playButton.Text = "▶ Play";
    }

    private async void RemoveSound(SoundItem sound)
    {
        Console.WriteLine("remove item: " + sound.Name);

        // Animation de suppression
        await _containerFrame.FadeTo(0.3, 200);
        await _containerFrame.ScaleTo(0.8, 200);

        // Ici vous pourriez déclencher la suppression réelle
        // Par exemple, remonter l'événement au parent
    }

    // Méthodes publiques pour contrôler l'UI depuis l'extérieur
    public void SetPlayingState(bool isPlaying)
    {
        if (isPlaying)
        {
            _playButton.Text = "⏸ Stop";
            _playButton.BackgroundColor = Colors.LightGreen;
        }
        else
        {
            _playButton.Text = "▶ Play";
            _playButton.BackgroundColor = Colors.White;
        }
    }

    public void HighlightItem(bool highlight)
    {
        if (highlight)
        {
            _containerFrame.BackgroundColor = Colors.DarkRed;
            _containerFrame.Shadow = new Shadow
            {
                Brush = Colors.Red,
                Offset = new Point(5, 5),
                Radius = 15,
                Opacity = 0.6f
            };
        }
        else
        {
            _containerFrame.BackgroundColor = Colors.Crimson;
            _containerFrame.Shadow = new Shadow
            {
                Brush = Colors.DarkRed,
                Offset = new Point(3, 3),
                Radius = 10,
                Opacity = 0.4f
            };
        }
    }
}