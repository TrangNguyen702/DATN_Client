using BestHTTP;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using SimpleJSON;
using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ButtonOnClickScript : MonoBehaviour
{
    public UIInput RoomNametxb;
    public UIInput HostNametxb;
    public UIInput Numbertxb;
    public UIInput Passwordtxb;
    // public UILabel eventtext;

    public GameObject RowRoomPrefab;
    private int RoomNumber = 1;
    //   private string EventUrl = "http://192.168.1.104:3000/api/events";

    // Use this for initialization
    private void Start()
    {
        //HTTPRequest request = new HTTPRequest(new Uri(EventUrl + PlayerPrefs.GetString("token")), HTTPMethods.Get, OnRequestFinished);

        //request.Send();
    }

    //private void OnRequestFinished(HTTPRequest originalRequest, HTTPResponse response)
    //{
    //    var json = JSON.Parse(response.DataAsText);
    //    eventtext.text = json["description"];
    //}

    private void OnClick()
    {
        if (gameObject.name == "btnAddRoom")
        {
            ((GameObject)GameObject.Find("ContentRooms")).SetActive(false);
            ((GameObject)GameObject.Find("Window")).transform.Find("ContentCreateRoom").gameObject.SetActive(true);
            GameObject.Find("TabRoom").GetComponent<UIToggledObjects>().activate[0] = GameObject.Find("ContentCreateRoom");
        }
        else if (gameObject.name == "BackToTabRooms")
        {
            ((GameObject)GameObject.Find("ContentCreateRoom")).SetActive(false);
            ((GameObject)GameObject.Find("Window")).transform.Find("ContentRooms").gameObject.SetActive(true);
            GameObject.Find("TabRoom").GetComponent<UIToggledObjects>().activate[0] = GameObject.Find("ContentRooms");
        }
        else if (gameObject.name == "CreateButton")
        {
            //  Debug.Log(HostNametxb.text + Numbertxb.text + Passwordtxb.text);
            GameObject mygameobject = (GameObject)Instantiate(RowRoomPrefab, new Vector3(this.transform.position.x,
                this.transform.position.y, this.RowRoomPrefab.transform.position.z), Quaternion.identity);
            //   if (Selection.activeTransform != null)
            mygameobject.transform.Find("RoomName").GetComponent<UILabel>().text = RoomNametxb.text;
            mygameobject.transform.Find("Current_max").GetComponent<UILabel>().text = Numbertxb.text;
            mygameobject.transform.Find("Host").GetComponent<UILabel>().text = HostNametxb.text;
            mygameobject.transform.localScale = new Vector3(1, 1, 1);
            //  NGUITools.AddChild((GameObject.Find("Window")).transform.Find("Grid").gameObject, mygameobject);

            //  Debug.Log(mygameobject.transform.parent.name);

            ((GameObject)GameObject.Find("ContentCreateRoom")).SetActive(false);
            ((GameObject)GameObject.Find("Window")).transform.Find("ContentRooms").gameObject.SetActive(true);
            //   GameObject.Find("Window").transform.Find("Grid").gameObject.GetComponent<UIGrid>().AddChild(mygameobject.transform);
            GameObject.Find("Grid").GetComponent<UIGrid>().AddChild(mygameobject.transform);
            mygameobject.transform.localScale = new Vector3(1, 1, 1);
            GameObject.Find("TabRoom").GetComponent<UIToggledObjects>().activate[0] = GameObject.Find("ContentRooms");
            GameObject.Find("Grid").GetComponent<UIGrid>().Reposition();
        }
        else if (gameObject.tag == "HandleClickRoomRow")
        {
            string n = gameObject.transform.parent.transform.Find("RoomName").GetComponent<UILabel>().text;
            ((GameObject)GameObject.Find("ContentRooms")).SetActive(false);
            ((GameObject)GameObject.Find("Window")).transform.Find("ContentRoom").gameObject.SetActive(true);
            GameObject.Find("TabRoom").GetComponent<UIToggledObjects>().activate[0] = GameObject.Find("ContentRoom");
            GameObject.Find("RoomTitle").GetComponent<UILabel>().text = n;
        }
        else if (gameObject.name == "BackToTabRooms_ContentRoom")
        {
            ((GameObject)GameObject.Find("ContentRoom")).SetActive(false);
            ((GameObject)GameObject.Find("Window")).transform.Find("ContentRooms").gameObject.SetActive(true);
            GameObject.Find("TabRoom").GetComponent<UIToggledObjects>().activate[0] = GameObject.Find("ContentRooms");
        }
    }

    // Update is called once per frame
    private void Update()
    {
    }
}