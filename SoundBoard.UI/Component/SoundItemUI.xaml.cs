using UraniumUI.Dialogs;
namespace SoundBoard.UI.Component;
public partial class SoundItemUI : ContentView
{
    public string Name { get; set; }
    public string TimeSpan { get; set; }
    public string Description { get; set; }
    public SoundItem SoundItem { get; set; }
   
    public SoundItemUI()
    {
        InitializeComponent();
      
    }

    public SoundItemUI(SoundItem soundItem) 
    {
        SoundItem = soundItem;
    
        var button = new Button()
        {
              Text = SoundItem.Name,
              StyleClass= new[] {"FilledButton" },
              HeightRequest = 80,
              WidthRequest = 80,
          


        };

        button.Clicked += async (s, e) =>
        {
            await Application.Current.MainPage.DisplayAlert(soundItem.Name,"nom playing","ok");
            Console.WriteLine("Sound Play"+soundItem.Name);
        };

       
        Content = button;
    }
}