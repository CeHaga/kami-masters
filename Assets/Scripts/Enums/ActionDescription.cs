using System.Collections;
using System.Collections.Generic;

public class ActionDescription
{
    public Actions action;
    public string name;
    public Lanes[] laneAttack;
    public Lanes[] lanePosition;

    public ActionDescription(Actions action, string name, Lanes[] laneAttack, Lanes[] lanePosition)
    {
        action = this.action;
        name = this.name;
        laneAttack = this.laneAttack;
        lanePosition = this.lanePosition;
    }
}
