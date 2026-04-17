using System.Collections;
using TMPro;
using UnityEngine;

public class WheelManager : MonoBehaviour
{ 

public static WheelManager Instance;

[SerializeField] private GameObject WheelPanel;
[SerializeField] private TextMeshProUGUI NumberTxt;
[SerializeField] private TextMeshProUGUI DescriptionTxt;
public int Number { get; private set; }


private void Awake()
{
    Instance = this;
}

public void LoanChance(Player player)
{
    StartCoroutine(LoanRoll(player));
}

public void OffenseChance(Player player)
{
    StartCoroutine(OffenseRoll(player));
}

public IEnumerator LoanRoll(Player player)
{
    GameState PreviousState = GameManager.instance.CurrentState;
    GameManager.instance.CurrentState = GameState.WheelSpin;

    yield return new WaitForSeconds(1f);
    WheelPanel.SetActive(true);

    Number = Random.Range(1, 11);
    
    float Duration = 1.5f;
    float LoopDuration = 0f;

    while (LoopDuration < Duration)
    {
        NumberTxt.text = Random.Range(1, 11).ToString();
        yield return new WaitForSeconds(0.05f);
        LoopDuration += 0.05f;
    }
    
    NumberTxt.text = Number.ToString();
        if (Number > 6)
        {
            DescriptionTxt.text = $"{player.Name} has succesfully loaned 1000 Status points";
            player.StatusPoints += 1000;
            PlayerData.instance.UpdateAmount(player, player.StatusPoints);
            Debug.Log($"{player.Name} has succesfully loaned 1000 Status points");
        }
        else
        {
            DescriptionTxt.text = $"{player.Name} has lost 500 Status points due to interest";
            Debug.Log($" {player.Name} has lost 500 Status points due to interest");
        }
        yield return new WaitForSeconds(2.5f);

        WheelPanel.SetActive(false);
        NumberTxt.text = "";
        DescriptionTxt.text = "";

        
        GameManager.instance.CurrentState = PreviousState;

    }

    public IEnumerator OffenseRoll(Player player)
    {

        GameState PreviousState = GameManager.instance.CurrentState;
        GameManager.instance.CurrentState = GameState.WheelSpin;

        yield return new WaitForSeconds(1f);
        WheelPanel.SetActive(true);

        Number = Random.Range(1, 11);

        float Duration = 1.5f;
        float LoopDuration = 0f;

        while (LoopDuration < Duration)
        {
            NumberTxt.text = Random.Range(1, 11).ToString();
            yield return new WaitForSeconds(0.05f);
            LoopDuration += 0.05f;
        }

        NumberTxt.text = Number.ToString();
        if (Number <= 5)
        {
            DescriptionTxt.text = $"{player.Name} had the max offense fee and must pay 300 Status points";
            Debug.Log($"{player.Name} had the max offense fee and must pay 300 Status points");
            player.StatusPoints -= 300;
            PlayerData.instance.UpdateAmount(player, player.StatusPoints);

        }
        else if (Number >= 6)
        {
            DescriptionTxt.text = $"{player.Name} had the min offense fee and must pay 100 Status points";
            Debug.Log($"{player.Name} had the min offense fee and must pay 100 Status points");
            player.StatusPoints -= 100;
            PlayerData.instance.UpdateAmount(player, player.StatusPoints);
        }

        yield return new WaitForSeconds(2.5f);

        WheelPanel.SetActive(false);
        NumberTxt.text = "";
        DescriptionTxt.text = "";

        
        GameManager.instance.CurrentState = PreviousState;

    }

}

