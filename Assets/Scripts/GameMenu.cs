using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// GameMenu Class
/// Handles method to go back to the main menu
/// </summary>
public class GameMenu : MonoBehaviour
{
    /// <summary>
    /// Go back to main menu called by button MainMenu
    /// </summary>
    public void GoMainMenu()
    {
        //going back a scene
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }
}

