using UnityEngine;

[CreateAssetMenu(fileName = "New Action", menuName = "Action")]
public class Action : ScriptableObject
{
    public new string name;

    public Lanes[] lanesAttack;
    public Lanes[] lanesPosition;
    public Lanes[] lanesHitbox;

    public int hpHeal;

    public bool returnAfter;

    public Shape shapeChange;

    public AnimationClip animation;

    public Sprite buttonSprite;
}
