using System.Collections.Generic;
using UnityEngine;

public enum Role
{
    Unemployed,
    Employed,
    Entrepreneur
}

public class Player:MonoBehaviour
{
    public string Name;
    public int Wins;
    public int Losses;
    public int StatusPoints;
    public List<Card> Hand =  new List<Card>();
    public Role CurrentRole = Role.Unemployed;

    
    public void InitialDraw()
    {
        for (int i = 0; i < 3; i++)
        {
            Card DrawnCard = GameManager.instance.DeckDraw();
            Hand.Add(DrawnCard);
            UIManager.Instance.DsiplayCard(DrawnCard, this);
        }
    }

    public void DrawCard()
    {
        for (int i = 0; i < 2; i++)
        {
            if (Hand.Count >= 5)
            {
                // DiscardCard();
                return;
            }
            Card DrawnCard = GameManager.instance.DeckDraw();
            Hand.Add(DrawnCard);
            UIManager.Instance.DsiplayCard(DrawnCard, this);
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


