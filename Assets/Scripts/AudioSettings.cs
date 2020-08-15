using UnityEngine;


/// <summary>
/// Audio Settings class 
/// Sets the volume to the value set and saved in the main menu
/// </summary>
public class AudioSettings : MonoBehaviour
{
    // background pref key
    private static readonly string BackgroundPref = "BackgroundPref";
    // background volume level as a float 
    private float backgroundFloat;
    // backgroundAudio source object
    public AudioSource backgroundAudio;

    /// <summary>
    /// Calls continue settings on awake
    /// </summary>
    private void Awake()
    {
        ContinueSettings();
    }

    /// <summary>
    /// Loads background audio volume from PlayerPrefs
    /// sets the backgreound audio level to the value
    /// </summary>
    private void ContinueSettings()
    {
        backgroundFloat = PlayerPrefs.GetFloat(BackgroundPref);
        backgroundAudio.volume = backgroundFloat;
    }
}
