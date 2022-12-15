using System.Windows.Input;

namespace TheNiceList;

public partial class MainPage : ContentPage
{
    //fields
    private List<String> whitelist;
    private List<String> blacklist;
    private Dictionary<String, String> theNiceList;

    /// <summary>
    /// constructor
    /// </summary>
    public MainPage()
	{
		InitializeComponent();
        whitelist = new List<String>();
        blacklist = new List<String>();
        theNiceList = new Dictionary<String, String>();
        fillWhitelist();
	}

    /// <summary>
    /// handler for the check it twice button and for the completed event
    /// shows whether the person whose name is in the entry is naughty or nice
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void CheckButtonClickedHandler(Object sender, EventArgs e)
    {
        //don't let the event play out if the name does not have any text in it
        if(name.Text == null || name.Text.Length == 0)
        {
            return;
        }

        //calculate the naughtiness and place it in the output text label
        output.Text = CalculateNaughtiness()+"!";
    }

    /// <summary>
    /// calculates the naughtiness of the person whose name is in the text field
    /// it does this randomly if there is no prior experience with that name, 
    /// but if the name has been used before on this run of the app, the status will be saved
    /// </summary>
    /// <returns> returns either naughty or nice </returns>
	private string CalculateNaughtiness()
    {
        string input="";
        Random rng= new Random();

        //gets the name in the text box.
        if (name.Text != null)
        {
            input = name.Text.ToLower();

            //if the name is in the whitelist return nice/a variation
            if (whitelist.Contains(input))
            {
                return "Nicest of Them All";
            }
            //if the name is in the blacklist return naughty/a variation
            if(blacklist.Contains(input))
            {
                return "Are you excited for coal?";
            }
        }

        string status;

        //randomly decide the status of the person
        if (rng.NextDouble() < .5)
        {
            status= "Nice";
        }
        else
        {
            status= "Naughty";
        }

        //if the name is not already stored, store it with its status
        if (name.Text != null && !theNiceList.ContainsKey(input) && input!="")
        {
            theNiceList.Add(input, status);
        }

        //if the nice list contains the the status, return that
        if(theNiceList.ContainsKey(input))
        {
            return theNiceList[input];
        }

        //otherwise return the randomly generated one
        return status;
    }

    /// <summary>
    /// fills the default whitelist
    /// </summary>
    private void fillWhitelist()
    {
        whitelist.Add("papa");
        whitelist.Add("rich");
        whitelist.Add("papa rich");
        whitelist.Add("richard");
    }

    /// <summary>
    /// clears the nice list, whitelist, and blacklist
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void ResetButtonClicked(Object sender, EventArgs e)
    {
        theNiceList.Clear();
        whitelist.Clear();
        blacklist.Clear();
        fillWhitelist();
    }

    /// <summary>
    /// handler for the console button. opens the console in which users
    /// can add to the whitelist and the blacklist
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void ConsoleButtonClicked(Object sender, EventArgs e)
    {
        Window console = new Window(new Console(this));
        Application.Current.OpenWindow(console);
    }

    /// <summary>
    /// adds the given name to the whitelist
    /// </summary>
    /// <param name="name"></param>
    public void AddToWhitelist(string name)
    {
        if (whitelist.Contains(name))
            return;
        whitelist.Add(name);
    }

    /// <summary>
    /// adds the given name to the blacklist
    /// </summary>
    /// <param name="name"></param>
    public void AddToBlacklist(string name)
    {
        if (whitelist.Contains(name))
            return;
        blacklist.Add(name);
    }

    /// <summary>
    /// removes the given name from the whitelist
    /// returns false if the operation was unsuccesful. true otherwise
    /// </summary>
    /// <param name="name"></param>
    /// <returns></returns>
    public bool RemoveFromWhitelist(string name)
    {
        if (whitelist.Contains(name))
        {
            whitelist.Remove(name);
            return true;
        }
        return false;

    }

    /// <summary>
    /// removes the given name from the blacklist
    /// returns false if the operation was unsuccesful. true otherwise
    /// </summary>
    /// <param name="name"></param>
    /// <returns></returns>
    public bool RemoveFromBlacklist(string name)
    {
        if (blacklist.Contains(name))
        {
            blacklist.Remove(name);
            return true;
        }
        return false;
    }

}

