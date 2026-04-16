using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class CardData : MonoBehaviour , IPointerClickHandler
{
    public Card Data;
    private Image CardIMG;
    private bool Hidden = false;
    private bool Played = false;

    void Awake()
    {
        CardIMG = GetComponent<Image>();
    }
    public void DisplayCards(Card CD, bool HiddenCard)
    {
        Data = CD;

        if (Data  == null) 
        {
            return;
        }

        if (HiddenCard)
        {
            CardIMG.sprite = Data.CardHiddenSprite;
        }
        else
        {
            CardIMG.sprite = Data.CardSprite;
        }

    }
 

    public void OnPointerClick(PointerEventData EventData)
    {
        if (Hidden || Played)
        {
            return;
        }

        Played = true;

        GameManager.instance.Me.PlayCard(Data, GameManager.instance.AI);
    }
}
