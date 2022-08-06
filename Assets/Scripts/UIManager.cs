using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public GameManager gameManager;
    public void attack1Press()
    {
        gameManager.playerButtonPressed(1);
    }

    public void attack2Press()
    {
        gameManager.playerButtonPressed(2);
    }

    public void attack3Press()
    {
        gameManager.playerButtonPressed(3);
    }

    public void confirmPlayerChoice()
    {
        gameManager.confirmPlayerChoice();
    }
}
