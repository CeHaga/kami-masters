using UnityEngine;

[CreateAssetMenu(fileName = "New Shape", menuName = "Shape")]
public class Shape : ScriptableObject
{
    public new string name;

    public int maxHP;
    
    public Action[] actions;
}
