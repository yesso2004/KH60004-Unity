using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using Firebase;
using Firebase.Auth;
using TMPro;

public class FireBaseAuthManager : MonoBehaviour
{
public DependencyStatus  DependencyStatus;
public FirebaseAuth Auth;
public FirebaseUser User;

public TMP_InputField RegistrationName;
public TMP_InputField RegistrationEmail;
public TMP_InputField RegistrationPassword;
public TMP_InputField RegistrationConfirmPassword;

public TMP_InputField EmailSignIn;
public TMP_InputField PasswordSignIn;

public void Awake()
{
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
                        FailedMessage +=  "Sign-In Failed";
                        break;
                }
                Debug.Log(FailedMessage);
            }
            else
            {
                User = LoginQuery.Result.User;
                Debug.Log("Successfully logged in : " + User.DisplayName);
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
                Debug.LogError("Username is Empty");
            }
            else if (Email == "")
            {
                Debug.LogError("Email is Empty");
            }
            else if (RegistrationPassword.text != RegistrationConfirmPassword.text)
            {
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
                            FailedMessage +=  firebaseException.Message;
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
                    }
                }
            }
        }
        
}
