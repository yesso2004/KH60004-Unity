using UnityEngine;

[CreateAssetMenu(fileName = "Traitor", menuName = "Cards/Traitor")]
public class Traitor : Card
{
    public override void CardAbility(Player player, Player Rival)
    {

    
            if (player.Hand.Count == 0)
            {
                player.CurrentRole = Role.Unemployed;
                PlayerData.instance.UpdateStatus(player,player.CurrentRole);
                player.StatusPoints -= 500;
                PlayerData.instance.UpdateAmount(player, player.StatusPoints);
                return;
            }
            if (player.Hand.Count == 1)
            {
                Card LostCard = player.Hand[0];
                UIManager.Instance.StartCoroutine(UIManager.Instance.DiscardCard(LostCard, player));
                player.Hand.Remove(LostCard);
                player.StatusPoints -= 150;
                PlayerData.instance.UpdateAmount(player, player.StatusPoints);
                Debug.Log("Traitor has removed the card "+ LostCard + "Player: " + player.Name);
                return;
            }
        for (int i = 0; i < 2; i++)
        {
            
            int RandomIndex = Random.Range(0, player.Hand.Count);
            Card LostCard = player.Hand[RandomIndex];
            UIManager.Instance.StartCoroutine(UIManager.Instance.DiscardCard(LostCard, player));
            player.Hand.Remove(LostCard);
            Debug.Log("Traitor has removed the card " + LostCard + "Player: " + player.Name);

        }
    }
}
