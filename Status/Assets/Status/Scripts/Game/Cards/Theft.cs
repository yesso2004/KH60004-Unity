using UnityEngine;

[CreateAssetMenu(fileName = "Theft", menuName = "Cards/Theft")]
public class Theft : Card
{
    public override void CardAbility(Player player, Player Rival)
    {
        if (Rival.Hand.Count == 0)
        {
            Rival.StatusPoints -= 1500;
            PlayerData.instance.UpdateAmount(Rival, Rival.StatusPoints);
            player.StatusPoints += 500;
            PlayerData.instance.UpdateAmount(player, player.StatusPoints);
            return;
        }

        int StealRand = Random.Range(0, Rival.Hand.Count);
        Card StolenCard = Rival.Hand[StealRand];

        if (player.Hand.Count >= 5)
        {
            Rival.StatusPoints -= 200;
            PlayerData.instance.UpdateAmount(Rival,Rival.StatusPoints);
            player.StatusPoints += 50;
            PlayerData.instance.UpdateAmount(player, player.StatusPoints);

            UIManager.Instance.StartCoroutine(UIManager.Instance.DiscardCard(StolenCard, Rival));
            Rival.Hand.Remove(StolenCard);
            Debug.Log("Player: "+player.Name+ " Stole the card: "+StolenCard+" from the player: "+Rival.Name+" But had no space");

            return;
        }
       

       
        UIManager.Instance.StartCoroutine(UIManager.Instance.DiscardCard(StolenCard,Rival));
        Rival.Hand.Remove(StolenCard);

        player.Hand.Add(StolenCard);
        UIManager.Instance.DsiplayCard(StolenCard,player);
        Debug.Log("Player: " + player.Name + " Stole the card: " + StolenCard + " from the player: " + Rival.Name );


    }
}
