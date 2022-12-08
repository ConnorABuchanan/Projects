using System.Windows.Input;

namespace TheNiceList;

public partial class MainPage : ContentPage
{
    public MainPage()
	{
		InitializeComponent();

	}

    private void CheckButtonClickedHandler(Object sender, EventArgs e)
    {
        output.Text = CalculateNaughtiness();
    }

	private string CalculateNaughtiness()
    {
        return "hi";
    }
}

