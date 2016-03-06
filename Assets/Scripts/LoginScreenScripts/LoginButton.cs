using BestHTTP;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using SimpleJSON;
using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoginButton : MonoBehaviour
{
    private string LoginUrl = "http://192.168.1.104:3000/api/users/login";
    public UIInput username;
    public UIInput password;

    private void Start()
    {
        username = GameObject.Find("usernameLogin").GetComponent<UIInput>();
        password = GameObject.Find("passwordLogin").GetComponent<UIInput>();
    }

    private void OnClick()
    {
        HTTPRequest request = new HTTPRequest(new Uri(LoginUrl), HTTPMethods.Post, OnRequestFinished);
        request.AddField("username", username.text);
        request.AddField("password", password.text);
        request.Send();

        //SceneManager.LoadScene(1);
    }

    private void OnRequestFinished(HTTPRequest originalRequest, HTTPResponse response)
    {
        var json = JSON.Parse(response.DataAsText);

        if (response.StatusCode == 200)
        {
            Debug.Log(json["id"].Value);
            PlayerPrefs.SetString("token", json["id"].Value);
            PlayerPrefs.Save();
            AutoFade.LoadLevel("lobbyScreen", 1.2f);
        }
        else
        {
            //   Debug.Log("Login failed !");
        }
    }
}