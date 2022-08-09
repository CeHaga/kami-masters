using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFighter : Fighter
{
    public override ActionDescription Attack()
    {
        Actions choice = battleManager.GetPlayerChoice();
        return ChooseAttack(choice);
    }
}
