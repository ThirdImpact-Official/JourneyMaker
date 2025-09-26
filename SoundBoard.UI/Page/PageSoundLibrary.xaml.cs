namespace SoundBoard.UI.Page;

public partial class PageSoundLibrary : ContentPage
{
    private SoundSheet SoundSheet { get; set; } = new SoundSheet();
    private Frame frameContainer { get; set; }
	public PageSoundLibrary()
	{
		InitializeComponent();
        PageMusicBuilder();
	}
    /// <summary>
    /// PageBuilder
    /// </summary>
    private void PageMusicBuilder()
    {
        try
        {
            frameContainer = new Frame
            {
                HasShadow=true,
                Padding=4
            };
            var soundSheet = new SoundSheet();
        
            var soundGrid = new SoundGrid(3, 3); // 3x3 grid

            // Ajouter des sons
            soundGrid.AddSoundItem(new SoundItem { Name = "Bass Drum" });
            soundGrid.AddSoundItem(new SoundItem { Name = "Snare" });

            // Ou charger des données d'exemple
            soundGrid.LoadSampleData();
            frameContainer.Content = soundGrid;

            soundSheet.AddSoundGrid(soundGrid);
            pageSoundContainer.Children
                .Add(frameContainer);

        }
        catch (Exception ex)
        {

        }
    }
}