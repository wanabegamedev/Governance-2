using UnityEngine;


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
        
        return tempDescription + "\n";
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
