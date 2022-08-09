using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFighter : Fighter
{
    public override ActionDescription Attack()
    {
        int offset = Random.Range(0, 2);
        Actions choice = ActionFromChoiceOffset(offset);
        return ChooseAttack(choice);
    }
}
