using SoundBoard.UI.EventApp;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using UraniumUI.Material.Controls;
using TabItem = UraniumUI.Material.Controls.TabItem;
using TabView = UraniumUI.Material.Controls.TabView;

namespace SoundBoard.UI.Component;

public partial class SoundSheet : ContentView, INotifyPropertyChanged
{
    #region Private Fields
    private readonly ObservableCollection<TabItem> _tabItems = new();
    private TabView _tabView;
    private readonly Color _accentColor = Colors.Coral;
    private bool _isInitialized;
    private ObservableCollection<SoundGrid> _soundGrids = new();
    #endregion

    #region Public Properties
    public ObservableCollection<SoundGrid> SoundGrids
    {
        get => _soundGrids;
        set
        {
            if (_soundGrids != value)
            {
                if (_soundGrids != null)
                    _soundGrids.CollectionChanged -= OnSoundGridsCollectionChanged;

                _soundGrids = value ?? new ObservableCollection<SoundGrid>();

                if (_soundGrids != null)
                    _soundGrids.CollectionChanged += OnSoundGridsCollectionChanged;

                OnPropertyChanged();
                RefreshTabs();
            }
        }
    }

    public Color AccentColor => _accentColor;
    public bool HasSoundGrids => _soundGrids?.Count > 0;
    public int SoundGridCount => _soundGrids?.Count ?? 0;
    #endregion

    #region Events
    public event EventHandler<SoundGridEventArg> SoundGridAdded;
    public event EventHandler<SoundGridEventArg> SoundGridRemoved;
    public event EventHandler AddNewSoundGridRequested;
    public event PropertyChangedEventHandler PropertyChanged;
    #endregion

    #region Constructor
    public SoundSheet()
    {
        InitializeComponent();
        InitializeSoundGrids();
        InitializeUI();
    }
    #endregion

    #region Private Methods
    private void InitializeSoundGrids()
    {
        _soundGrids = new ObservableCollection<SoundGrid>();
        _soundGrids.CollectionChanged += OnSoundGridsCollectionChanged;
    }

    private void InitializeUI()
    {
        if (_isInitialized) return;

        try
        {
            var mainFrame = CreateMainFrame();
            _tabView = CreateTabView();

            mainFrame.Content = _tabView;
            Content = mainFrame;

            RefreshTabs();
            _isInitialized = true;
        }
        catch (Exception ex)
        {
            System.Diagnostics.Debug.WriteLine($"InitializeUI error: {ex.Message}");
            CreateFallbackUI();
        }
    }

    private Frame CreateMainFrame()
    {
        return new Frame
        {
            Padding = new Thickness(10),
            BackgroundColor = Colors.White,
            CornerRadius = 15,
            HasShadow = true,
            VerticalOptions = LayoutOptions.FillAndExpand,
            HorizontalOptions = LayoutOptions.FillAndExpand
        };
    }

    private TabView CreateTabView()
    {
        return new TabView
        {
            ItemsSource = _tabItems
        };
    }

    private void RefreshTabs()
    {
        _tabItems.Clear();

        // Add tabs for each sound grid
        if (_soundGrids != null)
        {
            for (int i = 0; i < _soundGrids.Count; i++)
            {
                var grid = _soundGrids[i];
                var tabItem = CreateSoundGridTabItem(grid, i);
                _tabItems.Add(tabItem);
            }
        }

        // Add the "+" tab for adding new sound grids
        AddNewSoundGridTab();
    }

    private TabItem CreateSoundGridTabItem(SoundGrid soundGrid, int index)
    {
        return new TabItem
        {
            Title = $"Sound Grid {index + 1}",
            Content = CreateSoundGridContainer(soundGrid),
            Data = soundGrid, // Important: lier les données
            Header = CreateTabHeader($"Grid {index + 1}", Colors.Blue)
        };
    }

    private View CreateTabHeader(string title, Color color)
    {
        return new Label
        {
            Text = title,
            TextColor = color,
            FontSize = 14,
            FontAttributes = FontAttributes.Bold,
            HorizontalOptions = LayoutOptions.Center,
            VerticalOptions = LayoutOptions.Center,
            Margin = new Thickness(10, 5)
        };
    }

    private View CreateSoundGridContainer(SoundGrid soundGrid)
    {
        return new ContentView
        {
            Content = soundGrid,
            Padding = new Thickness(10),
            VerticalOptions = LayoutOptions.FillAndExpand,
            HorizontalOptions = LayoutOptions.FillAndExpand
        };
    }

