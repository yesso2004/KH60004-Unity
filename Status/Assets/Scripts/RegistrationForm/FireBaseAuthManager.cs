using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using Firebase;
using Firebase.Auth;
using TMPro;
using UnityEngine.SceneManagement;

public class FireBaseAuthManager : MonoBehaviour
{
public DependencyStatus  DependencyStatus;
public FirebaseAuth Auth;
public FirebaseUser User;

public TextMeshProUGUI RegisterWarningMessage;
public TMP_InputField RegistrationName;
public TMP_InputField RegistrationEmail;
public TMP_InputField RegistrationPassword;
public TMP_InputField RegistrationConfirmPassword;

public TextMeshProUGUI SignInWarningMessage;
public TMP_InputField EmailSignIn;
public TMP_InputField PasswordSignIn;

public GameObject SuccessScreen;
[SerializeField]private GameObject PlayMenu;

private CanvasGroup PlayMenuCG;
private CanvasGroup SuccessScreenPanelCG;

 [SerializeField] private TextMeshProUGUI UserName;
 
 private CanvasGroup UserNameCG;

public void ClearRegistration()
{
    RegistrationName.text = "";
    RegistrationEmail.text = "";
    RegistrationPassword.text = "";
    RegistrationConfirmPassword.text = "";
}

public void ClearSignIn()
{
    EmailSignIn.text = "";
    PasswordSignIn.text = "";
}



public void Awake()
{
    SuccessScreenPanelCG = SuccessScreen.GetComponent<CanvasGroup>();
    PlayMenuCG = PlayMenu.GetComponent<CanvasGroup>();
    
    FirebaseApp.CheckAndFixDependenciesAsync().ContinueWith(task =>
    {
        DependencyStatus = task.Result;

        if (DependencyStatus == DependencyStatus.Available)
        {
            InitializeFireBase();
        }
        else
        {
            Debug.LogError("Could not resolve all Firebase dependencies: " + DependencyStatus);
        }
    });
}

void InitializeFireBase()
        {
            Auth = FirebaseAuth.DefaultInstance;
            Auth.StateChanged += AuthStateChanged;
            AuthStateChanged(this, null);
        }

        void AuthStateChanged(object Sender,System.EventArgs Eventargs)
        {
            
            if (Auth.CurrentUser != User)
            {
                bool SignedIn = User != Auth.CurrentUser && Auth.CurrentUser != null;
                if (!SignedIn && User != null)
                {
                    Debug.Log("Signed Out");
                }
                
                User  = Auth.CurrentUser;

                if (SignedIn)
                {
                    Debug.Log("Signed In");
                }
            }
        }

        public void SignIn()
        {
            StartCoroutine(SignInAsync(EmailSignIn.text,PasswordSignIn.text));
        }

        public void SignOut()
        {
            Auth.SignOut();
            ClearRegistration();
            ClearSignIn();
        }

        private IEnumerator SignInAsync(string Email, string Password)
        {
            var LoginQuery = Auth.SignInWithEmailAndPasswordAsync(Email, Password);
            yield return new WaitUntil(()=>LoginQuery.IsCompleted);

            if (LoginQuery.Exception != null)
            {
                FirebaseException firebaseException = LoginQuery.Exception.GetBaseException() as FirebaseException;
                AuthError AE =  (AuthError) firebaseException.ErrorCode;

                string FailedMessage = "Sign-In Failed due to ";
                
                switch (AE)
                {
                    case AuthError.InvalidEmail:
                        FailedMessage +=  "Invalid Email Address";
                        SignInWarningMessage.text = FailedMessage;
                        ClearSignIn();
                        break;
                    case AuthError.WrongPassword:
                        FailedMessage +=  "Wrong Password";
                        SignInWarningMessage.text = FailedMessage;
                        ClearSignIn();
                        break;
                    case AuthError.MissingEmail:
                        FailedMessage +=  "Missing Email";
                        SignInWarningMessage.text = FailedMessage;
                        ClearSignIn();
                        break;
                    case AuthError.MissingPassword:
                        FailedMessage +=  "Missing Password";
                        SignInWarningMessage.text = FailedMessage;
                        ClearSignIn();
                        break;
                    default:
                        FailedMessage +=  firebaseException.Message;
                        SignInWarningMessage.text = FailedMessage;
                        ClearSignIn();
                        break;
                }
                Debug.Log(FailedMessage);
            }
            else
            {
                User = LoginQuery.Result.User;
                Debug.Log("Successfully logged in : " + User.DisplayName);
                StartCoroutine(SuccessScreenTransition(SuccessScreenPanelCG));
                yield return null;
                PlayMenu.SetActive(true);
                yield return null;
                StartCoroutine(FadeIn(PlayMenuCG));
                
            }
        }

