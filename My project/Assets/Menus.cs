using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menus : MonoBehaviour
{

    public GameObject start;
    public GameObject game;
    public GameObject pause;

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape)){
            //if escape pressed open pause menu
            bool active = true;
            ChangeMenuPause(active);
            while(active){
                if(Input.GetKeyDown(KeyCode.Escape)){
                    active = false;
                    ChangeMenuPause(active);
                }
            }
        }
    }

    public void ChangeMenuPause(bool active){
        if(active){
            start.SetActive(false);
            game.SetActive(false);
            pause.SetActive(true);
        }
        if(!active){

        }
    }

    public void ChangeMenuStart(){
        //changes what ui is active 
        start.SetActive(false);
        game.SetActive(true);
    }
}
