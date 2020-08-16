using TMPro;
using UnityEngine;


/// <summary>
/// Game text script
/// Updates the Text component of the utility text messages
/// Saving Etc.
/// </summary>
public class GameTextScript : MonoBehaviour
{
    // Holds the Text<estProGui Component
    private TextMeshProUGUI _text;
    // Holds the message to be displayed in the Text object this script runs on
    public static string message;
    
    //On Start getting the TextMesh Component and setting it to the variable _text
    private void Start()
    {
        _text = GetComponent<TextMeshProUGUI>();
    }

    /// <summary>
    /// Every frame updating the text to the current message
    /// </summary>
    private void Update()
    {
        _text.text = message;

    }

}


