using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Fighter : MonoBehaviour
{
    public BattleManager battleManager;
    
    protected Shape shape;
    
    private int maxHP;
    private int hp;

    [Header("Shape Change")]
    public int shapeChangeCooldown = 3;
    private int cooldown;

    public abstract Action Attack();

    public void Create(Shape shape)
    {
        this.shape = shape;

        maxHP = shape.maxHP;
        hp = maxHP;

        cooldown = 0;
    }

    protected bool UseAttack(Action action)
    {
        if(action.shapeChange != null){
            if(cooldown != 0) return false;
        }
        
        if(cooldown > 0) cooldown--;

        ShapeChange(action.shapeChange);
        Heal(action.hpHeal);

        return true;
    }

    public bool OnHit(int dmg)
    {
        hp -= dmg;
        return hp <= 0;
    }

    public void Heal(int heal)
    {
        if(hp < maxHP) hp += heal;
    }

    public void ShapeChange(Shape newShape)
    {
        if(newShape == null) return;
        shape = newShape;

        cooldown = shapeChangeCooldown;
    }

    public Shape GetShape()
    {
        return shape;
    }

    public int GetMaxHP()
    {
        return maxHP;
    }

    public int GetHP()
    {
        return hp;
    }

    public int GetCooldown()
    {
        return cooldown;
    }
}
