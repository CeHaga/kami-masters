using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public GameManager gameManager;
    
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
}
