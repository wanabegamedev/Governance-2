using UnityEngine;

[CreateAssetMenu(fileName = "CardEvent", menuName = "DisplayText", order = 0)]
public class DisplayText : CardEvent
{
    
    public override string GetEventInfo()
    {
        return description + "\n";
    }

    public override void OnEventActivate()
    {
        return;
    }
}

