using System;
using UnityEngine;

public class GameManager : MonoBehaviour
{

   public static GameManager instance;
   
   
   public Card currentSelectedCard;

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
      
   }

   
 

}

    