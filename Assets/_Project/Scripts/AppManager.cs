using UnityEngine;
using UnityEngine.UI;

public class AppManager : MonoBehaviour
{
    [Header("Login")]
    [SerializeField] private InputField inputFieldEmailLogin;
    [SerializeField] private InputField inputFieldPasswordLogin;
    [SerializeField] private Button buttonLogin;

    [Header("Signup")]
    [SerializeField] private InputField inputFieldEmailSignup;
    [SerializeField] private InputField inputFieldPasswordSignup;
    [SerializeField] private Button buttonSignup;

    [Header("RetrievePaswword")]
    [SerializeField] private InputField inputFieldEmailRetrievePassword;
    [SerializeField] private Button buttonRetrievePassword;

    private void Start()
    {
        buttonLogin.onClick.AddListener(OnButtonLoginClicked);
        buttonSignup.onClick.AddListener(OnButtonSignupClicked);
        buttonRetrievePassword.onClick.AddListener(OnButtonRetrievePasswordClicked);
    }

    private void OnButtonLoginClicked()
    {
        FirebaseManager.Instance.LoginFirebase(inputFieldEmailLogin.text, inputFieldPasswordLogin.text, result =>
        {
            if (result)
            {
                print("Success login");
            }
            else
            {
                print("Error login");
            }
        });
    }

    private void OnButtonSignupClicked()
    {
        FirebaseManager.Instance.SignupFirebase(inputFieldEmailSignup.text, inputFieldPasswordSignup.text, (result, messsage) =>
        {
            if (result)
            {
                print("Success signup");
                print("Message: " + messsage);
            }
            else
            {
                print("Error signup");
                print("Message: " + messsage);
            }
        });
    }

    private void OnButtonRetrievePasswordClicked()
    {
        FirebaseManager.Instance.RetrievePasswordFirebase(inputFieldEmailRetrievePassword.text, result =>
        {
            if (result)
            {
                print("Success retrieve passowrd");
            }
            else
            {
                print("Error retrieve passowrd");
            }
        });
    }
}