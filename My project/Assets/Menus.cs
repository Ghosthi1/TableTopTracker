using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menus : MonoBehaviour
{

    public GameObject start;
    public GameObject game;

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape)){
            ChangeMenu();
        }
    }

    public void ChangeMenu(){
        
    }

    public void ChangeMenuStart(){
        //changes what ui is active 
        start.SetActive(false);
        game.SetActive(true);
    }
}
