using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleManager : MonoBehaviour
{
    public GameManager gameManager;
    public PlayerFighter playerFighter;
    public EnemyFighter enemyFighter;

    private int playerChoice;

    private ActionDescription playerAction;
    private ActionDescription enemyAction;

    private void Start()
    {
        enemyAction = enemyFighter.attack();
        gameManager.enemyAttack(enemyAction);
    }

    public int getPlayerChoice()
    {
        return playerChoice;
    }

    public void playerAttack(int choice)
    {
        playerChoice = choice;
        playerAction = playerFighter.attack();

        Debug.Log("Player used " + playerAction.name + " and Enemy used " + enemyAction.name);
        
        // Player attack
        if(checkAttack(playerAction.laneAttack, enemyAction.lanePosition)){

        }

        // Enemy attack
        if(checkAttack(enemyAction.laneAttack, playerAction.lanePosition)){

        }

        enemyAction = enemyFighter.attack();
        gameManager.enemyAttack(enemyAction);
    }

    private bool checkAttack(Lanes[] laneAttack, Lanes[] lanePosition){
        foreach (Lanes lane in laneAttack)
        {
            if(Array.Exists(lanePosition, element => element == lane)) return true;
        }

        return false;
    }
}
