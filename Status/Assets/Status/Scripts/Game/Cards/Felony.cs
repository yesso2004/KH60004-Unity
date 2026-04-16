using UnityEngine;

[CreateAssetMenu(fileName = "Felony", menuName = "Cards/Felony")]
public class Felony : Card
{
    public override void CardAbility(Player player, Player Rival)
    {
        if (GameManager.instance.RoundNumber <= 3)
        {
            return;
        }

        player.StatusPoints -= 1000;
        PlayerData.instance.UpdateAmount(player, player.StatusPoints);

    }
}
