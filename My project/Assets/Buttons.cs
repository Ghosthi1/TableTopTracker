using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;
using System;
using System.Diagnostics.Tracing;

public class Buttons : MonoBehaviour
{
    public int counter = 0;
    public void AddButton(TextMeshProUGUI currentText){
            counter += 1;
            currentText.text = counter.ToString();
            LimitChecker(currentText);
    }

    public void MinusButton(TextMeshProUGUI currentText){
            counter -= 1;
            currentText.text = counter.ToString();
            LimitChecker(currentText);
    }

    private void LimitChecker(TextMeshProUGUI currentText){
            //checks the bounds of the values 
            //gets string value 
            String currentnumber = currentText.ToString();
            //converts to int 
            int.TryParse(currentnumber , out int intNumber);
            if(intNumber < 0 ){
                currentText.text = 0.ToString();
            }
    }
}
