
using UnityEngine;

public class Board : MonoBehaviour
{
   public GameObject cellPrefab;
   public Cell[] cells = new Cell[9];


     
    public void Build(GameController _controller)
    {

        for (int i = 0; i < cells.Length; i++)
        {
            GameObject newCell = Instantiate(cellPrefab , this.transform);

            cells[i] = newCell.GetComponent<Cell>();
            cells[i].controller = _controller;
          // cells[i].text.text = "";
           
        }
        print("Build finished");
    }


    public bool CheckForWinner()
    {
       
        int i = 0;

        //horizontal check
         for (i=0; i <= 6; i +=3)
        {
            bool checkResult = CheckValues(i, i + 1 );
            if ( !checkResult)
            {
                
                continue; }

            
              checkResult = CheckValues(i, i + 2);
            if ( !checkResult)
            {
               //print("1nd CheckValues started");
                continue; }
                
            return true; 
        } 
 
        /// vertical
       for (i = 0; i <= 2; i ++)
       
        {
            if ( !CheckValues(i, i + 3))
                continue;

            if (  !CheckValues(i, i + 6))
                continue;
            return true;
        }
          
       ///2 diagonals
          if ( CheckValues(0, 4) && CheckValues(0, 8))
                return true;


           if ( CheckValues(2, 4) && CheckValues(2, 6))
                return true;      
    

        return false;

 

    }

    private bool CheckValues(int firstIndex, int secondIndex)
    {
        
        //if empty cells
        if (cells[firstIndex].text.text == string.Empty ) { return false; }

        if (cells[secondIndex].text.text == string.Empty) { return false; }


          return (cells[firstIndex].text.text == cells[secondIndex].text.text) ? true : false;

 
         
     
    }
    
    public void DisableBoard()
    {
      foreach (var cell in cells)
     {
      cell.button.interactable = false;
    cell.text.text = string.Empty;

     }

    }
     public void ResetGame()
    {
     foreach (var cell in cells)
     {
      cell.button.interactable = true;
      

     }

    }
}
