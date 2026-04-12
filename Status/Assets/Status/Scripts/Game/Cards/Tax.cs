using UnityEngine;

[CreateAssetMenu(fileName = "Tax", menuName = "Cards/tax")]
public class Tax : Card
{
    public override void CardAbility(Player player, Player Rival)
    {
        player.StatusPoints *= Mathf.RoundToInt(0.15f);
    }
}
