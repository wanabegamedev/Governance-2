
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
        return $"Decreases all values by {amount}";
    }

    public override void OnEventActivate()
    {
        GameManager.instance.economyValue -= amount;
        GameManager.instance.militaryValue -= amount;
        GameManager.instance.healthValue -= amount;
        GameManager.instance.popularityValue -= amount;
        
        
        
    }
    
}

[CreateAssetMenu(fileName = "CardEvent", menuName = "DisplayText", order = 0)]
public class DisplayText : CardEvent
{
    
    public override string GetEventInfo()
    {
        return description;
    }

    public override void OnEventActivate()
    {
      return;
    }
}


[CreateAssetMenu(fileName = "CardEvent", menuName = "DecreaseValue", order = 0)]
public class ChangeValue : CardEvent
{
    public ValueTypes valueToChange;
    
    
    public int changeAmount;
    public override string GetEventInfo()
    {
        string tempDescription = "";
        
        switch (valueToChange)
        {
            case ValueTypes.Economy:
                tempDescription = $"Changes economy by: {changeAmount}"; 
                break;
            
            case ValueTypes.Happiness:
                tempDescription = $"Changes happiness by: {changeAmount}"; 

                break;
            
            case ValueTypes.Health:
                tempDescription = $"Changes health services by: {changeAmount}"; 
                break;
            
            case ValueTypes.Military:
                tempDescription = $"Changes military by: {changeAmount}"; 
                break;
        }
        
        return description;
    }

    public override void OnEventActivate()
    {
        switch (valueToChange)
        {
            case ValueTypes.Economy:
                GameManager.instance.economyValue += changeAmount;
                break;
            
            case ValueTypes.Happiness:
                GameManager.instance.popularityValue += changeAmount;
                break;
            
            case ValueTypes.Health:
                GameManager.instance.healthValue += changeAmount;
                break;
            
            case ValueTypes.Military:
                GameManager.instance.militaryValue += changeAmount;
                break;
        }
    }
}

