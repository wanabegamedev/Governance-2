using System;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Card : MonoBehaviour
{

    [SerializeField] private float cardMovementSpeed = 10;

    public CardData cardData;


    [Header("UI Elements")] 
   [SerializeField] private TextMeshPro titleText;

    [SerializeField] private SpriteRenderer imageHolder;

    [SerializeField] private TextMeshPro descriptionText;


    private void Awake()
    {
        titleText.text = cardData.cardTitle;
        imageHolder.sprite = cardData.cardImage;
        descriptionText.text = cardData.cardDescription;
        
    }


    private void OnMouseOver()
    {
        if (Input.GetMouseButton(0))
        {
           SelectCard();
            
           //Moves the card
           transform.position = new Vector3(Camera.main.ScreenToWorldPoint(Input.mousePosition).x,
               Camera.main.ScreenToWorldPoint(Input.mousePosition).y, 0);
        }
        else
        {
            RemoveCard();
        }
    }


    private void SelectCard()
    {
       GameManager.instance.currentSelectedCard = this;
    }
    
    private void RemoveCard()
    {
        GameManager.instance.currentSelectedCard = null;
    }
}
