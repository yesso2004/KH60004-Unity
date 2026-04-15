using System.Collections.Generic;
using UnityEngine;



[CreateAssetMenu(fileName = "Frame", menuName = "Cards/Frame")]
public class Frame : Card
{


    [SerializeField] private List<Card> PenaltyCards = new List<Card>();
    
    public override void CardAbility(Player player, Player Rival)
    {
        int RandomIndex = Random.Range(0,PenaltyCards.Count);
        Card PenaltyCard = PenaltyCards[RandomIndex];
    }
}
