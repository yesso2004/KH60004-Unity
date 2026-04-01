using System.Collections;
using UnityEngine;
using Firebase;
using Firebase.Auth;
using Firebase.Database;
using Firebase.Extensions;
using TMPro;
using UnityEditor.VersionControl;

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

[SerializeField] private TextMeshProUGUI DisplayName; 
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
            StartCoroutine(FadeManager.Instance.SuccessScreenTransition(SuccessScreen));
            StartCoroutine(FadeManager.Instance.FadeIn(SelectPanel));
        });
    }

     public void SignIn()
    {
        Auth.SignInWithEmailAndPasswordAsync(
            EmailSignIn.text.Trim(),
            PasswordSignIn.text.Trim()
        ).ContinueWithOnMainThread(Task =>
        {
            if (Task.IsFaulted)
            {
                if (Task.Exception != null)
                {
                    FirebaseException FBE = Task.Exception.GetBaseException() as FirebaseException;
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
            }
            FirebaseUser User = Task.Result.User;
            string UserID = User.UserId;
            DBRef.Child("user").Child(User.UserId).GetValueAsync().ContinueWithOnMainThread(DBTask =>
            {
                if (DBTask.IsCompleted)
                {
                    DataSnapshot snapshot = DBTask.Result;
                    DisplayName.text = snapshot.Child("Username").Value.ToString();
                    Debug.Log("Successfully Retrieved!: "+snapshot.Child("Username").Value.ToString());
                }
                else if (DBTask.IsFaulted || DBTask.IsCanceled)
                {
                    Debug.Log("Failed to retrieve user data");
                    SignInWarningMessage.text = "Failed to retrieve user data";
                    ClearSignIn();
                }
            });
            Debug.Log("Successfully logged in : " + UserID);
            StartCoroutine(FadeManager.Instance.FadeOut(SignInPanel));
            StartCoroutine(FadeManager.Instance.FadeIn(PlayMenu));
        });
    }

        public void SignOut()
        {
            Auth.SignOut();
            ClearRegistration();
            ClearSignIn();
            StartCoroutine(FadeManager.Instance.FadeOut(PlayMenu));
            StartCoroutine(FadeManager.Instance.FadeIn(SelectPanel));
        }
        
}
