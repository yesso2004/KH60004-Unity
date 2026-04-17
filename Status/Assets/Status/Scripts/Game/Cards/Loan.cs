using UnityEngine;

[CreateAssetMenu(fileName = "Loan", menuName = "Cards/Loan")]
public class Loan : Card
{
    public override void CardAbility(Player player, Player Rival)
    {
        player.StatusPoints -= 500;
        PlayerData.instance.UpdateAmount(player, player.StatusPoints);
        WheelManager.Instance.LoanChance(player);
    }
}
