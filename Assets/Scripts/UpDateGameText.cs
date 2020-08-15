using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;
using UnityEngine.UI;

public  class UpDateGameText : MonoBehaviour
{
    public static void OnGameOver()
    {
        GameTextScript.message = "GameOver";

    }

    public static void OnSaveGame()
    {
        GameTextScript.message = "Game Saved";

    }

    public static void OnWhiteWins()
    {
        GameTextScript.message = "White Wins!";

    }

    public static void OnBlackWins()
    {
        GameTextScript.message = "Black Wins!";

    }
}
