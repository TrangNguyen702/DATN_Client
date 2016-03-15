using BestHTTP;
using Newtonsoft.Json;
using SimpleJSON;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GetItems : MonoBehaviour
{
	public static List<Item> itemlist = new List<Item>();
    public List<GameObject> itemPo = new List<GameObject>();
    public GameObject itemprefab1;
	public GameObject itemprefab2;
    public  Sprite sp;

    private void Start()
    {
        HTTPRequest request = new HTTPRequest(new Uri(APIUrl.UrlItems + PlayerPrefs.GetString("token")), HTTPMethods.Get, OnRequestFinished);
        Debug.Log(APIUrl.UrlItems + PlayerPrefs.GetString("token"));

        request.Send();
    }

    // Update is called once per frame
    private void Update()
    {
    }

    private void OnRequestFinished(HTTPRequest originalRequest, HTTPResponse response)
    {
        var json = JSON.Parse(response.DataAsText);

        for (int i = 0; i < json.Count; i++)
        {
            itemlist.Add(new Item(
                 json[i]["code"]
                 , json[i]["name"]
                 , json[i]["damage"]
                 , json[i]["price"]
                 , json[i]["avatar"]
                 , json[i]["itemCategoryId"]
                 , json[i]["id"]
                 , json[i]["categoryId"]
                 ));
			//kiem tra xem sung da mua chua
			itemlist [i].bought = 0;
			//Debug.Log ("so sanh item ; " + json [i] ["id"]);
			for(int k = 0; k<GetUserId.itemid.Count; k++){
			//	Debug.Log ("so sanh voi :" + GetUserId.itemid [k]+ "va ;"+ json[i]["id"]);
				if (json [i] ["id"].ToString().Trim('"').Equals( GetUserId.itemid [k].ToString())) {
					itemlist [i].bought = 1;
					Debug.Log ("trung nhau giua ;"+ GetUserId.itemid[k] +"va :"+ json[i]["name"]);

				}
			}
			GameObject bullet3;
			if (itemlist [i].bought == 1) {
				 bullet3 = (GameObject)Instantiate (itemprefab2, itemPo [i].transform.position, Quaternion.identity);
			} else {
				 bullet3 = (GameObject)Instantiate (itemprefab1, itemPo [i].transform.position, Quaternion.identity);
			}

            Transform[] allChildren = bullet3.transform.GetComponentsInChildren<Transform>();
            foreach (Transform t in allChildren)
            {
                if (t != null && t.gameObject.name == "Wp")
                {

                    new HTTPRequest(new Uri(json[i]["avatar"]), (request, res)
                    =>
                    {
                        var texture = new Texture2D(0, 0);
                      //  Debug.Log("red.data = "+ res);
                        texture.LoadImage(res.Data);
                      t.GetComponent<SpriteRenderer>().sprite = Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), new Vector2(0.5f, 0.5f));
                    }
                    ).Send();
                }
            }
			bullet3.transform.SetParent(GameObject.Find("Weapons").transform);
            bullet3.transform.position = itemPo[i].transform.position;
			bullet3.transform.localScale = new Vector3 (0.9f, 0.9f, 0.9f);
        }
    }

    public class Item
    {
        public string code;
        public string name;
        public string damage;
        public string price;
        public string avatar;
        public string itemCategoryId;
        public string id;
        public string categoryId;
		public int bought;

        public Item(string code,
         string name,
         string damage,
         string price,
        string avatar,
         string itemCategoryId,
         string id,
        string categoryId)
        {
            this.code = code;
            this.name = name;
            this.damage = damage;
            this.price = price;
            this.avatar = avatar;
            this.itemCategoryId = itemCategoryId;
            this.id = id;
            this.categoryId = categoryId;
        }
    }
}
