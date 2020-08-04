using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamSwitcher : MonoBehaviour
{
    public static CamSwitcher Instance { set; get; }
    public Camera[] cameraList = new Camera[2];
   
    public void SetCameras()
    {

        cameraList[0].gameObject.SetActive(true);
        cameraList[1].gameObject.SetActive(false);
    }

    public void SwitchCam(bool isWhiteTurn)
    {
        
        if (isWhiteTurn)
        {
            cameraList[0].gameObject.SetActive(true);
            cameraList[1].gameObject.SetActive(false);
        }
        else
        {
            cameraList[0].gameObject.SetActive(false);
            cameraList[1].gameObject.SetActive(true);
            
        }
    }
}
