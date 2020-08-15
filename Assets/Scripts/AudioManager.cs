using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Audio Manager
/// Handles all game audio methods 
/// Getting slider input, settting volume and saving 
/// </summary>
public class AudioManager : MonoBehaviour
{
    // Keys to access values in preferences
    private static readonly string FirstPlay = "FirstPlay";
    private static readonly string BackgroundPref = "BackgroundPref";
    // Int to store if its the First Play of game
    private int firstPlayInt;
    // Stores the level of the background audio
    private float backgroundFloat;
    //Stores a reference to the backgroundSlider Object
    public Slider backgroundSlider;
    //Stores a reference to the backgroundAudio Object
    public AudioSource backgroundAudio;

    /// <summary>
    /// Called on start
    /// Sets and saves default audio levels 
    /// </summary>
    void Start()
    {
        // Getting the first play Int from PlayerPrefs
        firstPlayInt = PlayerPrefs.GetInt(FirstPlay);

        //checking if its the first play
        if (firstPlayInt == 0)
        {
            // setting and saving default values
            backgroundFloat = 0.25f;
            backgroundSlider.value = backgroundFloat;
            PlayerPrefs.SetFloat(BackgroundPref, backgroundFloat);
            PlayerPrefs.SetInt(FirstPlay, -1);
        }
        else
        {
            //Getting the saved Preference for the background level if its not the first play
            backgroundFloat = PlayerPrefs.GetFloat(BackgroundPref);
            backgroundSlider.value = backgroundFloat;
        }



    }

    // On awake calling ContiueSettings
    private void Awake()
    {
        ContinueSettings();
    }

    //Getting and setting Saved PlayerPrefs for the background audio levels
    private void ContinueSettings()
    {
        backgroundFloat = PlayerPrefs.GetFloat(BackgroundPref);
        backgroundAudio.volume = backgroundFloat;
    }

    // Saving the Background audio level to player prefs
    public void SaveSoundSettings()
    {
        PlayerPrefs.SetFloat(BackgroundPref, backgroundSlider.value);
    }

    /// <summary>
    /// OnApplicationFocus Saving the Game sound settings if the game loses focus 
    /// </summary>
    /// <param name="inFocus">bool representing if the game is in focus</param>
    public void OnApplicationFocus(bool inFocus)
    {
        if (!inFocus)
        {
            //if not in focus saving the sound settings
            SaveSoundSettings();
        }
    }

    // updating the actual volume with the slider value
    //The slider game object calls this method
    public void updateSound()
    {
        backgroundAudio.volume = backgroundSlider.value;

    }
}
