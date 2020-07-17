using UnityEngine;
using UnityEngine.UI;

public class Cell : MonoBehaviour
{
    public Button button;
    public Text text;
    public GameController controller;


    public void Fill()
    {
        button.interactable = false;
        text.text = controller.GetTurnCharacter();

        controller.SwitchTurn();
    }


}