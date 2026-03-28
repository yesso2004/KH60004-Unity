using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using TMPro;
using UnityEngine.Rendering;

public class TransitionOptionMenu : MonoBehaviour
{
    
    public Button RegisterFormBtn;
    public Button SignInFormBtn;
    public Button QuitButton;
    
    private CanvasGroup RegisterFormBtnCG;
    private CanvasGroup SignInFormBtnCG;
    private CanvasGroup QuitBtnCG;

    public Image StatusLogo;
    public Image BankDecor;
    public Image CareerDecor;
    public Image GovernmentDecor;
    public Image MobDecor;
    public Image JusticeDecor;
    public TextMeshProUGUI NameTxt;
    public TextMeshProUGUI EmailTxt;
    public TextMeshProUGUI PasswordTxt;
    public TextMeshProUGUI ConfirmPasswordTxt;
    public TextMeshProUGUI RegisterWarningTxt;
    public TMP_InputField  NameInputField;
    public TMP_InputField  EmailInputField;
    public TMP_InputField PasswordInputField;
    public TMP_InputField  ConfirmPasswordInputField;
    public Button BackBtn;
    public Button RegisterBtn;

    private CanvasGroup StatusLogoCG;
    private CanvasGroup BankDecorCG;
    private CanvasGroup CareerDecorCG;
    private CanvasGroup GovernmentDecorCG;
    private CanvasGroup MobDecorCG;
    private CanvasGroup JusticeDecorCG;
    private CanvasGroup NameTxtCG;
    private CanvasGroup EmailTxtCG;
    private CanvasGroup PasswordTxtCG;
    private CanvasGroup ConfirmPasswordTxtCG;
    private CanvasGroup RegisterWarningTxtCG;
    private CanvasGroup NameInputFieldCG;
    private CanvasGroup EmailInputFieldCG;
    private CanvasGroup PasswordInputFieldCG;
    private CanvasGroup ConfirmPasswordInputFieldCG;
    private CanvasGroup BackBtnCG;
    private CanvasGroup RegisterBtnCG;

    public Image StatusLogoSigInForm;
    public Image BankDecorSigInForm;
    public Image CareerDecorSigInForm;
    public Image GovernmentDecorSigInForm;
    public Image MobDecorSigInForm;
    public TextMeshProUGUI EmailTxtSigInForm;
    public TextMeshProUGUI PasswordTxtSigInForm;
    public TextMeshProUGUI SignInWarningTxt;
    public TMP_InputField EmailInputSigInForm;
    public TMP_InputField PasswordInputSigInForm;
    public Button  BackBtnSigInForm;
    public Button SignInBtn;
    
    private CanvasGroup StatusLogoSignInFormCG;
    private CanvasGroup BankDecorSignInFormCG;
    private CanvasGroup CareerDecorSignInFormCG;
    private CanvasGroup GovernmentDecorSignInFormCG;
    private CanvasGroup MobDecorSignInFormCG;
    private CanvasGroup EmailTxtSignInFormCG;
    private CanvasGroup PasswordTxtSignInFormCG;
    private CanvasGroup SignInWarningTxtCG;
    private CanvasGroup EmailInputSignInFormCG;
    private CanvasGroup PasswordInputSignInFormCG;
    private CanvasGroup BackBtnSignInFormCG;
    private CanvasGroup SignInBtnCG;
    
    public GameObject SelectPanel;
    public GameObject RegisterFormPanel;
    public GameObject SignInPanel;
    
    private CanvasGroup SelectPanelCG;
    private CanvasGroup RegisterFormPanelCG;
    private CanvasGroup SignInPanelCG;
    
    

