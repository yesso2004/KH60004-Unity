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
   


    public IEnumerator InitialDraw()
    {
        for (int i = 0; i < 3; i++)
        {
            Card DrawnCard = GameManager.instance.DeckDraw();


            if (DrawnCard == null)
            {
                yield break;
            }

            yield return StartCoroutine(DrawCardShowcase.instance.PlayerDrawCards(DrawnCard, this));

            if (DrawnCard == null || DrawnCard.CardType == CardTypes.Penalty) continue;

            Hand.Add(DrawnCard);
            UIManager.Instance.DsiplayCard(DrawnCard, this);
        }
    }

    public IEnumerator DrawCard()
    {

        GameManager.instance.CurrentState = GameState.Draw;

        for (int i = 0; i < 2; i++)
        {
            if (GameManager.instance.CurrentState == GameState.WheelSpin)
            {
                yield return new WaitUntil(() => GameManager.instance.CurrentState != GameState.WheelSpin);
            }

            if (Hand.Count >= 5)
            {
                Card DiscardedCard = DiscardCard();
                yield return UIManager.Instance.StartCoroutine(UIManager.Instance.DiscardCard(DiscardedCard, this));
            }

            Card DrawnCard = GameManager.instance.DeckDraw();

            if (DrawnCard ==  null)
            {
                Debug.LogError("Null Card detected");
                break;
            }

            yield return StartCoroutine(DrawCardShowcase.instance.PlayerDrawCards(DrawnCard, this));

            if (DrawnCard.CardType == CardTypes.Penalty)
            {
                DrawnCard.CardAbility(this, this);
                continue;
            }

            Hand.Add(DrawnCard);
            UIManager.Instance.DsiplayCard(DrawnCard, this);

            yield return new WaitForSeconds(2f);
        }   

        if (this == GameManager.instance.Me)
        {
            
            if (Hand.Count == 0)
            {
                GameManager.instance.CurrentState = GameState.AITurn;
                GameManager.instance.AITurn(this);
            }
            else
            {
                GameManager.instance.CurrentState = GameState.PlayerTurn;
            }
        }
        else if (this == GameManager.instance.AI)
        {

            GameManager.instance.CurrentState = GameState.AITurn;
        }
    }

    private Card DiscardCard()
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

    public void PlayCard(Card PlayedCard,Player Rival, CardData UICard = null)
    {

        if (this == GameManager.instance.Me && GameManager.instance.CurrentState != GameState.Playing)
        {
            return;
        }

        if (Hand.Contains(PlayedCard))
        {
            Hand.Remove(PlayedCard);
            PlayedCard.CardAbility(this, Rival);
            StartCoroutine(PlayWait(PlayedCard, UICard));

        }
    }

    private IEnumerator PlayWait(Card PlayedCard,CardData UICard = null)
    {

        yield return UIManager.Instance.StartCoroutine(UIManager.Instance.DiscardCard(PlayedCard, this, UICard));

        if (GameManager.instance.CurrentState == GameState.WheelSpin)
        {
            yield return new WaitUntil(() => GameManager.instance.CurrentState != GameState.WheelSpin);
        }

        if (this == GameManager.instance.Me)
        {
            GameManager.instance.CurrentState = GameState.AITurn;
            GameManager.instance.AITurn(this);
        }
    }

}


