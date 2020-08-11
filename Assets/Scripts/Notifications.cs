using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public  class Notifications : MonoBehaviour
{
  
    public GameObject Announcment;

    private void Start()
    {
        
    }
    public void  pushSavedGame()
    {
        Announcment = Instantiate(Announcment) as GameObject;
        Announcment.SetActive(true);
    }

}
