using UnityEngine;

[CreateAssetMenu(fileName = "Traitor", menuName = "Cards/Traitor")]
public class Traitor : Card
{
    public override void CardAbility(Player player, Player Rival)
    {
    
            if (player.Hand.Count == 0)
            {
                player.CurrentRole = Role.Unemployed;
                player.StatusPoints -= 500;
            }
            if (player.Hand.Count == 1)
            {
                player.Hand.RemoveAt(0);
                player.StatusPoints -= 150;
            }
        for (int i = 0; i < 2; i++)
        {
            int RandomIndex = Random.Range(0, player.Hand.Count);
            player.Hand.RemoveAt(RandomIndex);
        }
    }
}
