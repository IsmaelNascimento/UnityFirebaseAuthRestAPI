using System;
using Proyecto26;
using UnityEngine;

public class FirebaseManager : MonoBehaviour
{
    public static FirebaseManager Instance;

    [Header("Jsons")]
    [SerializeField] private TextAsset jsonLoginOrSignup;
    [SerializeField] private TextAsset jsonResetPassword;

    private void Awake()
    {
        Instance = this;
    }

    public void LoginFirebase(string email, string password, Action<bool> result = null)
    {
        string uri = Constants.ENDPOINT_LOGIN_FIREBASE_AUTH + Constants.API_KEY_FIREBASE;
        string payload = jsonLoginOrSignup.text;
        payload = payload.Replace("{email}", email);
        payload = payload.Replace("{password}", password);

        RestClient.Post(uri, payload)
                  .Then((res) => 
                  {
                       if (result != null) 
                        result(true); 
                   })
                  .Catch((err) => 
                  { 
                      if (result != null) 
                        result(false); 
                  });
    }

    public void SignupFirebase(string email, string password, Action<bool, string> result = null)
    {
        string uri = Constants.ENDPOINT_SIGNUP_FIREBASE_AUTH + Constants.API_KEY_FIREBASE;
        string payload = jsonLoginOrSignup.text;
        payload = payload.Replace("{email}", email);
        payload = payload.Replace("{password}", password);

        RestClient.Post(uri, payload)
                  .Then((res) =>
                  {
                      result?.Invoke(true, res.Text); // .Net 4.x
                  })
                  .Catch((err) =>
                  {
                      result?.Invoke(false, err.Message);
                  });
    }

    public void RetrievePasswordFirebase(string email, Action<bool> result = null)
    {
        string uri = Constants.ENDPOINT_RESET_PASSWORD_FIREBASE_AUTH + Constants.API_KEY_FIREBASE;
        string payload = jsonResetPassword.text;
        payload = payload.Replace("{email}", email);

        RestClient.Post(uri, payload)
                  .Then((res) =>
                  {
                      result?.Invoke(true);
                  })
                  .Catch((err) =>
                  {
                      result?.Invoke(false);
                  });
    }
}