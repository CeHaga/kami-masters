using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFighter : Fighter
{
    public override Action Attack()
    {
        Action choice = battleManager.GetPlayerChoice();
        bool validAttack = UseAttack(choice);

        if(!validAttack) return null;
        return choice;
    }
}
