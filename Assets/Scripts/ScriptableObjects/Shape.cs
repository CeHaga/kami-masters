using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Shape", menuName = "Shape")]
public class Shape : ScriptableObject
{
    public new string name;
    
    public Action action1;
    public Action action2;
}
