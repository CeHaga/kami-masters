using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleManager : MonoBehaviour
{
    public GameManager gameManager;
    public PlayerFighter playerFighter;
    public EnemyFighter enemyFighter;

    private Action playerChoice;

    private Action playerAction;
    private Action enemyAction;

    public void StartBattle(Shape playerInitialShape, Shape enemyInitialShape){
        enemyFighter.Create(enemyInitialShape);
        enemyAction = enemyFighter.Attack();
        gameManager.EnemyAttack(enemyAction);

        playerFighter.Create(playerInitialShape);
    }

    public Action GetPlayerChoice()
    {
        return playerChoice;
    }

    public BattleStatus PlayerAttack(Action action)
    {
        playerChoice = action;

        playerAction = playerFighter.Attack();
        if(!playerAction) return null;

        BattleStatus battleStatus = new BattleStatus();        
        
        battleStatus.playerDead = false;
        battleStatus.enemyDead = false;
        battleStatus.playerHit = false;
        battleStatus.enemyHit = false;
        
        battleStatus.playerHeal = playerAction.hpHeal > 0;
        battleStatus.enemyHeal = playerAction.hpHeal > 0;
        
        // Player attack
        if(CheckAttack(playerAction.lanesAttack, enemyAction.lanesHitbox)){
            battleStatus.enemyHit = true;
            battleStatus.enemyDead = enemyFighter.OnHit(1);
        }

        // Enemy attack
        if(CheckAttack(enemyAction.lanesAttack, playerAction.lanesHitbox)){
            battleStatus.playerHit = true;
            battleStatus.playerDead = playerFighter.OnHit(1);
        }
        
        battleStatus.playerShape = playerFighter.GetShape();
        battleStatus.playerMaxHP = playerFighter.GetMaxHP();
        battleStatus.playerHP = playerFighter.GetHP();
        battleStatus.playerAction = playerAction;
        battleStatus.enemyShape = enemyFighter.GetShape();
        battleStatus.enemyMaxHP = enemyFighter.GetMaxHP();
        battleStatus.enemyHP = enemyFighter.GetHP();
        battleStatus.enemyAction = enemyAction;

        enemyAction = enemyFighter.Attack();
        gameManager.EnemyAttack(enemyAction);

        return battleStatus;
    }

    private bool CheckAttack(Lanes[] laneAttack, Lanes[] lanePosition){
        foreach (Lanes lane in laneAttack)
        {
            if(Array.Exists(lanePosition, element => element == lane)) return true;
        }

        return false;
    }

    public Shape GetPlayerShape(){
        return playerFighter.GetShape();
    }
}
