using UnityEngine;

[CreateAssetMenu(fileName = "Loyalty", menuName = "Cards/Loyalty")]
public class Loyalty : Card
{
    public override void CardAbility(Player player, Player Rival)
    {
        player.StatusPoints += 600;
    }
}
