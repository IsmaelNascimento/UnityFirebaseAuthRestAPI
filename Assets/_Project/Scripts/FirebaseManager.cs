using System;
using Proyecto26;
using UnityEngine;

public class FirebaseManager : MonoBehaviour
{
	public static FirebaseManager Instance;

	[Header("Jsons")]
	[SerializeField] private TextAsset jsonLoginOrSignup;
	[SerializeField] private TextAsset jsonResetPassword;
    [SerializeField] private TextAsset jsonGoogleOAtuh;
    [SerializeField] private TextAsset jsonFacebookOAtuh;

    private void Awake()
	{
		Instance = this;
	}

	public void LoginFirebase(string email, string password, Action<bool, string> result = null)
	{
		string uri = Constants.ENDPOINT_LOGIN_FIREBASE_AUTH + Constants.API_KEY_FIREBASE;
		string payload = jsonLoginOrSignup.text;
		payload = payload.Replace("{email}", email);
		payload = payload.Replace("{password}", password);

		RestClient.Post(uri, payload)
				.Then((res) =>
				{
                    result?.Invoke(false, res.Text);
                })
				.Catch((err) =>
				{
                    result?.Invoke(true, err.Message);
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
			            result?.Invoke(false, res.Text);
		            })
		            .Catch((err) =>
		            {
			            result?.Invoke(true, err.Message);
		            });
	}

	public void RetrievePasswordFirebase(string email, Action<bool, string> result = null)
	{
		string uri = Constants.ENDPOINT_RESET_PASSWORD_FIREBASE_AUTH + Constants.API_KEY_FIREBASE;
		string payload = jsonResetPassword.text;
		payload = payload.Replace("{email}", email);

		RestClient.Post(uri, payload)
				  .Then((res) =>
				  {
					  result?.Invoke(false, res.Text);
				  })
				  .Catch((err) =>
				  {
					  result?.Invoke(true, err.Message);
				  });
	}

    public void LoginGoogleOAuthFirebase(string googleIdToken, Action<bool, string> result = null)
    {
        string uri = Constants.ENDPOINT_SIGNIN_OAUTH_CREDENTIAL + Constants.API_KEY_FIREBASE;
        string payload = jsonGoogleOAtuh.text;
        payload = payload.Replace("{google_id_token}", googleIdToken);

        RestClient.Post(uri, payload)
                    .Then((res) =>
                    {
                        result?.Invoke(false, res.Text);
                    })
                    .Catch((err) =>
                    {
                        result?.Invoke(true, err.Message);
                    });
    }

    public void LoginFacebookOAuthFirebase(string acess_token, Action<bool, string> result = null)
    {
        string uri = Constants.ENDPOINT_SIGNIN_OAUTH_CREDENTIAL + Constants.API_KEY_FIREBASE;
        string payload = jsonFacebookOAtuh.text;
        payload = payload.Replace("{acess_token}", acess_token);

        RestClient.Post(uri, payload)
                    .Then((res) =>
                    {
                        result?.Invoke(false, res.Text);
                    })
                    .Catch((err) =>
                    {
                        result?.Invoke(true, err.Message);
                    });
    }
}