    private void AddNewSoundGridTab()
    {
        var addTabItem = new TabItem
        {
            Title = "+",
            Content = CreateAddTabContent(),
            Header = CreateAddTabHeader(),
            Data = null // Marque comme tab d'ajout
        };

        _tabItems.Add(addTabItem);
    }
    private View CreateAddTabContent()
    {
        var addButton = new Button
        {
            Text = "Add New Sound Grid",
            BackgroundColor = _accentColor,
            TextColor = Colors.White,
            CornerRadius = 8,
            Padding = new Thickness(20, 10),
            HorizontalOptions = LayoutOptions.Center,
            VerticalOptions = LayoutOptions.Center
        };

        addButton.Clicked += OnAddNewSoundGridClicked;

        // Créez un ContentView avec un GestureRecognizer qui ignore les taps
        var container = new ContentView
        {
            Content = new StackLayout
            {
                Children =
            {
                new Label
                {
                    Text = "Add a new sound grid to get started",
                    TextColor = Colors.Gray,
                    HorizontalOptions = LayoutOptions.Center,
                    Margin = new Thickness(0, 0, 0, 20)
                },
                addButton
            },
                VerticalOptions = LayoutOptions.Center,
                HorizontalOptions = LayoutOptions.Center,
                Padding = new Thickness(30)
            }
        };

        // Empêche la sélection de l'onglet quand on clique ailleurs que sur le bouton
        var tapGesture = new TapGestureRecognizer();
        tapGesture.Tapped += (s, e) => { /* Ne rien faire - empêche la sélection */ };
        container.GestureRecognizers.Add(tapGesture);

        return container;
    }
    

    private View CreateAddTabHeader()
    {
        return new Label
        {
            Text = "+",
            TextColor = _accentColor,
            FontSize = 18,
            FontAttributes = FontAttributes.Bold,
            HorizontalOptions = LayoutOptions.Center,
            VerticalOptions = LayoutOptions.Center,
            Margin = new Thickness(15, 5)
        };
    }

    private void CreateFallbackUI()
    {
        Content = new Label
        {
            Text = "Error loading sound sheet",
            TextColor = Colors.Red,
            HorizontalOptions = LayoutOptions.Center,
            VerticalOptions = LayoutOptions.Center
        };
    }
    #endregion

    #region Public Methods
    public bool AddSoundGrid(SoundGrid soundGrid)
    {
        if (soundGrid == null || _soundGrids.Contains(soundGrid))
            return false;

        _soundGrids.Add(soundGrid);
        OnSoundGridAdded(new SoundGridEventArg(soundGrid));
        return true;
    }

    public bool RemoveSoundGrid(SoundGrid soundGrid)
    {
        if (soundGrid == null || !_soundGrids.Contains(soundGrid))
            return false;

        _soundGrids.Remove(soundGrid);
        OnSoundGridRemoved(new SoundGridEventArg(soundGrid));
        return true;
    }

    public void ClearSoundGrids()
    {
        var removedGrids = _soundGrids.ToList();
        _soundGrids.Clear();

        foreach (var grid in removedGrids)
        {
            OnSoundGridRemoved(new SoundGridEventArg(grid));
        }
    }
    #endregion

    #region Event Handlers
    private void OnSoundGridsCollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
    {
        RefreshTabs();
        OnPropertyChanged(nameof(HasSoundGrids));
        OnPropertyChanged(nameof(SoundGridCount));
    }

    private void OnAddNewSoundGridClicked(object sender, EventArgs e)
    {
        OnAddNewSoundGridRequested();
    }
    #endregion

    #region Event Raising Methods
    protected virtual void OnSoundGridAdded(SoundGridEventArg e)
    {
        SoundGridAdded?.Invoke(this, e);
    }

    protected virtual void OnSoundGridRemoved(SoundGridEventArg e)
    {
        SoundGridRemoved?.Invoke(this, e);
    }

    protected virtual void OnAddNewSoundGridRequested()
    {
        AddNewSoundGridRequested?.Invoke(this, EventArgs.Empty);
    }

    protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
    #endregion

    #region Cleanup
    protected override void OnHandlerChanging(HandlerChangingEventArgs args)
    {
        base.OnHandlerChanging(args);

        if (args.NewHandler == null && _soundGrids != null)
        {
            _soundGrids.CollectionChanged -= OnSoundGridsCollectionChanged;
        }
    }
    #endregion

}