        public void Register()
        {
            StartCoroutine(RegisterAsync(RegistrationName.text,RegistrationEmail.text,RegistrationPassword.text,RegistrationConfirmPassword.text));
        }

        IEnumerator RegisterAsync(string Name,string Email,string Password,string Confirm)
        {
            if (Name == "")
            {
                RegisterWarningMessage.text = "DisplayName/Username is Empty";
                ClearRegistration();
                Debug.LogError("Username is Empty");
            }
            else if (Email == "")
            {
                RegisterWarningMessage.text = "Email is Empty";
                ClearRegistration();
                Debug.LogError("Email is Empty");
            }
            else if (RegistrationPassword.text != RegistrationConfirmPassword.text)
            {
                RegisterWarningMessage.text = "Passwords do not match";
                ClearRegistration();
                Debug.LogError("Passwords do not match");
            }
            else
            {
                var RegistrationQuery = Auth.CreateUserWithEmailAndPasswordAsync(Email, Password);
                yield return new WaitUntil(()=>RegistrationQuery.IsCompleted);
                if (RegistrationQuery.Exception != null)
                {
                    FirebaseException  firebaseException = RegistrationQuery.Exception.GetBaseException() as FirebaseException;
                    AuthError AE = (AuthError)firebaseException.ErrorCode;
                    
                    string FailedMessage = "Registration Failed due to ";

                    switch (AE)
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
                            FailedMessage +=  firebaseException.Message;
                            RegisterWarningMessage.text = FailedMessage;
                            ClearRegistration();
                            break;
                    }
                    Debug.Log(FailedMessage);
                }
                else
                {
                    User  = RegistrationQuery.Result.User;
                    
                    UserProfile UP = new UserProfile{DisplayName = Name};
                    
                    var UpdateProfile = User.UpdateUserProfileAsync(UP);
                    
                    yield return new WaitUntil(()=>UpdateProfile.IsCompleted);

                    if (UpdateProfile.Exception != null)
                    {
                        User.DeleteAsync();
                        FirebaseException firebaseException = UpdateProfile.Exception.GetBaseException() as FirebaseException;
                        AuthError AE = (AuthError)firebaseException .ErrorCode;
                        
                        string  FailedMessage = "Registration Failed due to ";

                        switch (AE)
                        {
                            case AuthError.InvalidEmail:
                                FailedMessage +=  "Invalid Email Address";
                                break;
                            case AuthError.WrongPassword:
                                FailedMessage +=  "Wrong Password";
                                break;
                            case AuthError.MissingEmail:
                                FailedMessage +=  "Missing Email";
                                break;
                            case AuthError.MissingPassword:
                                FailedMessage +=  "Missing Password";
                                break;
                            default:
                                FailedMessage +=  "Profile Update Failed";
                                break;
                        }
                        Debug.Log(FailedMessage);
                    }
                    else
                    {
                        Debug.Log("Successfull Registration, Welcome: "+ User.DisplayName);
                        StartCoroutine(SuccessScreenTransition(SuccessScreenPanelCG));
                        ClearRegistration();
                        
                    }
                }
            }
        }
        
        IEnumerator SuccessScreenTransition(CanvasGroup CG)
        {
            float Speed = 1.5f;
    
            while (CG.alpha < 1f)
            {
                CG.alpha += Speed * Time.deltaTime;
                yield return null;
            }
    
            CG.interactable = true;
            yield return null;
            CG.blocksRaycasts = true;
            yield return new WaitForSeconds(1);
    
            while (CG.alpha > 0f)
            {
                CG.alpha -= Speed * Time.deltaTime;
                yield return null;
            }
            CG.interactable = false;
            yield return null;
            CG.blocksRaycasts = false;
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
