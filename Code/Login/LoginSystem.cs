using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using PlayFab;
using PlayFab.ClientModels;


public class LoginSystem : MonoBehaviour
{
    [Header("Login")]
    [SerializeField]
    private InputField emailLogin;
    [SerializeField]
    private InputField passwordLogin;
    [SerializeField]
    private InputField resetPassword;
    [SerializeField]
    private Text loginText;
    
    

    [Header("Creat")]
    [SerializeField]
    private InputField userNameCreat;
    [SerializeField]
    private InputField emaiCreat;
    [SerializeField]
    private InputField passwordCreat;
    [SerializeField]
    private InputField passwordCreatConfirme;
    [SerializeField]
    private Text messageText;
    [SerializeField]
    private Text resetMessageText;


    public void Login()
    {
        var request = new LoginWithEmailAddressRequest
        {
            Email = emailLogin.text,
            Password = passwordLogin.text
        };
        PlayFabClientAPI.LoginWithEmailAddress(request, LoginSuccess, OnErrorL);
    }
    void LoginSuccess(LoginResult result)
    {
        loginText.text = "Logged - - Espere !";
        GetComponent<LoginSceneUIController>().NextScene();

    }

    public void Register()
    {
        var request = new RegisterPlayFabUserRequest
        {
            Username = userNameCreat.text,
            Email = emaiCreat.text,
            Password = passwordCreat.text,
            RequireBothUsernameAndEmail = false
        };
        PlayFabClientAPI.RegisterPlayFabUser(request, RegisterSuccess, OnError);
    }

    void RegisterSuccess(RegisterPlayFabUserResult result)
    {
        messageText.text = "Registrado com Sucesso !!!";
    }
    void OnError(PlayFabError error)
    {
        string mensagemDeErro = "";

        // Verifique o código de erro para determinar qual mensagem exibir
        switch (error.Error)
        {
            case PlayFabErrorCode.EmailAddressNotAvailable:
                mensagemDeErro = "Email em já cadastrado";
                break;
            case PlayFabErrorCode.InvalidEmailAddress:
                mensagemDeErro = "Email inválido";
                break;
            case PlayFabErrorCode.UsernameNotAvailable:
                mensagemDeErro = "Usuário já cadastrado";
                break;
            case PlayFabErrorCode.InvalidUsernameOrPassword:
                mensagemDeErro = "Nome de usuário ou senha incorretos";
                break;
            case PlayFabErrorCode.InvalidParams:
                mensagemDeErro = "Parametros inválidos";
                break;
            // Adicione mais casos para outros códigos de erro, se necessário
            default:
                mensagemDeErro = "Erro, tente novamente"; 
                break;
        }

        messageText.text = mensagemDeErro;
    }
    void OnErrorL(PlayFabError error)
    {
        string mensagemDeErro = "";

        // Verifique o código de erro para determinar qual mensagem exibir
        switch (error.Error)
        {
            case PlayFabErrorCode.EmailAddressNotAvailable:
                mensagemDeErro = "Email em já cadastrado";
                break;
            case PlayFabErrorCode.InvalidEmailAddress:
                mensagemDeErro = "Email inválido";
                break;
            case PlayFabErrorCode.UsernameNotAvailable:
                mensagemDeErro = "Usuário já cadastrado";
                break;
            case PlayFabErrorCode.InvalidUsernameOrPassword:
                mensagemDeErro = "Nome de usuário ou senha incorretos";
                break;
            case PlayFabErrorCode.InvalidParams:
                mensagemDeErro = "Parametros inválidos";
                break;
            // Adicione mais casos para outros códigos de erro, se necessário
            default:
                mensagemDeErro = "Erro, usuário ou senha incorreto";
                break;
        }
        loginText.text = mensagemDeErro;
    }

    public void RegisterBtn()
    {
        if(passwordCreat.text == passwordCreatConfirme.text) 
        {
            Register();
        }
        else
        {
            messageText.text = "Senha e a confirmação da senha devem ser os mesmos";
        }
    }

    public void ResetPasswordBtn()
    {
        var request = new SendAccountRecoveryEmailRequest
        {
            Email = resetPassword.text,
            TitleId = "D031B"
        };
        PlayFabClientAPI.SendAccountRecoveryEmail(request, OnPasswordReset, OnError);
    }

    public void OnPasswordReset(SendAccountRecoveryEmailResult result)
    {
        resetMessageText.text = " Email enviado";
    }
}

