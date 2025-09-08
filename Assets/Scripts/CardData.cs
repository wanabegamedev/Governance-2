using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "CardData", menuName = "Scriptable Objects/CardData")]
public class CardData : ScriptableObject
{
    public string cardTitle = "Default Bill Title";
    
    public string cardDescription = "Default Bill Description";

    public Sprite cardImage;

    public List<CardEvent> OnAcceptEvents;
    
    public List<CardEvent> OnRejectEvents;
    

}
    
