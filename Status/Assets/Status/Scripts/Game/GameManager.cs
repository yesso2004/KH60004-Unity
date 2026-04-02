using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public Player Me;
    public Player AI;
    public List<Player> Players;
    public List<Card> Deck = new List<Card>();
    public int RoundNumber = 0;
    
    
    void Awake()
    {
        instance = this;
    }

    public void Game()
    {
        for (int i = 0; i < 20; i++)
        {
            if (i == 0)
            {
                
                foreach (Player player in Players)
                {
                    
                }
            }
            foreach (Player player in Players)
            {
            }
        }
       
    }
    
    public Card DeckDraw()
    {
        if (Deck.Count <= 0)
        {
            Debug.Log("Game Over");
        }
        
        int RandomCardIndex = Random.Range(0, Deck.Count);
        Card DrawnCard = Deck[RandomCardIndex];
        Deck.Remove(DrawnCard);
        
        return DrawnCard;
    }
    
    
}
