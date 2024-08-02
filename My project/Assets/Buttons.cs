using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;
using System;
using System.Diagnostics.Tracing;
using UnityEngine.UIElements;
using System.Runtime.Serialization.Json;

public class Buttons : MonoBehaviour
{

    private int round = 1;
    public int turn = 1;
    public int cp1  = 1;
    private int cp2  = 1;

    //plus for true neg for false 
    private bool whatbuttonPressed;

    public void ButtonPressed(GameObject button){
        //gets the button pressed 
        if(button.CompareTag("Plus")){
            whatbuttonPressed = true;
        }
        if(button.CompareTag("Negative")){
            whatbuttonPressed = false;
        }
    }

    private void AddButton(TextMeshProUGUI currentText, ref int correctCounter){
            correctCounter ++;
            //coverts counter to sttring and updates game 
            currentText.text = correctCounter.ToString();
    }

    public void MinusButton(TextMeshProUGUI currentText, ref int correctCounter){
            correctCounter --;
            currentText.text = correctCounter.ToString();
    }

    private bool LimitChecker(TextMeshProUGUI currentText,int minValue, int maxValue, ref int correctCounter ){
        //retuns bool to show upper bound "true" or lower bound "false"
            //checks the bounds of the values   
            //Checks if Greater than or less than bounds
            if( correctCounter < minValue){
                correctCounter = minValue;
                currentText.text = minValue.ToString();
                Debug.Log("Points to low"); 
                return false;
            }
            if(correctCounter > maxValue){
                correctCounter = minValue;
                currentText.text = minValue.ToString();
                Debug.Log("Points to High"); 
                return true;
            }
            //default return 
            return false;
           
    }

    public void TagChecker(GameObject Object){
        //checks the tag to appropriatly deal with buttons 
        
        if(Object.CompareTag("Turn")){
        //counter used here is turn 
            //gets the text 
            TextMeshProUGUI ObjectText = Object.GetComponent<TextMeshProUGUI>();

            //deals with what button was pressed
            if(whatbuttonPressed){
                AddButton(ObjectText, ref turn);
            }
            if(!whatbuttonPressed){
                MinusButton(ObjectText, ref turn);
            }

            if(LimitChecker(ObjectText, 1,2 , ref turn)){
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

        if(Object.CompareTag("CP1")){
        //counter used here is cpCount1 

            //gets the text 
            TextMeshProUGUI ObjectText = Object.GetComponent<TextMeshProUGUI>();
            //deals with what button was pressed
            if(whatbuttonPressed){
                AddButton(ObjectText, ref turn);
            }
            if(!whatbuttonPressed){
                MinusButton(ObjectText, ref turn);
            }

            if(LimitChecker(ObjectText,0,5, ref cp1)){

            }
        }
        


    }

}
