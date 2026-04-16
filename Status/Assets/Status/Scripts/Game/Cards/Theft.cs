using UnityEngine;

[CreateAssetMenu(fileName = "Theft", menuName = "Cards/Theft")]
public class Theft : Card
{
    public override void CardAbility(Player player, Player Rival)
    {
        if (Rival.Hand.Count == 0)
        {
            Rival.StatusPoints -= 1500;
            player.StatusPoints += 500;
            return;
        }

        int StealRand = Random.Range(0, Rival.Hand.Count);
        Card StolenCard = Rival.Hand[StealRand];

        if (player.Hand.Count >= 5)
        {
            Rival.StatusPoints -= 200;
            player.StatusPoints += 50;
        
            UIManager.Instance.StartCoroutine(UIManager.Instance.DiscardCard(StolenCard, Rival));
            Rival.Hand.Remove(StolenCard);
            Debug.Log("Player: "+player.Name+ "");

            return;
        }
       

       
        UIManager.Instance.StartCoroutine(UIManager.Instance.DiscardCard(StolenCard,Rival));
        Rival.Hand.Remove(StolenCard);

        player.Hand.Add(StolenCard);
        UIManager.Instance.DsiplayCard(StolenCard,player);

    }
}
