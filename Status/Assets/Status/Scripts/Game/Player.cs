using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class Player:MonoBehaviour
{
    public string Name;
    public int Wins;
    public int Losses;
    public int StatusPoints;
    public List<Card> Hand =  new List<Card>();
    public string CurrentRole = "Unemployed";

    
    public void InitialDraw()
    {
        for (int i = 0; i < 3; i++)
        {
            Card DrawnCard = GameManager.instance.DeckDraw();
            Hand.Add(DrawnCard);
        }
    }

    public void DrawCard()
    {
        for (int i = 0; i < 2; i++)
        {
            if (Hand.Count >= 5)
            {
                // DiscardCard();
            }
            Card DrawnCard = GameManager.instance.DeckDraw();
            Hand.Add(DrawnCard);
        }
    }

    public void DiscardCard(int Index)
    {
        Hand.RemoveAt(Index);
    }

    public void PlayCard(int Index,Player Rival)
    {
        Card PlayedCard = Hand[Index];
        //StartCoroutine
        PlayedCard.CardAbility(this,Rival);
        Hand.RemoveAt(Index);
        
    }
}
