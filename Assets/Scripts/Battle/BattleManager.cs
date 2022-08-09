using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleManager : MonoBehaviour
{
    public GameManager gameManager;
    public PlayerFighter playerFighter;
    public EnemyFighter enemyFighter;

    private Actions playerChoice;

    private ActionDescription playerAction;
    private ActionDescription enemyAction;

    private void Start()
    {
        enemyFighter.Create(Shapes.KARP);
        enemyAction = enemyFighter.Attack();
        gameManager.EnemyAttack(enemyAction);
    }

    public Actions GetPlayerChoice()
    {
        return playerChoice;
    }

    public void PlayerAttack(Actions action)
    {
        playerChoice = action;
        playerAction = playerFighter.Attack();

        if(playerAction == null){
            Debug.Log("Invalid action");
            return;
        }

        Debug.Log("Player used " + playerAction.name + " and Enemy used " + enemyAction.name);
        
        // Player attack
        if(CheckAttack(playerAction.laneAttack, enemyAction.lanePosition)){
            enemyFighter.OnHit(1);
        }

        // Enemy attack
        if(CheckAttack(enemyAction.laneAttack, playerAction.lanePosition)){
            playerFighter.OnHit(1);
        }

        enemyAction = enemyFighter.Attack();
        gameManager.EnemyAttack(enemyAction);
    }

    private bool CheckAttack(Lanes[] laneAttack, Lanes[] lanePosition){
        foreach (Lanes lane in laneAttack)
        {
            if(Array.Exists(lanePosition, element => element == lane)) return true;
        }

        return false;
    }
}
