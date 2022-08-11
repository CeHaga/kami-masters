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
    public AudioClip firstClip;

    [Header("Second Battle")]
    public Shape secondPlayerInitialShape;
    public Shape secondEnemyInitialShape;
    public AudioClip secondClip;

    public void BearBattle()
    {
        BattleInformation.playerInitialShape = firstPlayerInitialShape;
        BattleInformation.enemyInitialShape = firstEnemyInitialShape;
        BattleInformation.clip = firstClip;

        SceneManager.LoadScene("Battle");
    }
    public void KarpBattle()
    {
        BattleInformation.playerInitialShape = secondPlayerInitialShape;
        BattleInformation.enemyInitialShape = secondEnemyInitialShape;
        BattleInformation.clip = secondClip;

        SceneManager.LoadScene("Battle");
    }

   
}
