using UnityEditor;
using UnityEngine;

public abstract class Card:ScriptableObject
{
    public string CardName;
    public string CardDescription;
    public Sprite CardSprite;
    public Sprite CardHiddenSprite;
    public abstract void CardAbility(Player player,Player Rival);

    public int WheelOfFate()
    {
        int Num = Random.Range(0, 11);
        return Num;
    }
}

class Compensate:Card
{
    public override void CardAbility(Player player, Player Rival)
    {
        player.StatusPoints += 300;
    }
}

class Loyalty:Card
{
    public override void CardAbility(Player player, Player Rival)
    {
        player.StatusPoints += 600;
    }
}

class Loan:Card
{
    public override void CardAbility(Player player, Player Rival)
    {
        int Chance = WheelOfFate();

        if (Chance >= 1 && Chance <= 4)
        {
            
        }
    }
}


