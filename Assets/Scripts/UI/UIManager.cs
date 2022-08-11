using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [Header("Managers")]
    public GameManager gameManager;

    [Header("Hearts")]
    [SerializeField] private SpriteRenderer[] playerHearts;
    [SerializeField] private SpriteRenderer[] enemyHearts;
    [SerializeField] private Sprite fullHeart;
    [SerializeField] private Sprite emptyHeart;
    
    [Header("Signs")]
    [SerializeField] private GameObject[] warningSigns;
    [SerializeField] private GameObject[] placeSigns;

    private void Awake()
    {
        ResetSigns();    
    }
    
    public void ChangeTsuruPress()
    {
        gameManager.PlayerButtonPressed(UIActions.SHAPECHANGE_TSURU);
    }

    public void ChangeCatPress()
    {
        gameManager.PlayerButtonPressed(UIActions.SHAPECHANGE_CAT);
    }

    public void ChangeFrogPress()
    {
        gameManager.PlayerButtonPressed(UIActions.SHAPECHANGE_FROG);
    }

    public void Attack1Press()
    {
        gameManager.PlayerButtonPressed(UIActions.ATTACK1);
    }

    public void Attack2Press()
    {
        gameManager.PlayerButtonPressed(UIActions.ATTACK2);
    }

    public void ConfirmPlayerChoice()
    {
        gameManager.ConfirmPlayerChoice();
    }

    public void UpdateUI(BattleStatus battleStatus){
        SetHealth(playerHearts, battleStatus.playerHP);
        SetHealth(enemyHearts, battleStatus.enemyHP);
    }

    private void SetHealth(SpriteRenderer[] hearts, int hp){
        Debug.Log(hp);
        for(int i = 0; i < hp; i++){
            hearts[i].sprite = fullHeart;
        }
        for(int i = hp; i < hearts.Length; i++){
            hearts[i].sprite = emptyHeart;
        }
    }

    public void SetSigns(Action enemyAction){
        ResetSigns();

        foreach(Lanes lane in enemyAction.lanesAttack){
            warningSigns[(int)lane].SetActive(true);
        }
        
        foreach(Lanes lane in enemyAction.lanesHitbox){
            placeSigns[(int)lane].SetActive(true);
        }
    }

    private void ResetSigns(){
        foreach(GameObject sign in warningSigns){
            sign.SetActive(false);
        }
        foreach(GameObject sign in placeSigns){
            sign.SetActive(false);
        }
    }
}
