using System;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;



public class GameManager : MonoBehaviour
{

    
    
   public static GameManager instance;
   
   
   public Card currentSelectedCard;

   [Header("Values")] 
   
   public int healthValue = 100;
   
    public int economyValue = 100;
    
    public int militaryValue = 100;

    public int popularityValue = 100;

    public int politicalPower = 100;
    
    [SerializeField] GameObject cardPrefab;
    
    [SerializeField] Vector3 cardStartPosition;

    [Header("Decks")] 
    
    public List<CardData> cardsInDeck;
    
    public List<CardData> cardDiscardDeck;
    
    
  
    
    
    
    

    
    

   private void Awake()
   {
      if (instance != null)
      {
        Destroy(gameObject);
      }
      else
      {
          instance = this;
          DontDestroyOnLoad(gameObject);
      }
      
      SpawnNewCard();
      
   }

   private void Update()
   {
       if (healthValue <= 0 || militaryValue <= 0 || popularityValue <= 0 || economyValue <= 0 || politicalPower <= 0)
       {
           EndGame();
       }
   }


   public void SpawnNewCard()
   {
       var tempCard = Instantiate(cardPrefab, cardStartPosition, quaternion.identity);

       tempCard.GetComponent<Card>().cardData = SelectTopCard();
   }

   public void RemoveCard(CardData cardDataRef)
   {
       if (!cardDataRef.oneTime)
       {
           cardDiscardDeck.Add(cardDataRef);
       }
    
       cardsInDeck.Remove(cardDataRef);
       
   }

   public CardData SelectTopCard()
   {
       
       //Reshuffle the discard deck if 
       if (cardsInDeck.Count == 0)
       {
           cardsInDeck = cardDiscardDeck;
           cardDiscardDeck = new();
           
         //Shuffle(cardsInDeck);
           
           return cardsInDeck[0];
       }
      
       
       return cardsInDeck[0];
   }

   public void EndGame()
   {
       print("Game Over");

       SceneManager.LoadScene(2);
   }
   
   public static void Shuffle<T>( IList<T> ts) {
       var count = ts.Count;
       var last = count - 1;
       for (var i = 0; i < last; ++i) {
           var r = UnityEngine.Random.Range(i, count);
           var tmp = ts[i];
           ts[i] = ts[r];
           ts[r] = tmp;
       }
   }
   
   
   
   
 

}

    