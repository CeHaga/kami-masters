using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    public BattleManager battleManager;

    /*
    public GameObject action1Btn;
    public GameObject action2Btn;

    private GameObject action1Text;
    private GameObject action2Text;

    public TextMeshProUGUI actionDisplay;
    */
    private Actions playerChoice;

    private void Awake() {
        playerChoice = 0;
    }

    private void Start() {
        //action1Text = action1Btn.GetChild(0);
        //action2Text = action2Btn.GetChild(0);
    }

    public void PlayerAttack(Actions choice)
    {
        battleManager.PlayerAttack(choice);
    }

    public void EnemyAttack(ActionDescription enemyAction)
    {
        //actionDisplay.text = enemyAction.name;
    }

    public void PlayerButtonPressed(Actions choice){
        playerChoice = choice;
    }

    public void ConfirmPlayerChoice(){
        if(playerChoice == 0) return;
        PlayerAttack(playerChoice);

        //action1Text.text = 

        playerChoice = 0;
    }
}
