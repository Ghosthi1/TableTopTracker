using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;
using System;
using System.Diagnostics.Tracing;
using UnityEngine.UIElements;

public class Buttons : MonoBehaviour
{
    private int counter = 1;
    private int round = 1;
    private TextMeshProUGUI currentTexts ;

    public void AddButton(TextMeshProUGUI currentText){
            counter ++;
            //coverts counter to sttring and updates game 
            currentText.text = counter.ToString();
            //global variable
            currentTexts = currentText;
    }

    public void MinusButton(TextMeshProUGUI currentText){
            counter --;
            currentText.text = counter.ToString();
            //global variable
            currentTexts = currentText;
    }

    private bool LimitChecker(TextMeshProUGUI currentText,int minValue, int maxValue){
        //retuns bool to show upper bound "true" or lower bound "false"
            //checks the bounds of the values   
            //Checks if Greater than or less than bounds
            if( counter < minValue){
                counter = minValue;
                currentText.text = minValue.ToString();
                Debug.Log("Points to low"); 
                return false;
            }
            if(counter > maxValue){
                counter = minValue;
                currentText.text = minValue.ToString();
                Debug.Log("Points to High"); 
                return true;
            }
            //default return 
            return false;
           
    }

    public void TagChecker(GameObject button){
        //checks the tag to appropriatly deal with buttons 
        
        if(button.CompareTag("Turn")){
            if(LimitChecker(currentTexts, 1,2)){
            //if higher than max value 
                round++;
                if(round > 5)
                {
                    Debug.Log("game over ");
                    Application.Quit();
                }
                else
                {
                    //gest rounds object and text
                    GameObject rounds = GameObject.Find("Round");
                    TextMeshProUGUI roundsText = rounds.GetComponent<TextMeshProUGUI>();
                    //sets the text 
                    roundsText.text = "Round: " + round.ToString();
                }

            }
        }
    }

}
