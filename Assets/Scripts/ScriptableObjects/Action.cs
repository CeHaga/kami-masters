using UnityEngine;

[CreateAssetMenu(fileName = "New Action", menuName = "Action")]
public class Action : ScriptableObject
{
    public new string name;

    public Lanes[] laneAttack;
    public Lanes[] lanePosition;

    public int hpHeal;

    public Shape shapeChange;
}
