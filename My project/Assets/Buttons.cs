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

    private void Buttonpressed(TextMeshProUGUI currentText){
            //main manager
            LimitChecker(currentText);
            
    }
    public void AddButton(TextMeshProUGUI currentText){
            counter += 1;
            currentText.text = counter.ToString();
            Buttonpressed(currentText);
    }

    public void MinusButton(TextMeshProUGUI currentText){
            counter -= 1;
            currentText.text = counter.ToString();
            Buttonpressed(currentText);
    }

    private void LimitChecker(TextMeshProUGUI currentText){
            //checks the bounds of the values 
            //gets string value 
            String currentnumber = currentText.text; 
            //converts to a int and compares 
            if(int.Parse(currentnumber) < 0){
                counter = 0;
                currentText.text = "0";
                Debug.Log("Points to low"); 
            }
    }

    public void TagChecker(GameObject button){
        //checks the tag to appropriatly deal with buttons 
        
        if(button.CompareTag("Plus")){
            Debug.Log("Plus"); 
        }
        if(button.CompareTag("Negative")){
            Debug.Log("Minus"); 
        }
    }

}
