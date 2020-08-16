using UnityEngine;
using TMPro;

/// <summary>
/// WinnerText Script
/// runs on the text object that announces the winner of the game
/// </summary>
public class WinnerText : MonoBehaviour
{
    // Stores the textMesh Component
    private TextMeshProUGUI _text;
    // Stores the current message to be displayed
    public static string message;

    // Getting the TextMesh component on start and assigning it to _text
    private void Start()
    {
        _text = GetComponent<TextMeshProUGUI>();
    }


    /// <summary>
    /// Updating the text to the message every frame
    /// </summary>
    private void Update()
    {
        _text.text = message;


    }

}
