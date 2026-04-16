using UnityEngine;

[CreateAssetMenu(fileName = "Tax", menuName = "Cards/tax")]
public class Tax : Card
{
    public override void CardAbility(Player player, Player Rival)
    {
        int TaxAmount = Mathf.RoundToInt(player.StatusPoints * 0.15f);
        player.StatusPoints -= TaxAmount;
    }
}
