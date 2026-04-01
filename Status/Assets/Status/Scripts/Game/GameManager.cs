using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public List<Card> Deck = new List<Card>();
    public Transform[] CardSlots;
    public bool[] Hand;

    // public void DrawCard()
    // {
    //     if (Deck.Count >= 1)
    //     Card RandomCard = Deck[Random.Range(0, Deck.Count)];
    //     for 
    // }
}
