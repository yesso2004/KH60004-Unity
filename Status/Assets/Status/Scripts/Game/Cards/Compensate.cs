using UnityEngine;

[CreateAssetMenu(fileName = "Compensate", menuName = "Cards/Compensate")]
public class Compensate : Card
{
    public override void CardAbility(Player player, Player Rival)
    {
        player.StatusPoints += 300;
    }
}
