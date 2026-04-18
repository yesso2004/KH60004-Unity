using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using TMPro;
using UnityEngine.Rendering;

public class MenuTransitions : MonoBehaviour
{
    
    [SerializeField] private GameObject SelectPanel;
    [SerializeField] private GameObject RegisterFormPanel;
    [SerializeField] private GameObject SignInPanel;
    [SerializeField] private GameObject PlayMenuPanel;
    [SerializeField] private GameObject StatsPanel;
    
    public void RegisterForm()
    {
        StartCoroutine(FadeManager.Instance.FadeOut(SelectPanel));
        StartCoroutine(FadeManager.Instance.FadeIn(RegisterFormPanel));
    }
    
    public void ExitRegisterForm()
    {
      StartCoroutine(FadeManager.Instance.FadeOut(RegisterFormPanel));
      StartCoroutine(FadeManager.Instance.FadeIn(SelectPanel));
    }

    public void SigInForm()
    {
        StartCoroutine(FadeManager.Instance.FadeOut(SelectPanel));
        StartCoroutine(FadeManager.Instance.FadeIn(SignInPanel));
    }


    public void ExitSigInForm()
    {
        StartCoroutine(FadeManager.Instance.FadeOut(SignInPanel));
        StartCoroutine(FadeManager.Instance.FadeIn(SelectPanel));
    }

    public void Stats()
    {
        StartCoroutine(PlayMenuFadeOut(StatsPanel));
        StartCoroutine(FadeManager.Instance.FadeIn(StatsPanel));
    }

    public void ExitStats()
    {
        StartCoroutine(FadeManager.Instance.FadeOut(StatsPanel));
        StartCoroutine(FadeManager.Instance.FadeIn(PlayMenuPanel));
    }

    private IEnumerator PlayMenuFadeOut(GameObject Panel)
    {
        CanvasGroup PanelCG = Panel.GetComponent<CanvasGroup>();
        float Speed = 2f;

        while (PanelCG.alpha > 0f)
        {
            PanelCG.alpha -= Speed * Time.deltaTime;
            yield return null;
        }
        PanelCG.interactable = false;
        yield return null;

        PanelCG.blocksRaycasts = false;
        yield return null;
    }
}