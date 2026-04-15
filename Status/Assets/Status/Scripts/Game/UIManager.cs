using UnityEngine;

public class UIManager : MonoBehaviour
{
    
    public static UIManager Instance;

    public GameObject CardPrefab;
    public Transform PlayerHandZone;
    public Transform AIHandZone;

    private void Awake()
    {
        Instance = this;
    }

    public void DsiplayCard(Card CardData,Player player)
    {
        Transform TargetedHand = null;
        bool Hidden = false;
        if (player == GameManager.instance.Me)
        {
             Hidden = false;
             TargetedHand = PlayerHandZone;
        }
        else
        {
            Hidden = true;
            TargetedHand = AIHandZone;
        }

        if (TargetedHand == null)
        {
            Debug.LogError("Cannot allocate card to missing hand");
            return;
        }

        GameObject AddedCard = Instantiate(CardPrefab, TargetedHand);
        CardData DataScript = AddedCard.GetComponent<CardData>();

        if (DataScript != null)
        {
            DataScript.DisplayCards(CardData, Hidden);
        }
        else
        {
            Debug.LogError("Failed to create card");
        }
    }

}
