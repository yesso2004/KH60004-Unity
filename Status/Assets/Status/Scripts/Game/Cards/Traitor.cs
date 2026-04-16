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
                return;
            }
            if (player.Hand.Count == 1)
            {
                Card LostCard = player.Hand[0];
                UIManager.Instance.StartCoroutine(UIManager.Instance.DiscardCard(LostCard, player));
                player.Hand.Remove(LostCard);
                player.StatusPoints -= 150;
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
