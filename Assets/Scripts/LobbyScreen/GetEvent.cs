using BestHTTP;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using SimpleJSON;
using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GetEvent : MonoBehaviour
{
    public UILabel eventtext;

    // private string EventUrl = "http://192.168.1.22:3000/api/events?access_token=";
    // public int speed;

    private void Start()
    {
        HTTPRequest request = new HTTPRequest(new Uri(APIUrl.UrlEvent + PlayerPrefs.GetString("token")), HTTPMethods.Get, OnRequestFinished);

        request.Send();
        //  speed = 2;
    }

    private void OnRequestFinished(HTTPRequest originalRequest, HTTPResponse response)
    {
        var json = JSON.Parse(response.DataAsText);
        //  var json = JSON.Parse(response.DataAsText);
        string a = "";
        for (int i = 0; i < json.Count; i++)
        {
            //  Debug.Log(json[i]["name"]);
            a += json[i]["description"];
        }
        eventtext.text = a;
    }

    // Update is called once per frame
    private void Update()
    {
        //if (Time.deltaTime != 0)
        //    eventtext.transform.position += Vector3.left * Time.deltaTime * speed;
    }
}