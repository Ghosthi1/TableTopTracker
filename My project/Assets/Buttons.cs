using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;
using System;
using System.Diagnostics.Tracing;

public class Buttons : MonoBehaviour
{
    private int counter = 0;
    public void AddButton(TextMeshProUGUI currentText){
            counter += 1;
            Text oldText = currentText.GetComponent<Text>();
            currentText.text = oldText + " " + counter.ToString();
    }

    public void MinusButton(TextMeshProUGUI text){

    }
}
