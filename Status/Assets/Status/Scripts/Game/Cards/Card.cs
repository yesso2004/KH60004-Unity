using System.Collections;
using UnityEditor;
using UnityEngine;

public abstract class Card:ScriptableObject
{
    public string CardName;
    public string CardDescription;
    public string CardType;
    public Sprite CardSprite;
    public Sprite CardHiddenSprite;
    public abstract void CardAbility(Player player,Player Rival);
}



