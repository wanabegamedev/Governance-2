
using UnityEngine;

[CreateAssetMenu(fileName = "CardEvent", menuName = "Scriptable Objects/CardEvent")]
public abstract class CardEvent : ScriptableObject
{
    public abstract string GetEventInfo();

    public abstract void OnEventActivate();
    
    
}