   void Start()
{
    RegisterFormBtnCG = RegisterFormBtn.GetComponent<CanvasGroup>();
    SignInFormBtnCG = SignInFormBtn.GetComponent<CanvasGroup>();
    QuitBtnCG = QuitButton.GetComponent<CanvasGroup>();
    
    StatusLogoCG = StatusLogo.GetComponent<CanvasGroup>();
    BankDecorCG = BankDecor.GetComponent<CanvasGroup>();
    CareerDecorCG = CareerDecor.GetComponent<CanvasGroup>();
    GovernmentDecorCG = GovernmentDecor.GetComponent<CanvasGroup>();
    MobDecorCG = MobDecor.GetComponent<CanvasGroup>();
    JusticeDecorCG = JusticeDecor.GetComponent<CanvasGroup>();
    NameTxtCG = NameTxt.GetComponent<CanvasGroup>();
    EmailTxtCG = EmailTxt.GetComponent<CanvasGroup>();
    PasswordTxtCG = PasswordTxt.GetComponent<CanvasGroup>();
    ConfirmPasswordTxtCG = ConfirmPasswordTxt.GetComponent<CanvasGroup>();
    RegisterWarningTxtCG = RegisterWarningTxt.GetComponent<CanvasGroup>();
    NameInputFieldCG = NameInputField.GetComponent<CanvasGroup>();
    EmailInputFieldCG = EmailInputField.GetComponent<CanvasGroup>();
    PasswordInputFieldCG = PasswordInputField.GetComponent<CanvasGroup>();
    ConfirmPasswordInputFieldCG = ConfirmPasswordInputField.GetComponent<CanvasGroup>();
    BackBtnCG = BackBtn.GetComponent<CanvasGroup>();
    RegisterBtnCG = RegisterBtn.GetComponent<CanvasGroup>();
    
    StatusLogoSignInFormCG = StatusLogoSigInForm.GetComponent<CanvasGroup>();
    BankDecorSignInFormCG = BankDecorSigInForm.GetComponent<CanvasGroup>();
    CareerDecorSignInFormCG =  CareerDecorSigInForm.GetComponent<CanvasGroup>();
    GovernmentDecorSignInFormCG =  GovernmentDecorSigInForm.GetComponent<CanvasGroup>();
    MobDecorSignInFormCG =  MobDecorSigInForm.GetComponent<CanvasGroup>();
    EmailTxtSignInFormCG = EmailTxtSigInForm.GetComponent<CanvasGroup>();
    PasswordTxtSignInFormCG = PasswordTxtSigInForm.GetComponent<CanvasGroup>();
    SignInWarningTxtCG = SignInWarningTxt.GetComponent<CanvasGroup>();
    EmailInputSignInFormCG = EmailInputSigInForm.GetComponent<CanvasGroup>();
    PasswordInputSignInFormCG = PasswordInputSigInForm.GetComponent<CanvasGroup>();
    BackBtnSignInFormCG =  BackBtnSigInForm.GetComponent<CanvasGroup>();
    SignInBtnCG = SignInBtn.GetComponent<CanvasGroup>();
    
    
    SelectPanelCG = SelectPanel.GetComponent<CanvasGroup>();
    RegisterFormPanelCG = RegisterFormPanel.GetComponent<CanvasGroup>();
    SignInPanelCG = SignInPanel.GetComponent<CanvasGroup>();
}
   
public void RegisterForm()
{
    StartCoroutine(FadeOut(RegisterFormBtnCG));
    StartCoroutine(FadeOut(SignInFormBtnCG));
    StartCoroutine(FadeOut(QuitBtnCG));
    StartCoroutine(FadeOut(SelectPanelCG));

    StartCoroutine(FadeIn(RegisterFormPanelCG));
    StartCoroutine(FadeIn(StatusLogoCG));
    StartCoroutine(FadeIn(BankDecorCG));
    StartCoroutine(FadeIn(CareerDecorCG));
    StartCoroutine(FadeIn(GovernmentDecorCG));
    StartCoroutine(FadeIn(MobDecorCG));
    StartCoroutine(FadeIn(JusticeDecorCG));
    StartCoroutine(FadeIn(NameTxtCG));
    StartCoroutine(FadeIn(EmailTxtCG));
    StartCoroutine(FadeIn(PasswordTxtCG));
    StartCoroutine(FadeIn(ConfirmPasswordTxtCG));
    StartCoroutine(FadeIn(RegisterWarningTxtCG));
    StartCoroutine(FadeIn(NameInputFieldCG));
    StartCoroutine(FadeIn(EmailInputFieldCG));
    StartCoroutine(FadeIn(PasswordInputFieldCG));
    StartCoroutine(FadeIn(ConfirmPasswordInputFieldCG));
    StartCoroutine(FadeIn(BackBtnCG));
    StartCoroutine(FadeIn(RegisterBtnCG));
    
}
    public void ExitRegisterForm()
    {
        StartCoroutine(FadeOut(StatusLogoCG));
        StartCoroutine(FadeOut(BankDecorCG));
        StartCoroutine(FadeOut(CareerDecorCG));
        StartCoroutine(FadeOut(GovernmentDecorCG));
        StartCoroutine(FadeOut(MobDecorCG));
        StartCoroutine(FadeOut(JusticeDecorCG));
        StartCoroutine(FadeOut(NameTxtCG));
        StartCoroutine(FadeOut(EmailTxtCG));
        StartCoroutine(FadeOut(PasswordTxtCG));
        StartCoroutine(FadeOut(RegisterWarningTxtCG));
        StartCoroutine(FadeOut(ConfirmPasswordTxtCG));
        StartCoroutine(FadeOut(NameInputFieldCG));
        StartCoroutine(FadeOut(EmailInputFieldCG));
        StartCoroutine(FadeOut(PasswordInputFieldCG));
        StartCoroutine(FadeOut(ConfirmPasswordInputFieldCG));
        StartCoroutine(FadeOut(BackBtnCG));
        StartCoroutine(FadeOut(RegisterBtnCG));
        StartCoroutine(FadeOut(RegisterFormPanelCG));
        
        
        StartCoroutine(FadeIn(SelectPanelCG));
        StartCoroutine(FadeIn(RegisterFormBtnCG));
        StartCoroutine(FadeIn(SignInFormBtnCG));
        StartCoroutine(FadeIn(QuitBtnCG));
    }

