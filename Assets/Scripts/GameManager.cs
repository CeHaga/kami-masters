using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public BattleManager battleManager;
    public Image panelImg;
    
    private int playerChoice;

    private void Awake() {
        playerChoice = 0;
    }

    public void playerAttack(int choice)
    {
        battleManager.playerAttack(choice);
    }

    public void enemyAttack(Actions enemyAction)
    {
        /* Gambiarra pra mostrar a cor */
        Color32 color = new Color32(255, 0, 255, 255);
        if ((int)enemyAction % 3 == 0)
        {
            color.b = 0;
        }
        if ((int)enemyAction % 3 == 2)
        {
            color.r = 0;
        }

        panelImg.color = color;
    }

    public void playerButtonPressed(int choice){
        playerChoice = choice;
    }

    public void confirmPlayerChoice(){
        if(playerChoice == 0) return;
        playerAttack(playerChoice);
        playerChoice = 0;
    }
}
