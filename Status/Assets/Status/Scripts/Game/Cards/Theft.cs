using UnityEngine;

[CreateAssetMenu(fileName = "Theft", menuName = "Cards/Theft")]
public class Theft : Card
{
    public override void CardAbility(Player player, Player Rival)
    {
        int StealRand = Random.Range(0, Rival.Hand.Count);

        if (player.Hand.Count >= 5)
        {
            Rival.StatusPoints -= 200;
            player.StatusPoints += 50;
            Rival.Hand.RemoveAt(StealRand);
            return;
        }
        else if (Rival.Hand.Count == 0)
        {
            Rival.StatusPoints -= 1500;
            player.StatusPoints += 500;
            return;
        }

        Card StolenCard = Rival.Hand[StealRand];
        Rival.Hand.RemoveAt(StealRand);
        player.Hand.Add(StolenCard);

    }
}
