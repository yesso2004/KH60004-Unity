using UnityEngine;

[CreateAssetMenu(fileName = "Entrepreneur", menuName = "Cards/Entrepreneur")]
public class Entrepreneur : Card
{
    public override void CardAbility(Player player, Player Rival)
    {
        player.CurrentRole = Role.Entrepreneur;
    }
}
