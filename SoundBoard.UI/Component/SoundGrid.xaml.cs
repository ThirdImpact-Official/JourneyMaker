using System.Collections.ObjectModel;

namespace SoundBoard.UI.Component;

public partial class SoundGrid : ContentView
{
    private ObservableCollection<SoundItem> _soundItems = new();
    private int _rows = 4;
    private int _columns = 4;
    private int _maxItems = 16;

    public ObservableCollection<SoundItem> SoundItems
    {
        get => _soundItems;
        set
        {
            _soundItems = value ?? new ObservableCollection<SoundItem>();
            RefreshGrid();
        }
    }

    public int Rows
    {
        get => _rows;
        set
        {
            if (value > 0)
            {
                _rows = value;
                _maxItems = _rows * _columns;
                RefreshGrid();
            }
        }
    }

    public int Columns
    {
        get => _columns;
        set
        {
            if (value > 0)
            {
                _columns = value;
                _maxItems = _rows * _columns;
                RefreshGrid();
            }
        }
    }

    public SoundGrid()
    {
        InitializeComponent();
        BuildGrid();
    }

    public SoundGrid(int rows, int columns) : this()
    {
        if (rows > 0) _rows = rows;
        if (columns > 0) _columns = columns;
        _maxItems = _rows * _columns;
        RefreshGrid();
    }

    public bool AddSoundItem(SoundItem soundItem)
    {
        if (soundItem == null || _soundItems.Count >= _maxItems)
            return false;

        _soundItems.Add(soundItem);
        RefreshGrid();
        return true;
    }

    public void ClearSoundItems()
    {
        _soundItems.Clear();
        RefreshGrid();
    }

    private void BuildGrid()
    {
        SoundGridContainer.Children.Clear();
        SoundGridContainer.RowDefinitions.Clear();
        SoundGridContainer.ColumnDefinitions.Clear();
        
        // Créer les colonnes
        for (int i = 0; i < _columns; i++)
        {
            SoundGridContainer.ColumnDefinitions.Add(new ColumnDefinition { Width = GridLength.Star });
        }

        // Créer les lignes
        for (int i = 0; i < _rows; i++)
        {
            SoundGridContainer.RowDefinitions.Add(new RowDefinition { Height = GridLength.Star });
        }

        RefreshGrid();
    }

    private void RefreshGrid()
    {
        SoundGridContainer.Children.Clear();

        int itemIndex = 0;
        for (int row = 0; row < _rows; row++)
        {
            for (int col = 0; col < _columns; col++)
            {
                if (itemIndex < _soundItems.Count)
                {
                    // Ajouter SoundItemUI
                    var soundItemUI = new SoundItemUI(_soundItems[itemIndex]);
                    Grid.SetRow(soundItemUI, row);
                    Grid.SetColumn(soundItemUI, col);
                    SoundGridContainer.Children.Add(soundItemUI);
                }
                else
                {
                    // Slot vide
                    var emptyBox = new BoxView
                    {
                        Color = Colors.LightBlue,
                        CornerRadius = 8,
                        HeightRequest=80,
                        WidthRequest=80
                    };
                    Grid.SetRow(emptyBox, row);
                    Grid.SetColumn(emptyBox, col);
                    SoundGridContainer.Children.Add(emptyBox);
                }
                itemIndex++;
            }
        }
    }

    public void LoadSampleData()
    {
        var sampleItems = new List<SoundItem>
        {
            new SoundItem { Name = "Kick" },
            new SoundItem { Name = "Snare" },
            new SoundItem { Name = "Hi-Hat" },
            new SoundItem { Name = "Cymbal" },
            new SoundItem { Name = "Bass" },
            new SoundItem { Name = "Guitar" },
            new SoundItem { Name = "Piano" },
            new SoundItem { Name = "Synth" }
        };

        _soundItems.Clear();
        foreach (var item in sampleItems.Take(_maxItems))
        {
            _soundItems.Add(item);
        }
        RefreshGrid();
    }
}