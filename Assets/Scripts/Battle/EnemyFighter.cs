using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFighter : Fighter
{
    public override ActionDescription attack()
    {
        int choice = Random.Range(1, 4);
        return chooseAttack(choice);
    }
}
