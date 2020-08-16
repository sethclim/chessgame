using UnityEngine;


/// <summary>
/// Class to update all in game text objects
/// </summary>
public class UpDateGameText : MonoBehaviour
{
    // Float: sets the length of time an object appears for
    private static float timeToAppear = 2.5f;
    //Stores the value for when the text is going to disappears
    private static float timeWhenDisappear;

    /// <summary>
    /// Update called every frame
    /// Checks if the current time is past the time when the text should be cleared
    /// </summary>
    private void Update()
    {
        //Checking if the time is greater then the time to disappear
        if (Time.time >= timeWhenDisappear)
        {
            // setting the two text scripts messages to an empty string
            GameTextScript.message = "";
            WinnerText.message = "";
        }
    }
    /// <summary>
    /// Called when the game is saved
    /// </summary>
    public static void OnSaveGame()
    {
        //Setting Message to the relevent Text script
        GameTextScript.message = "Game Saved";
        //Updating the time to disapear
        timeWhenDisappear = Time.time + timeToAppear;
    }

    /// <summary>
    /// Called when white wins
    /// </summary>
    public static void OnWhiteWins()
    {
        //Setting Message to the relevent Text script
        WinnerText.message = "White Wins!";
        //Updating the time to disapear
        timeWhenDisappear = Time.time + timeToAppear;
    }

    /// <summary>
    /// Called when black wins
    /// </summary>
    public static void OnBlackWins()
    {
        //Setting Message to the relevent Text script
        WinnerText.message = "Black Wins!";
        //Updating the time to disapears
        timeWhenDisappear = Time.time + timeToAppear;
 
    }

}
