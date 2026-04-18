using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DrawCardShowcase : MonoBehaviour
{

    public static DrawCardShowcase instance;

    [SerializeField] private GameObject DrawPanel;
    [SerializeField] private Image DrawPanelBackground;
    [SerializeField] private Image DrawnCardDisplay;
    [SerializeField] private TextMeshProUGUI PlayerDrewTxt;
    [SerializeField] private TextMeshProUGUI CardAbilityTxt;

    private void Awake()
    {
       instance = this; 
    }

    public IEnumerator PlayerDrawCards(Card DrawnCard , Player player)
    {
        Color StartColor = DrawPanelBackground.color;

        if (player == GameManager.instance.Me)
        {
            PlayerDrewTxt.text = $"{player.Name} Drew this card: ";
            DrawnCardDisplay.sprite = DrawnCard.CardSprite;
            CardAbilityTxt.text = DrawnCard.CardDescription;

            DrawPanel.SetActive(true);

            AudioManager.Instance.DrawSound();
            yield return StartCoroutine(FadeManager.Instance.FadeIn(DrawPanel));

            yield return new WaitForSeconds(3f);

            if (DrawnCard.CardType == CardTypes.Penalty)
            {
                float Duration = 1.0f;
                float StartTime = 0f;


                Color TargetColor = new Color(0.8f, 0.1f, 0.1f, 1f);

                while (StartTime < Duration)
                {
                    StartTime += Time.deltaTime;
                    float percent = StartTime / Duration;

                    AudioManager.Instance.PenaltySound();
                    DrawPanelBackground.color = Color.Lerp(StartColor, TargetColor, percent);

                    yield return null;
                }
            }

            yield return new WaitForSeconds(0.5f);

            yield return StartCoroutine(FadeManager.Instance.FadeOut(DrawPanel));
        }
        else
        {
            PlayerDrewTxt.text = $"{player.Name} Drew this card: ";
            DrawnCardDisplay.sprite = DrawnCard.CardHiddenSprite;
            CardAbilityTxt.text = "Secret :)";
            CardAbilityTxt.text = "Secret :)";
            DrawPanel.SetActive(true);

            AudioManager.Instance.DrawSound();
            yield return StartCoroutine(FadeManager.Instance.FadeIn(DrawPanel));

            yield return new WaitForSeconds(0.8f);

            if (DrawnCard.CardType == CardTypes.Penalty)
            {
                float Duration = 1.0f;
                float StartTime = 0f;

                Color TargetColor = new Color(0.8f, 0.1f, 0.1f, 1f);

                while (StartTime < Duration)
                {
                    StartTime += Time.deltaTime;
                    float percent = StartTime / Duration;

                    AudioManager.Instance.PenaltySound();
                    DrawPanelBackground.color = Color.Lerp(StartColor, TargetColor, percent);

                    yield return null;
                }
            }

            yield return new WaitForSeconds(0.5f);

            yield return StartCoroutine(FadeManager.Instance.FadeOut(DrawPanel));
        }
        DrawPanelBackground.color = StartColor;
        DrawPanel.SetActive(false);

    }

}
