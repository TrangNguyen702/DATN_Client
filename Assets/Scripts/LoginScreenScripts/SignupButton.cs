using BestHTTP;
using Newtonsoft.Json;
using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SignupButton : MonoBehaviour
{
    private string SignupUrl = "http://192.168.1.100:8080/api/signup";
    public UIInput username;
    public UIInput password;
    public UIInput confirmPassword;
    public UICenterOnChild characterSelected;
    public UIGrid characterList;

    private void Start()
    {
        username = GameObject.Find("usernameSignup").GetComponent<UIInput>();
        password = GameObject.Find("passwordSignup").GetComponent<UIInput>();
        confirmPassword = GameObject.Find("confirmPassword").GetComponent<UIInput>();
        characterSelected = GameObject.Find("characterList").GetComponent<UICenterOnChild>();
        characterList = GameObject.Find("characterList").GetComponent<UIGrid>();
    }

    private void OnClick()
    {
        Debug.Log(characterList.GetIndex(characterSelected.centeredObject.transform).ToString());
        if (!confirmPassword.text.Equals(password.text)) return;
        HTTPRequest request = new HTTPRequest(new Uri(SignupUrl), HTTPMethods.Post, OnRequestFinished);
        request.AddField("username", username.text);
        request.AddField("password", password.text);
        request.AddField("characterType", characterList.GetIndex(characterSelected.centeredObject.transform).ToString());
        request.Send();

        //SceneManager.LoadScene(1);
    }

    private void OnRequestFinished(HTTPRequest originalRequest, HTTPResponse response)
    {
        var res = JsonConvert.DeserializeObject<Response>(response.DataAsText);
        Debug.Log(res.success);

        if (res.success == -1)
        {
            Debug.Log(res.message);
        }
        else if (res.success == 0)
        {
            Debug.Log(res.message);
        }
    }

    public class Response
    {
        public int success;
        public string message = "";
    }
}