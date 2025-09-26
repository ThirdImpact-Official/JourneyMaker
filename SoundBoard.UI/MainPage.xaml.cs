namespace SoundBoard.UI
{
    public partial class MainPage : ContentPage
    {
        public Grid? gridLayout;
        public int _cornerradius=15;
        int count = 0;

        public MainPage()
        {
            InitializeComponent();
            LayoutBuilder();
        }

        private void LayoutBuilder()
        {
            try
            {
                //grid definition
                gridLayout = new Grid()
                {
                    VerticalOptions=LayoutOptions.FillAndExpand,
                    Padding=10,
                    RowSpacing=5,
                    ColumnSpacing=5,
                    RowDefinitions = 
                    {
                        new RowDefinition{ Height= GridLength.Star },
                        new RowDefinition{ },
                        new RowDefinition{Height= GridLength.Star }
                    },ColumnDefinitions =
                    {
                        new ColumnDefinition{Width= GridLength.Star },
                        new ColumnDefinition{Width= GridLength.Star },
                    }

                };
                //RowDefintion
                //row:0 col:0
                gridLayout.Add(new BoxView
                {
                    CornerRadius = _cornerradius,
                    Color = Colors.Salmon
                },0,0);
                //RowDefintion
                //row:0 col:1
                gridLayout.Add(new BoxView
                {
                    CornerRadius = _cornerradius,
                    Color = Colors.RosyBrown
                }, 1, 0);
                //Row:1 col:0
                gridLayout.Add(new BoxView
                {
                    CornerRadius = _cornerradius,
                    Color = Colors.Red
                }, 0, 1);
                gridLayout.Add(new Label
                {
                    Text="Row1 col0 "
                },0,1);
                //Row:1 col:1
                gridLayout.Add(new BoxView
                {
                    CornerRadius = _cornerradius,
                    Color = Colors.Beige
                }, 1, 1);
                BoxView boxView = new BoxView { Color = Colors.Red, CornerRadius = _cornerradius, };
                Grid.SetRow(boxView, 2);
                Grid.SetColumnSpan(boxView, 2);
                Label label = new Label
                {
                    Text = "Row 2, Column 0 and 1",
                    HorizontalOptions = LayoutOptions.Center,
                    VerticalOptions = LayoutOptions.Center
                };
                Grid.SetRow(label, 2);
                Grid.SetColumnSpan(label, 2);

                gridLayout.Add(boxView);
                gridLayout.Add(label);
                scrollView.Content = gridLayout;
            }
            catch (Exception ex)
            { 
            }
        }

      
    }
}
