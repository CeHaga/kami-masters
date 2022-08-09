using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFighter : Fighter
{
    public override Action Attack()
    {
        int choice = Random.Range(0, shape.actions.Length);
        Action action = shape.actions[choice];
        UseAttack(action);
        return action;
    }
}
