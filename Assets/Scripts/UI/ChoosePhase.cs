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
    public Sprite firstBackground;

    [Header("Second Battle")]
    public Shape secondPlayerInitialShape;
    public Shape secondEnemyInitialShape;
    public AudioClip secondClip;
    public Sprite secondBackground;

    public void BearBattle()
    {
        BattleInformation.playerInitialShape = firstPlayerInitialShape;
        BattleInformation.enemyInitialShape = firstEnemyInitialShape;
        BattleInformation.clip = firstClip;
        BattleInformation.background = firstBackground;

        SceneManager.LoadScene("Battle");
    }
    public void KarpBattle()
    {
        BattleInformation.playerInitialShape = secondPlayerInitialShape;
        BattleInformation.enemyInitialShape = secondEnemyInitialShape;
        BattleInformation.clip = secondClip;
        BattleInformation.background = secondBackground;

        SceneManager.LoadScene("Battle");
    }

   
}
