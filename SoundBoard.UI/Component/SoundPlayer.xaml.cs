using Microsoft.Maui.Controls;
using SoundBoard.UI.Service;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace SoundBoard.UI.Component;

public partial class SoundPlayer : ContentView, INotifyPropertyChanged
{
    private string _soundTitle = "Sound Player";
    private bool _isPlaying;
    private double _volume = 0.7;
    private double _playbackSpeed = 1.0;
    private double _playbackPosition;
    private TimeSpan _currentTime;
    private TimeSpan _totalTime = TimeSpan.FromSeconds(30); // Example
    private ISoundPlayService _playService;
    public SoundPlayer(ISoundPlayService soundPlay)
    {
        InitializeComponent();
        BindingContext = this;
        _playService = soundPlay;
    }
    public SoundPlayer()
    {
        InitializeComponent();
        BindingContext = this;
    }
    // Properties with INotifyPropertyChanged implementation
    public string SoundTitle
    {
        get => _soundTitle;
        set { _soundTitle = value; OnPropertyChanged(); }
    }

    public bool IsPlaying
    {
        get => _isPlaying;
        set { _isPlaying = value; OnPropertyChanged(); }
    }

    public double Volume
    {
        get => _volume;
        set { _volume = value; OnPropertyChanged(); }
    }

    // Add other properties and commands...

    public event PropertyChangedEventHandler PropertyChanged;
    protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
    
}
