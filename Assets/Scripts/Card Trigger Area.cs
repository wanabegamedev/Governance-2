using System;
using System.Collections.Generic;
using UnityEngine;

public class CardTriggerArea : MonoBehaviour
{
    [SerializeField] private bool acceptArea = true;
    [SerializeField] private bool rejectArea = false;

    [SerializeField] private AudioClip onActivateClip;
    
    
    


    private void OnTriggerStay2D(Collider2D other)
    {
        other.TryGetComponent(out Card cardRef);
        
        if (acceptArea)
        {
            DisplayEvents(cardRef.cardData.OnAcceptEvents, cardRef);
        }
        else
        {
            DisplayEvents(cardRef.cardData.OnRejectEvents, cardRef);
        }

        //Card must be dropped to be accepted
        if (cardRef != GameManager.instance.currentSelectedCard)
        {
           ActivateCard(cardRef);
           GetComponent<AudioSource>().clip = onActivateClip;
           GetComponent<AudioSource>().Play();
           
        }

    }

    private void DisplayEvents(List<CardEvent> events, Card cardRef)
    {
        string outputString = "";
        
        for (int i = 0; i < events.Count; i++)
        {
            outputString += events[i].GetEventInfo();
        }

        cardRef.descriptionText.text = outputString;

        if (acceptArea)
        {
            cardRef.titleText.text = "On Card Accept";
        }
        else
        {
            cardRef.titleText.text = "On Card Reject";
        }
        

    }


    private void OnTriggerExit2D(Collider2D other)
    {
        other.TryGetComponent(out Card cardRef);

        //Reset Card Data
        cardRef.titleText.text = cardRef.cardData.cardTitle;
        cardRef.descriptionText.text = cardRef.cardData.cardDescription;
    }

    private void ActivateCard(Card cardRef)
    {
        //accept the card events based on type of trigger
        if (acceptArea)
        {
            foreach (var cardEvent in cardRef.cardData.OnAcceptEvents)
            {
                cardEvent.OnEventActivate();
            }

            GameManager.instance.politicalPower += 5;
        }
        else
        {
            foreach (var cardEvent in cardRef.cardData.OnRejectEvents)
            {
                cardEvent.OnEventActivate();
            }

            GameManager.instance.politicalPower -= 10;
        }
        
        //Remove card data
        GameManager.instance.RemoveCard(cardRef.cardData);
        
        Destroy(cardRef.gameObject);
        
        GameManager.instance.SpawnNewCard();
    }
}
