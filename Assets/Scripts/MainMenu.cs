using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// Main Menu Script
/// Mounted on the Main Menu Game Object
/// Objects with a reference to this class call its methods 
/// </summary>
public class MainMenu : MonoBehaviour
{
    /// <summary>
    /// Playgame moves to the text active scene
    /// </summary>
    public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    /// <summary>
    /// Load Game Move to the scene two forwad that has the load menu up aready
    /// </summary>
    public void LoadGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 2);
    }

    /// <summary>
    /// Quit game Quits the game
    /// </summary>
    public void QuitGame()
    {
        //logging quit
        Debug.Log("QUIT!");
        // Closing application
        Application.Quit();
    }
}
