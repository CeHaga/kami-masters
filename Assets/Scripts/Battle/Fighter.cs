using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Fighter : MonoBehaviour
{
    public BattleManager battleManager;
    [SerializeField] protected Shapes shape;

    public abstract Actions attack();

    protected Actions chooseAttack(int choice)
    {
        switch (shape)
        {
            case Shapes.SHAPE1:
                switch (choice)
                {
                    case 1:
                        return Actions.SHAPE1_ACTION1;
                    case 2:
                        return Actions.SHAPE1_ACTION2;
                    case 3:
                        return Actions.SHAPE1_ACTION3;
                }
                break;
            case Shapes.SHAPE2:
                switch (choice)
                {
                    case 1:
                        return Actions.SHAPE2_ACTION1;
                    case 2:
                        return Actions.SHAPE2_ACTION2;
                    case 3:
                        return Actions.SHAPE2_ACTION3;
                }
                break;
            case Shapes.SHAPE3:
                switch (choice)
                {
                    case 1:
                        return Actions.SHAPE3_ACTION1;
                    case 2:
                        return Actions.SHAPE3_ACTION2;
                    case 3:
                        return Actions.SHAPE3_ACTION3;
                }
                break;
        }
        // Never happens, just to return sth
        return Actions.SHAPE1_ACTION1;
    }
}
