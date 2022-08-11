using UnityEngine;

[CreateAssetMenu(fileName = "New Shape", menuName = "Shape")]
public class Shape : ScriptableObject
{
    public new string name;

    public int maxHP;
    
    public Action[] actions;

    [Header("Lanes")]
    public Lanes[] lanesPosition;

    [Header("Animations")]
    public AnimationClip idle;
    public AnimationClip hit;
    public AnimationClip dead;
    public AnimationClip unfold;
}
