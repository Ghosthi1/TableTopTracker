
using UnityEngine;
using TMPro;
using Unity.VisualScripting;


public class Buttons : MonoBehaviour
{
    public GameObject totalP1;
    public GameObject totalP2;
    private int round = 1;
    private int turn = 1;
    private int cp1  = 1;
    private int cp2  = 1;
    private int primary1 = 0;
    private int primary2 = 0;
    private int secondary1 = 0;
    private int secondary2 = 0;

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

    private int AddButton(TextMeshProUGUI currentText, int counter){
            counter ++;
            //coverts counter to sttring and updates game 
            currentText.text = counter.ToString();
            return counter;
    }

    public int MinusButton(TextMeshProUGUI currentText, int counter){
            counter --;
            currentText.text = counter.ToString();
            return counter;
    }

    private int LimitChecker(TextMeshProUGUI currentText,int minValue, int maxValue, int counter ){
        //retuns bool to show upper bound "true" or lower bound "false"
            //checks the bounds of the values   
            //Checks if Greater than or less than bounds

            if( counter < minValue){
                counter = minValue;
                currentText.text = minValue.ToString();
                Debug.Log("Points to low"); 
                return counter;
            }
            if(counter > maxValue){
                counter = minValue;
                currentText.text = minValue.ToString();
                Debug.Log("Points to High"); 
                return counter;
            }
            //default return 
            Debug.Log("Default"); 
            return counter;
           
    }

    public void TagChecker(GameObject Object){
        //checks the tag to appropriatly deal with buttons 
        
        if(Object.CompareTag("Turn")){
        //counter used here is turn 
            //gets the text 
            TextMeshProUGUI ObjectText = Object.GetComponent<TextMeshProUGUI>();
            
            //gest rounds object and text
            GameObject rounds = GameObject.Find("Round");
            TextMeshProUGUI roundsText = rounds.GetComponent<TextMeshProUGUI>();

            //deals with what button was pressed
            if(whatbuttonPressed){
                turn = AddButton(ObjectText, turn);            
            }
            if(!whatbuttonPressed){
                turn = MinusButton(ObjectText, turn);
            }

            if(turn > 2){
            //if higher than max value 
                round++;
                if(round > 5)
                {
                    Debug.Log("game over ");
                    Application.Quit();
                }
                else
                {
                    round = LimitChecker(roundsText, 1, 5, round);
                    //sets the text 
                    roundsText.text = "Round: " + round.ToString();
                }
                turn = LimitChecker(ObjectText, 1,2 , turn);
            }
            if(turn < 1){
                round--;
                //resets round to max and updates canvas
                turn = 2;
                ObjectText.text = turn.ToString();
                if(round < 1){
                    turn = LimitChecker(ObjectText, 1,1 , turn);
                    round = LimitChecker(ObjectText, 1,5 , round);
                }
                else {
                    round = LimitChecker(roundsText, 1, 5, round);
                    //sets the text 
                    roundsText.text = "Round: " + round.ToString();
                }
                
                turn = LimitChecker(ObjectText, 1,2 , turn);
            }

        }

        if(Object.CompareTag("CP1")){
        //counter used here is cp1 

            //gets the text 
            TextMeshProUGUI ObjectText = Object.GetComponent<TextMeshProUGUI>();

            //deals with what button was pressed
            if(whatbuttonPressed){
                cp1 = AddButton(ObjectText, cp1);       
            }
            if(!whatbuttonPressed){
                cp1 = MinusButton(ObjectText, cp1); 
            }

            cp1 = LimitChecker(ObjectText,0,5, cp1);  
        }
        
        if(Object.CompareTag("CP2")){
        //counter used here is cp2 

            //gets the text 
            TextMeshProUGUI ObjectText = Object.GetComponent<TextMeshProUGUI>();
            //deals with what button was pressed
            if(whatbuttonPressed){
                cp2 = AddButton(ObjectText, cp2);       
            }
            if(!whatbuttonPressed){
                cp2 = MinusButton(ObjectText, cp2); 
            }

            cp2 = LimitChecker(ObjectText,0,5, cp2);  
        }

        if(Object.CompareTag("Primary1")){
        //counter used here is primary1

            //gets the text 
            TextMeshProUGUI ObjectText = Object.GetComponent<TextMeshProUGUI>();
            //deals with what button was pressed
            if(whatbuttonPressed){
                primary1 = AddButton(ObjectText, primary1);       
            }
            if(!whatbuttonPressed){
                primary1 = MinusButton(ObjectText, primary1); 
            }

            primary1 = LimitChecker(ObjectText,0,100, primary1);  
            UpdateTotal(1); 
        }

        if(Object.CompareTag("Primary2")){
        //counter used here is primary2 

            //gets the text 
            TextMeshProUGUI ObjectText = Object.GetComponent<TextMeshProUGUI>();
            //deals with what button was pressed
            if(whatbuttonPressed){
                primary2 = AddButton(ObjectText, primary2);       
            }
            if(!whatbuttonPressed){
                primary2 = MinusButton(ObjectText, primary2); 
            }

            primary2 = LimitChecker(ObjectText,0,100, primary2); 
            UpdateTotal(2); 
        }
        
        if(Object.CompareTag("Secondary1")){
        //counter used here is secondary1 
            Debug.Log("Done");
            //gets the text 
            TextMeshProUGUI ObjectText = Object.GetComponent<TextMeshProUGUI>();
            //deals with what button was pressed
            if(whatbuttonPressed){
                secondary1 = AddButton(ObjectText, secondary1);       
            }
            if(!whatbuttonPressed){
                secondary1 = MinusButton(ObjectText, secondary1); 
            }

            secondary1 = LimitChecker(ObjectText,0,100, secondary1); 
            UpdateTotal(1); 
        }

        if(Object.CompareTag("Secondary2")){
        //counter used here is secondary2 

            //gets the text 
            TextMeshProUGUI ObjectText = Object.GetComponent<TextMeshProUGUI>();
            //deals with what button was pressed
            if(whatbuttonPressed){
                secondary2 = AddButton(ObjectText, secondary2);       
            }
            if(!whatbuttonPressed){
                secondary2 = MinusButton(ObjectText, secondary2); 
            }

            secondary2 = LimitChecker(ObjectText,0,100, secondary2);  
            UpdateTotal(2);
        }

    }
    
    private void UpdateTotal(int player){
        if(player == 1){
            TextMeshProUGUI player1 = totalP1.GetComponent<TextMeshProUGUI>();
            player1.text = (primary1 + secondary1).ToString();
        }
        if(player == 2){
            TextMeshProUGUI player2 = totalP2.GetComponent<TextMeshProUGUI>();
            player2.text = (primary2 + secondary2).ToString();
        }
 
    }

}
