using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class ChoosePhase : MonoBehaviour
{
    [Header("First Battle")]
    public Shape firstPlayerInitialShape;
    public Shape firstEnemyInitialShape;

    [Header("Second Battle")]
    public Shape secondEnemyInitialShape;

    public void BearBattle()
    {
        BattleInformation.playerInitialShape = firstPlayerInitialShape;
        BattleInformation.enemyInitialShape = firstEnemyInitialShape;

        SceneManager.LoadScene("Battle");
    }
    public void KarpBattle()
    {
        BattleInformation.playerInitialShape = firstPlayerInitialShape;
        BattleInformation.enemyInitialShape = secondEnemyInitialShape;

        SceneManager.LoadScene("Battle");
    }

   
}
