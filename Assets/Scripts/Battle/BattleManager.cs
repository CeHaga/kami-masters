using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleManager : MonoBehaviour
{
    public GameManager gameManager;
    public PlayerFighter playerFighter;
    public EnemyFighter enemyFighter;

    private int playerChoice;

    private Actions playerAction;
    private Actions enemyAction;

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

        Debug.Log("Player used " + playerAction.ToString() + " and Enemy used " + enemyAction.ToString());

        enemyAction = enemyFighter.attack();
        gameManager.enemyAttack(enemyAction);
    }
}
