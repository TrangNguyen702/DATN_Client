using BestHTTP;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using SimpleJSON;
using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections.Generic;

public class GetUserId : MonoBehaviour
{
    // public string GetUserIdUrl = "http://192.168.1.22:3000/api/users";
	public static List<String> itemid = new List<string>();

    private void Start()
    {
        HTTPRequest request = new HTTPRequest(new Uri(APIUrl.UrlUserId + "/" + PlayerPrefs.GetString("UserId") + "?access_token=" + PlayerPrefs.GetString("token")), HTTPMethods.Get, OnRequestFinished);
        // Debug.Log(APIUrl.UrlUserId + "/" + PlayerPrefs.GetString("UserId") + "?access_token=" + PlayerPrefs.GetString("token"));
        //  request.AddField("id", PlayerPrefs.GetString("UserId"));
        request.Send();
    }

    // Update is called once per frame
    private void Update()
    {
    }

    private void OnRequestFinished(HTTPRequest originalRequest, HTTPResponse response)
    {
        var json = JSON.Parse(response.DataAsText);

       // Debug.Log(response.DataAsText);
		for (int i = 0; i < json ["item"].Count; i++) {
			itemid.Add(json["item"][i]);
			//Debug.Log ("item la " + itemid[i]);
		}


    }
	private void OnClick()
	{
		//Debug.Log ("abc");
	}
}