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
}