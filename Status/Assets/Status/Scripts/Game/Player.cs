using System.Collections;
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
    public bool Playing = false;

    
    public void InitialDraw()
    {
        for (int i = 0; i < 3; i++)
        {
            Card DrawnCard = GameManager.instance.DeckDraw();
            if (DrawnCard.CardType == CardTypes.Penalty)
            {
                continue;
            }
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
                Card DiscardedCard = DiscardCard();
                UIManager.Instance.StartCoroutine(UIManager.Instance.DiscardCard(DiscardedCard, this));
            }
            Card DrawnCard = GameManager.instance.DeckDraw();

            if (DrawnCard ==  null)
            {
                break;
            }

            Hand.Add(DrawnCard);
            UIManager.Instance.DsiplayCard(DrawnCard, this);

            if (DrawnCard.CardType == CardTypes.Penalty)
            {
                StartCoroutine(DelayedPenalty(DrawnCard));
            }
        }
    }

    public Card DiscardCard()
    {
        if (Hand.Count > 0)
        {
            Card DiscardedCard = Hand[0];
            Hand.RemoveAt(0);
            return DiscardedCard;
        }
        Debug.LogError("Couldnt find a card to discard");
        return null;
    }

    public void PlayCard(Card PlayedCard,Player Rival)
    {

        if (this == GameManager.instance.Me && GameManager.instance.AI.Playing == true)
        {
            return;
        }

        if (this == GameManager.instance.Me && this.Hand.Count == 0)
        {
            GameManager.instance.AI.Playing = true;
            GameManager.instance.AITurn(Rival);
        }

            if (Hand.Contains(PlayedCard))
        {
            PlayedCard.CardAbility(this, Rival);
            UIManager.Instance.StartCoroutine(UIManager.Instance.DiscardCard(PlayedCard, this));
            Hand.Remove(PlayedCard);

            if (this == GameManager.instance.Me)
            {
                GameManager.instance.AI.Playing = true;
                GameManager.instance.AITurn(Rival);
            }
        }

    }

    private IEnumerator DelayedPenalty(Card PenaltyCard)
    {
        
        yield return new WaitForSeconds(1.5f);

        
        if (Hand.Contains(PenaltyCard))
        {
            PenaltyCard.CardAbility(this, this);
            UIManager.Instance.StartCoroutine(UIManager.Instance.DiscardCard(PenaltyCard, this));
            Hand.Remove(PenaltyCard);
        }
    }


}


