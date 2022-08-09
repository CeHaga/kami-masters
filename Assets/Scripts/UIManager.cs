using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public GameManager gameManager;
    
    public void Attack1Press()
    {
        gameManager.PlayerButtonPressed(Actions.SHAPECHANGE_TSURU);
    }

    public void Attack2Press()
    {
        gameManager.PlayerButtonPressed(Actions.SHAPECHANGE_CAT);
    }

    public void Attack3Press()
    {
        gameManager.PlayerButtonPressed(Actions.SHAPECHANGE_FROG);
    }

    public void ConfirmPlayerChoice()
    {
        gameManager.ConfirmPlayerChoice();
    }
}
