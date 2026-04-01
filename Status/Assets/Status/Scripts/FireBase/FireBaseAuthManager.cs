using System.Collections;
using UnityEngine;
using Firebase;
using Firebase.Auth;
using Firebase.Database;
using Firebase.Extensions;
using TMPro;

public class FireBaseAuthManager : MonoBehaviour
{
    
private FirebaseAuth Auth;
private DatabaseReference DBRef;

[SerializeField] private  TMP_InputField RegistrationName;
[SerializeField] private  TMP_InputField RegistrationEmail;
[SerializeField] private  TMP_InputField RegistrationPassword;
[SerializeField] private  TMP_InputField RegistrationConfirmPassword;
[SerializeField] private TextMeshProUGUI RegisterWarningMessage;

[SerializeField] private  TMP_InputField EmailSignIn;
[SerializeField] private TMP_InputField PasswordSignIn;
[SerializeField] private  TextMeshProUGUI SignInWarningMessage;

[SerializeField] private GameObject SelectPanel;
[SerializeField] private GameObject RegisterPanel;
[SerializeField] private GameObject SignInPanel;
[SerializeField] private GameObject PlayMenu;
[SerializeField] private GameObject SuccessScreen;

    private void ClearRegistration()
    {
    RegistrationName.text = "";
    RegistrationEmail.text = "";
    RegistrationPassword.text = "";
    RegistrationConfirmPassword.text = "";
    }

    private void ClearSignIn()
    {
    EmailSignIn.text = "";
    PasswordSignIn.text = "";
    }


    private void Start()
    {
        Auth = FirebaseAuth.DefaultInstance;
        DBRef =  FirebaseDatabase.DefaultInstance.RootReference;
    }

    public void Register()
    {
        if (RegistrationName.text == "")
        {
            RegisterWarningMessage.text = "Name Field is Empty";
            ClearRegistration();
            return;
        }

        if (RegistrationPassword.text != RegistrationConfirmPassword.text)
        {
            RegisterWarningMessage.text = "Passwords do not match";
            ClearRegistration();
            return;
        }

        Auth.CreateUserWithEmailAndPasswordAsync(
            RegistrationEmail.text.Trim(),
            RegistrationPassword.text.Trim()
        ).ContinueWithOnMainThread(Task =>
        {
            if (Task.IsFaulted)
            {
                if (Task.Exception != null)
                {
                    FirebaseException FBE = Task.Exception.GetBaseException() as FirebaseException;
                    AuthError Error = (AuthError)FBE.ErrorCode;
            
                    string FailedMessage = "Registration Failed due to ";
        
                    switch (Error)
                    {
                        case AuthError.InvalidEmail:
                            FailedMessage +=  "Invalid Email Address";
                            RegisterWarningMessage.text = FailedMessage;
                            ClearRegistration();
                            break;
                        case AuthError.WrongPassword:
                            FailedMessage +=  "Wrong Password";
                            RegisterWarningMessage.text = FailedMessage;
                            ClearRegistration();
                            break;
                        case AuthError.MissingEmail:
                            FailedMessage +=  "Missing Email";
                            RegisterWarningMessage.text = FailedMessage;
                            ClearRegistration();
                            break;
                        case AuthError.MissingPassword:
                            FailedMessage +=  "Missing Password";
                            RegisterWarningMessage.text = FailedMessage;
                            ClearRegistration();
                            break;
                        default:
                            FailedMessage +=  FBE.Message;
                            RegisterWarningMessage.text = FailedMessage;
                            ClearRegistration();
                            break;
                    }
                    Debug.LogError(FailedMessage);
                    return;
                }
            }
            Debug.Log("Successfully Registered!");
            FirebaseUser NewUser = Task.Result.User;
            var UserDB = DBRef.Child("user").Child(NewUser.UserId);
            UserDB.Child("Username").SetValueAsync(RegistrationName.text);
            UserDB.Child("Wins").SetValueAsync(0);
            UserDB.Child("Losses").SetValueAsync(0);
            
            StartCoroutine(FadeManager.Instance.FadeOut(RegisterPanel));
            StartCoroutine(SuccessScreenTransition(SuccessScreen));
            StartCoroutine(FadeManager.Instance.FadeIn(SelectPanel));
        });

    }

     public void SignIn()
    {
        var SignInTask = Auth.SignInWithEmailAndPasswordAsync(
            EmailSignIn.text.Trim(),
            PasswordSignIn.text.Trim()
        );

        if (SignInTask.Exception != null)
        {
            FirebaseException FBE = SignInTask.Exception.GetBaseException() as FirebaseException;
            AuthError Error = (AuthError)FBE.ErrorCode;

            string FailedMessage = "Sign-In Failed due to ";

            switch (Error)
            {
                case AuthError.InvalidEmail:
                    FailedMessage += "Invalid Email Address";
                    SignInWarningMessage.text = FailedMessage;
                    ClearSignIn();
                    break;
                case AuthError.WrongPassword:
                    FailedMessage += "Wrong Password";
                    SignInWarningMessage.text = FailedMessage;
                    ClearSignIn();
                    break;
                case AuthError.MissingEmail:
                    FailedMessage += "Missing Email";
                    SignInWarningMessage.text = FailedMessage;
                    ClearSignIn();
                    break;
                case AuthError.MissingPassword:
                    FailedMessage += "Missing Password";
                    SignInWarningMessage.text = FailedMessage;
                    ClearSignIn();
                    break;
                default:
                    FailedMessage += FBE.Message;
                    SignInWarningMessage.text = FailedMessage;
                    ClearSignIn();
                    break;
            }

            Debug.Log(FailedMessage);
            return;
        }
        Debug.Log("Successfully logged in!");
        StartCoroutine(FadeManager.Instance.FadeOut(SignInPanel));
        StartCoroutine(FadeManager.Instance.FadeIn(PlayMenu));
    }

        public void SignOut()
        {
            Auth.SignOut();
            ClearRegistration();
            ClearSignIn();
        }

        IEnumerator SuccessScreenTransition(GameObject Panel)
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
