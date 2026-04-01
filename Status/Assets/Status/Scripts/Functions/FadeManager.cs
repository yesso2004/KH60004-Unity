using System.Collections;
using UnityEngine;

public class FadeManager:MonoBehaviour
{
    public static FadeManager Instance;

    void Awake()
    {
        Instance = this;
    }
    
    public IEnumerator FadeIn(GameObject Panel)
    {
        Panel.SetActive(true);
        
        CanvasGroup PanelCG = Panel.GetComponent<CanvasGroup>();
        
        float Speed = 2f;
        while (PanelCG.alpha < 1f)
        {
            PanelCG.alpha += Speed * Time.deltaTime;
            yield return null;
        }
        PanelCG.interactable = true;
        yield return null;
        
        PanelCG.blocksRaycasts = true;
        yield return null;
        
    }
    
    public IEnumerator FadeOut(GameObject Panel)
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
        
        Panel.SetActive(false);
    }
    
    public IEnumerator SuccessScreenTransition(GameObject Panel)
    { 
            
        Panel.SetActive(true);
            
        CanvasGroup PanelCG = Panel.GetComponent<CanvasGroup>();
        float Speed = 1.5f;
    
        while (PanelCG.alpha < 1f)
        {
            PanelCG.alpha += Speed * Time.deltaTime;
            yield return null;
        }
    
        PanelCG.interactable = true;
        yield return null;
        PanelCG.blocksRaycasts = true;
        yield return new WaitForSeconds(1);
    
        while (PanelCG.alpha > 0f)
        {
            PanelCG.alpha -= Speed * Time.deltaTime;
            yield return null;
        }
        PanelCG.interactable = false;
        yield return null;
        PanelCG.blocksRaycasts = false;
        yield return null;
            
        Panel.SetActive(false);
    }
}
