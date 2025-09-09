using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Deck", menuName = "Scriptable Objects/Deck")]
public class Deck : ScriptableObject
{
    public List<Card> cardsInDeck;
    
    [Header("Immediately added cards")]
    public List<Card> cardsInDeckImmediate;
    
    
}
