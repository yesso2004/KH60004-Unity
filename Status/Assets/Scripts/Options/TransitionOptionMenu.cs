    using UnityEngine;
    using UnityEngine.UI;
    using System.Collections;
    using TMPro;
    using UnityEngine.Rendering;

    public class TransitionOptionMenu : MonoBehaviour
    {
        
        public Button RegisterFormBtn;
        public Button SignInButton;
        public Button QuitButton;
        
        private CanvasGroup RegisterFormBtnCG;
        private CanvasGroup SignInBtnCG;
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
        private CanvasGroup NameInputFieldCG;
        private CanvasGroup EmailInputFieldCG;
        private CanvasGroup PasswordInputFieldCG;
        private CanvasGroup ConfirmPasswordInputFieldCG;
        private CanvasGroup BackBtnCG;
        private CanvasGroup RegisterBtnCG;
        
        public GameObject SelectPanel;
        public GameObject RegisterFormPanel;
        
        private CanvasGroup SelectPanelCG;
        private CanvasGroup RegisterFormPanelCG;
        
        

       void Start()
    {
        RegisterFormBtnCG = RegisterFormBtn.GetComponent<CanvasGroup>();
        SignInBtnCG = SignInButton.GetComponent<CanvasGroup>();
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
        NameInputFieldCG = NameInputField.GetComponent<CanvasGroup>();
        EmailInputFieldCG = EmailInputField.GetComponent<CanvasGroup>();
        PasswordInputFieldCG = PasswordInputField.GetComponent<CanvasGroup>();
        ConfirmPasswordInputFieldCG = ConfirmPasswordInputField.GetComponent<CanvasGroup>();
        BackBtnCG = BackBtn.GetComponent<CanvasGroup>();
        RegisterBtnCG = RegisterBtn.GetComponent<CanvasGroup>();
        
        SelectPanelCG = SelectPanel.GetComponent<CanvasGroup>();
        RegisterFormPanelCG = RegisterFormPanel.GetComponent<CanvasGroup>();
        
    }

       
       
    public void RegisterFormBtnFadeIn()
    {
        StartCoroutine(FadeOut(RegisterFormBtnCG));
        StartCoroutine(FadeOut(SignInBtnCG));
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
        StartCoroutine(FadeIn(NameInputFieldCG));
        StartCoroutine(FadeIn(EmailInputFieldCG));
        StartCoroutine(FadeIn(PasswordInputFieldCG));
        StartCoroutine(FadeIn(ConfirmPasswordInputFieldCG));
        StartCoroutine(FadeIn(BackBtnCG));
        StartCoroutine(FadeIn(RegisterBtnCG));
        

    }
        public void RegisterFormBtnFadeOut()
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
            StartCoroutine(FadeIn(SignInBtnCG));
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
