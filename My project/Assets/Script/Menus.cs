using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Menus : MonoBehaviour
{

    public GameObject start;
    public GameObject game;
    public GameObject pause;
    bool active = false;

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape)){
            if(active == true){
                ChangeMenuPause(active);
                active = false;
            }
            else if(active == false){
                //if escape pressed open pause menu
                Debug.Log("Escape"+ active);
                ChangeMenuPause(active);
                active = true;
            }
        }

    }


    private void ChangeMenuPause(bool actives){
        if(actives){
            Debug.Log("Pause");
            start.SetActive(false);
            game.SetActive(false);
            pause.SetActive(true);
        }
        if(!actives){
            Debug.Log("Game");
            start.SetActive(false);
            game.SetActive(true);
            pause.SetActive(false);
        }
    }

    private void ChangeMenuStart(){
        //changes what ui is active 
        start.SetActive(false);
        game.SetActive(true);
    }
}
