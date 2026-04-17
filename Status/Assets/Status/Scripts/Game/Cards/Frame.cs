using System.Collections.Generic;
using UnityEngine;



[CreateAssetMenu(fileName = "Frame", menuName = "Cards/Frame")]
public class Frame : Card
{
    
    public override void CardAbility(Player player, Player Rival)
    {
        Rival.StatusPoints -= 500;
        PlayerData.instance.UpdateAmount(Rival,Rival.StatusPoints);
        player.StatusPoints += 500;
        PlayerData.instance.UpdateAmount(player, player.StatusPoints);
    }
}
