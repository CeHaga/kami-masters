using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFighter : Fighter
{
    public override ActionDescription attack()
    {
        int choice = battleManager.getPlayerChoice();
        return chooseAttack(choice);
    }
}