    public void SigInForm()
    {
        StartCoroutine(FadeOut(RegisterFormBtnCG));
        StartCoroutine(FadeOut(SignInFormBtnCG));
        StartCoroutine(FadeOut(QuitBtnCG));
        StartCoroutine(FadeOut(SelectPanelCG));
        
        StartCoroutine(FadeIn(SignInPanelCG));
        StartCoroutine(FadeIn(BackBtnSignInFormCG));
        StartCoroutine(FadeIn(StatusLogoSignInFormCG));
        StartCoroutine(FadeIn(BankDecorSignInFormCG));
        StartCoroutine(FadeIn(CareerDecorSignInFormCG));
        StartCoroutine(FadeIn(GovernmentDecorSignInFormCG));
        StartCoroutine(FadeIn(MobDecorSignInFormCG));
        StartCoroutine(FadeIn(EmailTxtSignInFormCG));
        StartCoroutine(FadeIn(PasswordTxtSignInFormCG));
        StartCoroutine(FadeIn(SignInWarningTxtCG));
        StartCoroutine(FadeIn(EmailInputSignInFormCG));
        StartCoroutine(FadeIn(PasswordInputSignInFormCG));
        StartCoroutine(FadeIn(SignInBtnCG));
    }


    public void ExitSigInForm()
    {
        StartCoroutine(FadeOut(SignInPanelCG));
        StartCoroutine(FadeOut(BackBtnSignInFormCG));
        StartCoroutine(FadeOut(StatusLogoSignInFormCG));
        StartCoroutine(FadeOut(BankDecorSignInFormCG));
        StartCoroutine(FadeOut(CareerDecorSignInFormCG));
        StartCoroutine(FadeOut(GovernmentDecorSignInFormCG));
        StartCoroutine(FadeOut(MobDecorSignInFormCG));
        StartCoroutine(FadeOut(EmailTxtSignInFormCG));
        StartCoroutine(FadeOut(PasswordTxtSignInFormCG));
        StartCoroutine(FadeOut(SignInWarningTxtCG));
        StartCoroutine(FadeOut(EmailInputSignInFormCG));
        StartCoroutine(FadeOut(PasswordInputSignInFormCG));
        StartCoroutine(FadeOut(SignInBtnCG));
        
        StartCoroutine(FadeIn(SelectPanelCG));
        StartCoroutine(FadeIn(RegisterFormBtnCG));
        StartCoroutine(FadeIn(SignInFormBtnCG));
        StartCoroutine(FadeIn(QuitBtnCG));
    }
    
    IEnumerator FadeOut(CanvasGroup CG)
    {

        float Speed = 2f;
        while (CG.alpha > 0f)
        {
            CG.alpha -= Speed * Time.deltaTime;
            yield return null;
        }
        CG.interactable = false;
        yield return null;
        
        CG.blocksRaycasts = false;
        yield return null;
    }

    IEnumerator FadeIn(CanvasGroup CG)
    {
        float Speed = 2f;
        while (CG.alpha < 1f)
        {
            CG.alpha += Speed * Time.deltaTime;
            yield return null;
        }
        CG.interactable = true;
        yield return null;
        
        CG.blocksRaycasts = true;
        yield return null;
    }
    
   

}