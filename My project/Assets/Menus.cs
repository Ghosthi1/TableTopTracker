using System;
using System.Collections;
using System.Collections.Generic;
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
        if(Input.GetKeyUp(KeyCode.Escape) && active == false){
            //if escape pressed open pause menu
            active = true;
            ChangeMenuPause(active);
        }
        if(Input.GetKeyUp(KeyCode.Escape) && active == true){
            active = false;
            ChangeMenuPause(active);
        }

    }

    public void ChangeMenuPause(bool active){
        if(active == true){
            start.SetActive(false);
            game.SetActive(false);
            pause.SetActive(true);
        }
        if(active == false){
            start.SetActive(false);
            game.SetActive(true);
            pause.SetActive(false);
        }
    }

    public void ChangeMenuStart(){
        //changes what ui is active 
        start.SetActive(false);
        game.SetActive(true);
    }
}
