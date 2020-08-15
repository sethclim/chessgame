using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;
using UnityEngine.UI;

public class UpDateGameText : MonoBehaviour
{

    private static float timeToAppear = 2.5f;
    private static float timeWhenDisappear;
    public static bool updated;

    private void Update()
    {
        if (updated && (Time.time >= timeWhenDisappear))
        {
            GameTextScript.message = "";
            WinnerText.message = "";
        }
    }
    public static void OnGameOver()
    {
        GameTextScript.message = "Game Over";
        timeWhenDisappear = Time.time + timeToAppear;
        updated = true;
        
    }

    public static void OnSaveGame()
    {
        GameTextScript.message = "Game Saved";
        timeWhenDisappear = Time.time + timeToAppear;
        updated = true;

    }

    public static void OnWhiteWins()
    {
        WinnerText.message = "White Wins!";
        timeWhenDisappear = Time.time + timeToAppear;
        updated = true;
    }

    public static void OnBlackWins()
    {
        WinnerText.message = "Black Wins!";
        timeWhenDisappear = Time.time + timeToAppear;
        updated = true;
    }

}
