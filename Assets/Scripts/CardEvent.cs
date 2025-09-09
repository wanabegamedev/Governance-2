
using UnityEngine;

public enum ValueTypes
{
    Health,
    Happiness,
    Military,
    Economy
}

[CreateAssetMenu(fileName = "CardEvent", menuName = "Scriptable Objects/CardEvent")]
public abstract class CardEvent : ScriptableObject
{
   public string name;
   public string description;
    
    //Has to return a string
    public abstract string GetEventInfo();

    public abstract void OnEventActivate();
    
    
}
[CreateAssetMenu(fileName = "CardEvent", menuName = "DecreaseAllValues", order =0)]
public class DecreaseAllValues : CardEvent
{

    public int amount = 1;
    
    public override string GetEventInfo()
    {
        return $"Decreases all values by {amount}" + "\n";
    }

    public override void OnEventActivate()
    {
        GameManager.instance.economyValue -= amount;
        GameManager.instance.militaryValue -= amount;
        GameManager.instance.healthValue -= amount;
        GameManager.instance.popularityValue -= amount;
        
        
        
    }
    
}



