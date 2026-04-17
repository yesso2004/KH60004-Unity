using UnityEngine;

[CreateAssetMenu(fileName = "Employed", menuName = "Cards/Employed")]
public class Employed : Card
{
    public override void CardAbility(Player player, Player Rival)
    {
        if (player.CurrentRole == Role.Entrepreneur)
        {
            player.StatusPoints += 350;
            PlayerData.instance.UpdateAmount(player, player.StatusPoints);
            return;
        }
        player.CurrentRole = Role.Employed;
        PlayerData.instance.UpdateStatus(player, player.CurrentRole);
    }
}
