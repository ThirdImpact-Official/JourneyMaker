using Plugin.Maui.Audio;
using SoundBoard.UI.Service;

namespace SoundBoard.UI.Component;

public partial class Footer : ContentView
{
	public SoundPlayer player;
	public AudioManager audioManager= new();
	private ISoundPlayService _soundPlayService;
	public Footer()
	{
		InitializeComponent();

		_soundPlayService = new SoundPlayService(audioManager);
		player = new SoundPlayer(_soundPlayService);

		var stack = new VerticalStackLayout()
		{
			Padding = 4,
			StyleClass=new List<string>() { "Elevation1"},
			MaximumHeightRequest=200
		};
		//ajout du frame
		var fram = new Frame
		{
			HasShadow = true,

		};

	
		stack.Children.Add(player);
        Content = stack;
	}
	
}