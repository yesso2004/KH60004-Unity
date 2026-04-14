using UnityEngine;
using UnityEngine.UI;

public enum CardTypes{
    Reward,
    Chance,
    Penalty
}
public abstract class Card:ScriptableObject
{
    public string CardName;
    public string CardDescription;
    public CardTypes CardType;
    public Sprite CardSprite;
    public Sprite CardHiddenSprite;
    public abstract void CardAbility(Player player,Player Rival);
}



