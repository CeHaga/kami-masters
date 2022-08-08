using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Fighter : MonoBehaviour
{
    public BattleManager battleManager;
    [SerializeField] protected Shapes shape;
    [SerializeField] private int maxHP;
    private int hp;

    public abstract ActionDescription attack();

    protected ActionDescription chooseAttack(int choice)
    {
        ActionDescription action;
        switch (shape)
        {
            case Shapes.TSURU:
                switch (choice)
                {
                    case 1:
                        action = new ActionDescription(
                            Actions.TSURU_ACTION1,
                            "Ação 1 do Tsuru",
                            new Lanes[] {Lanes.MID},
                            new Lanes[] {Lanes.MID}
                        );
                        return action;
                    case 2:
                        action = new ActionDescription(
                            Actions.TSURU_ACTION2,
                            "Ação 2 do Tsuru",
                            new Lanes[] {},
                            new Lanes[] {Lanes.TOP}
                        );
                        return action;
                }
                break;
            case Shapes.KARP:
                switch (choice)
                {
                    case 1:
                        action = new ActionDescription(
                            Actions.KARP_ACTION1,
                            "Ação 1 da Carpa",
                            new Lanes[] {Lanes.MID},
                            new Lanes[] {Lanes.MID}
                        );
                        return action;
                    case 2:
                        action = new ActionDescription(
                            Actions.KARP_ACTION2,
                            "Ação 2 da Carpa",
                            new Lanes[] {Lanes.BOTTOM, Lanes.TOP},
                            new Lanes[] {Lanes.MID}
                        );
                        return action;
                }
                break;
        }
        // Never happens, just to return sth
        return null;
    }

    public bool onHit(int dmg){
        hp -= dmg;
        return hp <= 0;
    }
}
