using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class GameTextScript : MonoBehaviour
{
    private TextMeshProUGUI _text;
    public static string message;

    private void Start()
    {
        _text = GetComponent<TextMeshProUGUI>();
    }

    private void Update()
    {
        _text.text = message;
    
    }
}
