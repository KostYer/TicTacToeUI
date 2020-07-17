using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public Board board;
    public GameObject winnerUI;
    public GameObject[] turnShower;
    

    public int turnCount = 0;
    public bool turn = true;


    private void Awake()
    {
        board.Build(this);
       
    }

    public void SwitchTurn()
    {
        
        turnCount++;
       
       bool haveWinner = board.CheckForWinner();
       
        if (haveWinner || turnCount ==9) 
        {
          print ("we have a winner");
          StartCoroutine(EndGame (haveWinner));
         // board.ResetGame();

          return;

        }
       
        
        turn = !turn;
    }

    public string GetTurnCharacter()
    {
        return turn? "X" : "O";
    }


    private IEnumerator EndGame(bool haveWinner)
    {   
        
         //print ("Coroutine started");
         
        Text winnerLable = winnerUI.GetComponentInChildren<Text>();
        if (haveWinner)
        {
             winnerLable.text = GetTurnCharacter() + " " + "won" ;

        }
        else 
        {
          winnerLable.text = "Draw";  //"no winner ";

        }
       

        winnerUI.SetActive(true);
         board.DisableBoard();
         
         yield return new WaitForSeconds (5f);
        board.ResetGame();
        turnCount =0;
         

         winnerUI.SetActive(false);

    }


    
}
