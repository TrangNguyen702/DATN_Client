using BestHTTP;
using Newtonsoft.Json;
using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoginButton : MonoBehaviour
{
    private string LoginUrl = "http://192.168.1.69:8080/api/login";
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
        var res = JsonConvert.DeserializeObject<Response>(response.DataAsText);
        if (res.success == -1)
        {
            Debug.Log(res.message);
        }
        else if (res.success == 0)
        {
            AutoFade.LoadLevel("menuscreen", 1.2f);
            // SceneManager.LoadScene(1);
        }
    }

    public class Response
    {
        public int success;
        public string message = "";
    }
}