using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    [Header("Managers")]
    public BattleManager battleManager;
    public AnimationManager animationManager;
    
    [Header("Scriptable Objects")]
    [SerializeField] private Shapes shapes;

    [Header("Actions UI")]
    [SerializeField] private Transform[] actionsBtn;
    private Image[] actionsBtnImage;
    private Action[] actions;

    [SerializeField] private TextMeshProUGUI actionDisplay;
    
    private Action playerChoice;

    [Header("Initial Shapes")]
    [SerializeField] private Shape playerInitialShape;
    [SerializeField] private Shape enemyInitialShape;

    private void Awake()
    {
        playerChoice = null;
    }

    private void Start()
    {
        playerInitialShape = BattleInformation.playerInitialShape;
        enemyInitialShape = BattleInformation.enemyInitialShape;

        actionsBtnImage = new Image[actionsBtn.Length];
        actions = new Action[actionsBtn.Length];
        for(int i = 0; i < actionsBtn.Length; i++)
        {
            actionsBtn[i].gameObject.SetActive(false);
            actionsBtnImage[i] = actionsBtn[i].GetComponent<Image>();
        }

        battleManager.StartBattle(playerInitialShape, enemyInitialShape);
        animationManager.SetInitialShapes(playerInitialShape, enemyInitialShape);
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

        animationManager.ChangeBattleAnimations(battleStatus);

        for(int i = 0; i < actionsBtn.Length; i++){
            actionsBtn[i].gameObject.SetActive(true);
            actions[i] = battleManager.GetPlayerShape().actions[i];
            actionsBtnImage[i].sprite = actions[i].buttonSprite;
        }

        playerChoice = null;
    }
}
