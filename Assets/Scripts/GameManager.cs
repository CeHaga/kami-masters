using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    [Header("Managers")]
    public BattleManager battleManager;
    
    [Header("Scriptable Objects")]
    public Shapes shapes;

    [Header("Actions in Battle")]
    public Transform[] actionsBtn;
    private Action[] actions;
    private Text[] actionsText;

    public TextMeshProUGUI actionDisplay;
    
    private Action playerChoice;

    private void Awake()
    {
        playerChoice = null;
    }

    private void Start()
    {
        actionsText = new Text[actionsBtn.Length];
        actions = new Action[actionsBtn.Length];
        for(int i = 0; i < actionsBtn.Length; i++)
        {
            actionsText[i] = actionsBtn[i].GetComponentInChildren<Text>();
            actionsBtn[i].gameObject.SetActive(false);
        }
    }

    public void EnemyAttack(Action enemyAction)
    {
        actionDisplay.text = "Enemy will use " + enemyAction.name;
    }

    public void PlayerButtonPressed(UIActions choice)
    {
        switch (choice)
        {
            case UIActions.SHAPECHANGE_TSURU:
                playerChoice = shapes.shapeChangeTsuru;
                break;
            case UIActions.SHAPECHANGE_CAT:
                playerChoice = shapes.shapeChangeCat;
                break;
            case UIActions.SHAPECHANGE_FROG:
                playerChoice = shapes.shapeChangeFrog;
                break;
            case UIActions.ATTACK1:
                playerChoice = actions[0];
                break;
            case UIActions.ATTACK2:
                playerChoice = actions[1];
                break;
            default:
                playerChoice = null;
                break;
        }
    }

    public void ConfirmPlayerChoice()
    {
        if(playerChoice == null) return;
        BattleStatus battleStatus = battleManager.PlayerAttack(playerChoice);

        if(battleStatus == null) return;

        Debug.Log(battleStatus);

        for(int i = 0; i < actionsBtn.Length; i++){
            actionsBtn[i].gameObject.SetActive(true);
            actions[i] = battleManager.GetPlayerShape().actions[i];
            actionsText[i].text = actions[i].name;
        }

        playerChoice = null;
    }
}
