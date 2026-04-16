using System.Collections;
using System.Collections.Generic;
using Unity.VectorGraphics;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public Player Me;
    public Player AI;
    public List<Player> Players;
    public List<Card> Deck = new List<Card>();
    public int RoundNumber = 1;
    
    
    void Awake()
    {
        instance = this;
        Shuffle();
    }

    private void Start()
    {
       Me.InitialDraw();
       AI.InitialDraw();
    }

    public void AITurn(Player player)
    {
        StartCoroutine(AITurnWait(player));
    }

    public IEnumerator AITurnWait(Player player)
    {
        
        if (RoundNumber > 1)
        {
             AI.DrawCard();
           
        }
     

        yield return new WaitForSeconds(5f);

        if (AI.Hand.Count == 0)
        {
            RoundNumber++;
            AI.Playing = false;
            Me.DrawCard();
            yield break;
        }

        if (AI.Hand.Count > 0)
        {
            int RandomPlay = Random.Range(0, AI.Hand.Count);
            Card RandomChoice = AI.Hand[RandomPlay];
            AI.PlayCard(RandomChoice, player);
        }

        RoundNumber++;

        AI.Playing = false;
        Me.DrawCard();
    }

    public Card DeckDraw()
    {
        if (Deck.Count <= 0)
        {
            Debug.Log("Game Over");
            SceneManager.LoadScene("Menu");
            return null;
        }
        
        int RandomCardIndex = Random.Range(0, Deck.Count);
        Card DrawnCard = Deck[RandomCardIndex];
        Deck.Remove(DrawnCard);
        
        return DrawnCard;
    }

    public void Shuffle()
    {
        for (int i = 0; i < Deck.Count; i++)
        {
            Card ShuffledCard = Deck[i];
            int RandomIndex = Random.Range(i, Deck.Count);
            Deck[i] = Deck[RandomIndex];
            Deck[RandomIndex] = ShuffledCard;
        }
    }
    
}

