using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Proyecto26;
using Newtonsoft.Json;

public class Auth : MonoBehaviour
{
    public string token;
    public string refreshToken;
    public string scope;
    public string savedToken;

    public AuthResponse authResponse;

    public GameObject failPopup;

    public InputField usernameField;
    public InputField passwordField;

    public void Start()
    {
        deactivatePopup();
    }

    public void SetInformation()
    {
        GetToken(usernameField.text, passwordField.text);
    }
    public void GetToken(string username, string password)
    {
        var payload = new UserData { username = username, password = password };
        RestClient.Post<AuthResponse>("http://192.168.0.137:8080/api/auth/login", payload).Then(res =>

        {
            token = res.token;
            refreshToken = res.refreshToken;
            scope = res.scope;

            authResponse.token = res.token;
            authResponse.refreshToken = res.refreshToken;
            authResponse.scope = res.scope;

            PlayerPrefs.SetString("username", username);
            PlayerPrefs.SetString("password", password);

            PlayerPrefs.SetString("token", authResponse.token);
            PlayerPrefs.SetString("refreshToken", authResponse.refreshToken);
            PlayerPrefs.SetString("scope", authResponse.scope);
            PlayerPrefs.Save();

            //SceneManager.LoadScene("main_menu");
            //SceneManager.LoadScene("basic_image");
            //SceneManager.LoadScene("get_data");

            Debug.Log(authResponse.token);
            SceneManager.LoadScene("main_menu");
        }).Catch(err => {
            Debug.LogError(err.Message);
            // Insert Visual Design here
            failPopup.SetActive(true);

            // set if cannot connect to destibation host, enable WIFI
            // set if wrong password or username were inserted
        });
    }

    public void deactivatePopup()
    {
        failPopup.SetActive(false);
    }

}
