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

public class BuyBtn : MonoBehaviour {
	public static List<GameObject> po = new List<GameObject>();
	int n;
	// Use this for initialization
	void Start () {
		n = 0;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonDown (0)) {
		//	Debug.Log (((Camera)GameObject.Find ("Camera")).name);
			/*
			RaycastHit2D hit = Physics2D.Raycast (((Camera)GameObject.Find("Camera")).ScreenToWorldPoint (Input.mousePosition), Vector3.zero);  //click vao dap a4
			if (hit.collider.tag == "buybutton") {
				Debug.Log ("sjfdhsd");
				for(int i = 0; i<po.Count; i++){
					if(po[i].transform.position.Equals(hit.collider.transform.parent.transform.position)){
						n = i;
						Debug.Log ("them moi item co id =" + GetItems.itemlist [n]);
					}
				}
			//	hit.collider.transform.position = 


			//	HTTPRequest request = new HTTPRequest(new Uri(APIUrl.UrlPutItemId + "/" + PlayerPrefs.GetString("UserId") + "?access_token=" + PlayerPrefs.GetString("token")), HTTPMethods.Put, OnRequestFinished);
			//	GetUserId.itemid.Add (GetItems.itemlist[n].id);

			//	request.AddField("item", GetUserId.itemid);
			//	request.Send();
			}
			*/
		}
	
	}
}
