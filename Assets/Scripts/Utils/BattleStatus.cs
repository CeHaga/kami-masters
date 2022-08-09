using UnityEngine;

public class BattleStatus
{
    public Shape playerShape;
    public int playerMaxHP;
    public int playerHP;
    public Action playerAction;
    public bool playerHeal;
    public bool playerHit;
    public bool playerDead;

    public Shape enemyShape;
    public int enemyMaxHP;
    public int enemyHP;
    public Action enemyAction;
    public bool enemyHeal;
    public bool enemyHit;
    public bool enemyDead;

    public override string ToString(){
        return string.Format("== Player ==\nHP: {0}/{1}\nAction: {2}\nShape:{3}\n== Enemy ==\nHP: {4}/{5}\nAction: {6}\nShape: {7}", playerHP, playerMaxHP, playerAction.name, playerShape.name, enemyHP, enemyMaxHP, enemyAction.name, enemyShape.name);
    }
}
