using System.Windows.Input;

namespace TheNiceList;

public partial class MainPage : ContentPage
{
    private List<String> whitelist;
    private Dictionary<String, String> theNiceList;

    public MainPage()
	{
		InitializeComponent();
        whitelist = new List<String>();
        theNiceList = new Dictionary<String, String>();
        fillWhitelist();
	}

    private void CheckButtonClickedHandler(Object sender, EventArgs e)
    {
        output.Text = CalculateNaughtiness()+"!";
    }

	private string CalculateNaughtiness()
    {
        string input="";
        Random rng= new Random();

        if (name.Text != null)
        {
            input = name.Text.ToLower();
            if (whitelist.Contains(input))
            {
                return "Nicest of Them All";
            }
        }

        string status;

        if (rng.NextDouble() < .5)
        {
            status= "Nice";
        }
        else
        {
            status= "Naughty";
        }

        if (name.Text != null && !theNiceList.ContainsKey(input) && input!="")
        {
            theNiceList.Add(input, status);
        }

        if(theNiceList.ContainsKey(input))
        {
            return theNiceList[input];
        }

        return status;
    }

    private void fillWhitelist()
    {
        whitelist.Add("papa");
        whitelist.Add("rich");
        whitelist.Add("papa rich");
        whitelist.Add("richard");
    }
}

