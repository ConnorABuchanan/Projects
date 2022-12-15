namespace TheNiceList;

public partial class Console : ContentPage
{
    MainPage parent;

    /// <summary>
    /// constructor
    /// </summary>
    /// <param name="mp"></param>
	public Console(MainPage mp)
	{
		InitializeComponent();
        parent = mp;
	}

    /// <summary>
    /// processes the commands sent by the user
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void CommandSent(Object sender, EventArgs e)
    {
        //create an array from the command separated by spaces
        string[] command = commandIn.Text.ToLower().Split(' ');

        //if the command is too short return
        if(command.Length<=2)
        {
            return;
        }

        //get the name
        string name = "";
        for(int i=2; i<command.Length; i++)
        {
            name += command[i];
        }

        //check if the command is to add
        if (command[0] == "add")
        {
            //if the command is to add to the nice list
            if(command[1] == "nice")
            {
                //update the whitelist and send a message to the user
                parent.AddToWhitelist(name);
                commandOut.UpdateText(commandOut.Text + "\n Added " + name + " to the Nice List.");
            }
            //otherwise if the it is to add to the naughty list
            else if(command[1] == "naughty")
            {
                //update the blacklist and send a message to the user
                parent.AddToBlacklist(name);
                commandOut.UpdateText(commandOut.Text+ "\n Added " + name + " to the Naughty List.");
            }
        }
        //if the command is to remove
        else if (command[0] == "remove")
        {
            //if the command is to remove from the nice list
            if (command[1] == "nice")
            {
                //check if the removal is possible, and if so, do it and alert the user
                if (parent.RemoveFromWhitelist(name))
                {
                    commandOut.UpdateText(commandOut.Text + "\n Removed " + name + " from the Nice List.");
                }
                //otherwise alert the user that the command could not be carried out
                else
                {
                    commandOut.UpdateText(commandOut.Text + "\n there was a problem removing "+name+" from the Nice list.");
                }
            }
            //otherwise if the command is to remove from the naughty list
            else if (command[1] == "naughty")
            {
                //try to remove from the black list, and if it works, alert the user
                if (parent.RemoveFromBlacklist(name))
                {
                    commandOut.UpdateText(commandOut.Text + "\n Removed " + name + " to the Naughty List.");
                }
                //otherwise, alert the user that there was a problem
                else
                {
                    commandOut.UpdateText(commandOut.Text + "\n there was a problem removing " + name + " from the Naughty list.");
                }
            }
        }

        commandIn.Text = "";

    }

}