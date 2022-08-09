using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Fighter : MonoBehaviour
{
    public BattleManager battleManager;
    
    private Shapes shape;
    
    private int maxHP;
    private int hp;

    private int shapeChangeCooldown;
    private int cooldown;

    public abstract ActionDescription Attack();

    public void Create(Shapes shape, int maxHP=3, int shapeChangeCooldown=3){
        this.shape = shape;

        this.maxHP = maxHP;
        hp = maxHP;

        this.shapeChangeCooldown = shapeChangeCooldown;
        cooldown = 0;
    }

    protected ActionDescription ChooseAttack(Actions choice)
    {
        ActionDescription action;
        // Doesnt matter the shape, it can change 
        switch(choice){
            case Actions.SHAPECHANGE_TSURU:
                action = new ActionDescription(
                    choice,
                    "Transformação Tsuru",
                    new Lanes[] {},
                    new Lanes[] {Lanes.MID}
                );
                shape = Shapes.TSURU;
                return action;
            case Actions.SHAPECHANGE_CAT:
                action = new ActionDescription(
                    choice,
                    "Transformação Neko",
                    new Lanes[] {},
                    new Lanes[] {Lanes.BOTTOM, Lanes.MID}
                );
                shape = Shapes.CAT;
                return action;
            case Actions.SHAPECHANGE_FROG:
                action = new ActionDescription(
                    choice,
                    "Transformação Kaeru",
                    new Lanes[] {},
                    new Lanes[] {Lanes.BOTTOM}
                );
                shape = Shapes.FROG;
                return action;
        }
        switch (shape)
        {
            case Shapes.TSURU:
                switch (choice)
                {
                    case Actions.TSURU_ACTION1:
                        action = new ActionDescription(
                            choice,
                            "Ação 1 do Tsuru",
                            new Lanes[] {Lanes.MID},
                            new Lanes[] {Lanes.MID}
                        );
                        return action;
                    case Actions.TSURU_ACTION2:
                        action = new ActionDescription(
                            choice,
                            "Ação 2 do Tsuru",
                            new Lanes[] {},
                            new Lanes[] {Lanes.TOP}
                        );
                        return action;
                }
                break;
            case Shapes.CAT:
                switch (choice)
                {
                    case Actions.CAT_ACTION1:
                        action = new ActionDescription(
                            choice,
                            "Ação 1 do Gato",
                            new Lanes[] {Lanes.BOTTOM, Lanes.MID},
                            new Lanes[] {Lanes.BOTTOM, Lanes.MID}
                        );
                        return action;
                    case Actions.CAT_ACTION2:
                        action = new ActionDescription(
                            choice,
                            "Ação 2 do Gato",
                            new Lanes[] {},
                            new Lanes[] {Lanes.BOTTOM, Lanes.MID}
                        );
                        Heal(1);
                        return action;
                }
                break;
            case Shapes.FROG:
                switch (choice)
                {
                    case Actions.FROG_ACTION1:
                        action = new ActionDescription(
                            choice,
                            "Ação 1 do Sapo",
                            new Lanes[] {Lanes.BOTTOM},
                            new Lanes[] {Lanes.BOTTOM}
                        );
                        return action;
                    case Actions.FROG_ACTION2:
                        action = new ActionDescription(
                            choice,
                            "Ação 2 do Sapo",
                            new Lanes[] {},
                            new Lanes[] {Lanes.MID}
                        );
                        return action;
                }
                break;
            case Shapes.KARP:
                switch (choice)
                {
                    case Actions.KARP_ACTION1:
                        action = new ActionDescription(
                            choice,
                            "Ação 1 da Carpa",
                            new Lanes[] {Lanes.MID},
                            new Lanes[] {Lanes.MID}
                        );
                        return action;
                    case Actions.KARP_ACTION2:
                        action = new ActionDescription(
                            choice,
                            "Ação 2 da Carpa",
                            new Lanes[] {Lanes.BOTTOM, Lanes.TOP},
                            new Lanes[] {Lanes.MID}
                        );
                        return action;
                }
                break;
        }

        // Invalid action
        return null;
    }

    public bool OnHit(int dmg){
        hp -= dmg;
        // Return if dead
        return hp <= 0;
    }

    public void Heal(int heal){
        if(hp < maxHP) hp += heal;
    }

    protected Actions ActionFromChoiceOffset(int offset){
        return (Actions)((int)shape * 10 + offset);
    }
}
