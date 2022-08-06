using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFighter : Fighter
{
    public override Actions attack()
    {
        int choice = battleManager.getPlayerChoice();
        return chooseAttack(choice);
    }
}
