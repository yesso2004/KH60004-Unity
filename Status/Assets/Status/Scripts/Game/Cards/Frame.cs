using NUnit.Framework;
using UnityEngine;



[CreateAssetMenu(fileName = "Frame", menuName = "Cards/Frame")]
public class Frame : Card
{


    List<Card> PenaltyCards = new List<Card> { Felony,};
    Card Penalty 
    public override void CardAbility(Player player, Player Rival)
    {
        
    }
}
