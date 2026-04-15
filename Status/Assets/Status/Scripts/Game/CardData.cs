using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CardData : MonoBehaviour
{
    public Card Data;
    private Image CardIMG;

    void Awake()
    {
        CardIMG = GetComponent<Image>();
    }
    public void DisplayCards(Card CD, bool Hidden)
    {
        Data = CD;

        if (Data  == null) 
        {
            return;
        }

        if (Hidden)
        {
            CardIMG.sprite = Data.CardHiddenSprite;
        }
        else
        {
            CardIMG.sprite = Data.CardSprite;
        }

    }
   
}
