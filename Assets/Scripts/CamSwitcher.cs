using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamSwitcher : MonoBehaviour
{
    public static CamSwitcher Instance { set; get; }
    public Camera CamOnePrefab;
    public Camera CamTwoPrefab;

    private Camera camOne;
    private Camera camTwo;


    public void SetCameras()
    {
        camOne = Instantiate(CamOnePrefab) as Camera;
        camTwo = Instantiate(CamTwoPrefab) as Camera;

        camOne.enabled = true;
        camTwo.enabled = false;
    }

    public void SwitchCam(bool isWhiteTurn)
    {

        if (isWhiteTurn)
        {
            camOne.enabled = true;
            camTwo.enabled = false;
        }
        else
        {
            camOne.enabled = false;
            camTwo.enabled = true;
        }
      
    }
}
