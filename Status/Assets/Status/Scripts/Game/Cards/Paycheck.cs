using UnityEngine;

[CreateAssetMenu(fileName = "Paycheck", menuName = "Cards/Paycheck")]
public class Paycheck : Card
{
    public override void CardAbility(Player player, Player Rival)
    {
     if (player.CurrentRole == Role.Unemployed)
        {
            player.StatusPoints += 50;
        }
     if (player.CurrentRole == Role.Employed)
        {
            player.StatusPoints += 350;
        }
     if (player.CurrentRole == Role.Entrepreneur)
        {
            player.StatusPoints += 500;
        }
    }
}
