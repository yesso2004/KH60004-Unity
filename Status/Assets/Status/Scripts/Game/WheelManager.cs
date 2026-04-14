using System.Collections;
using TMPro;
using UnityEngine;

public class WheelManager : MonoBehaviour
{ 

    public static WheelManager Instance;
[SerializeField] private GameObject WheelPanel;
[SerializeField] private TextMeshProUGUI NumberTxt;
public int Number { get; private set; }

private void Awake()
{
    Instance = this;
}

public void LoanChance(Player Human)
{
    StartCoroutine(LoanRoll(Human));
}

public void OffenseChance(Player Human)
    {
        StartCoroutine(OffenseRoll(Human));
    }

public IEnumerator LoanRoll(Player player)
{
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
    yield return new WaitForSeconds(1.2f);

    WheelPanel.SetActive(false);
    if (Number > 6)
    {
            player.StatusPoints += 1000;
    }

}

public IEnumerator OffenseRoll(Player player)
    {
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
        yield return new WaitForSeconds(1.2f);

        WheelPanel.SetActive(false);
        if (Number <= 5)
        {
            player.StatusPoints -= 300;
        }
        else if (Number >= 6)
        {
            player.StatusPoints -= 100;

        }
    }

}

