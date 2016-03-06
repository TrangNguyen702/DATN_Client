using BestHTTP;
using Newtonsoft.Json;
using SimpleJSON;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SignupButton : MonoBehaviour
{
    private string SignupUrl = "http://192.168.1.104:3000/api/users";
    private string CharacterUrl = "http://192.168.1.104:3000/api/characters";
    public UIInput username;
    public UIInput password;
    public UIInput confirmPassword;
    public UICenterOnChild characterSelected;
    public UIGrid characterList;
    public List<CharacterItem> characteritemlist = new List<CharacterItem>();
    public List<UILabel> labeltitle = new List<UILabel>();
    public List<UILabel> labelinfor = new List<UILabel>();
    public List<SpriteRenderer> spriterender = new List<SpriteRenderer>();
    public GameObject characteritemprefab;
    public Sprite _sprite;

    private void Start()
    {
        //lay character ve
        HTTPRequest request = new HTTPRequest(new Uri(CharacterUrl), HTTPMethods.Get, OnCharacterFinished);
        request.Send();

        username = GameObject.Find("usernameSignup").GetComponent<UIInput>();
        password = GameObject.Find("passwordSignup").GetComponent<UIInput>();
        confirmPassword = GameObject.Find("confirmPassword").GetComponent<UIInput>();
        characterSelected = GameObject.Find("characterList").GetComponent<UICenterOnChild>();
        characterList = GameObject.Find("characterList").GetComponent<UIGrid>();
    }

    private void OnClick()
    {
        // Debug.Log(characterList.GetIndex(characterSelected.centeredObject.transform).ToString());
        if (!confirmPassword.text.Equals(password.text))
        {
            return;
        }
        HTTPRequest request = new HTTPRequest(new Uri(SignupUrl), HTTPMethods.Post, OnRequestFinished);
        request.AddField("username", username.text);
        request.AddField("password", password.text);
        request.AddField("score", "0");
        request.AddField("email", username.text + "nguyentrang@gmail.com");
        int n = characterList.GetIndex(characterSelected.centeredObject.transform);
        request.AddField("characterId", characteritemlist[n].id);
        request.Send();
    }

    private void OnCharacterFinished(HTTPRequest originalRequest, HTTPResponse response)
    {
        var json = JSON.Parse(response.DataAsText);

        for (int i = 0; i < json.Count; i++)
        {
            characteritemlist.Add(new CharacterItem(
                json[i]["code"]
                , json[i]["name"]
                , json[i]["strength"]
                , json[i]["speed"]
                , json[i]["avatar"]
                , json[i]["description"]
                , json[i]["id"]
                ));
            var bullet3 = (GameObject)Instantiate(characteritemprefab, new Vector3(0, 0, 0), Quaternion.identity);
            Transform[] allChildren = bullet3.transform.GetComponentsInChildren<Transform>();
            foreach (Transform t in allChildren)
            {
                if (t != null && t.gameObject.name == "UILabelTitle")
                    t.GetComponent<UILabel>().text = json[i]["name"];
                else if (t != null && t.gameObject.name == "UILabelInfor")
                    t.GetComponent<UILabel>().text = "Speed: " + json[i]["speed"] + "\nStrength: " + json[i]["strength"];
                else if (t != null && t.gameObject.name == "2D Sprite")
                {
                    new HTTPRequest(new Uri(json[i]["avatar"]), (request, res)
                    =>
                    {
                        var texture = new Texture2D(0, 0);
                        texture.LoadImage(res.Data);
                        t.GetComponent<UI2DSprite>().sprite2D = Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), new Vector2(0.5f, 0.5f));
                    }
                    ).Send();
                }
            }
            characterList.GetComponent<UIGrid>().AddChild(bullet3.transform);
            bullet3.transform.localScale = new Vector3(1, 1, 1);
            characterList.GetComponent<UIGrid>().Reposition();
        }
    }

    private void OnRequestFinished(HTTPRequest originalRequest, HTTPResponse response)
    {
        var res = JsonConvert.DeserializeObject<Response>(response.DataAsText);
        //  Debug.Log(response.StatusCode);
        if (response.StatusCode == 200)
        {
            ((GameObject)GameObject.Find("Content 2")).SetActive(false);
            ((GameObject)GameObject.Find("Window")).transform.Find("Content 1").gameObject.SetActive(true);
            GameObject.Find("Tab 1").GetComponent<UIToggledObjects>().activate[0] = GameObject.Find("Content 1");
        }
        //    else
        //   Debug.Log(response.StatusCode);
    }

    public class Response
    {
        public int success;
        public string message = "";
    }

    public class CharacterItem
    {
        public string code;
        public string name;
        public string strength;
        public string speed;
        public string visibility;
        public string armor;
        public string avatar;
        public string description;
        public string id;

        public CharacterItem(string code, string name, string strength, string speed, string avatar, string des, string id)
        {
            this.code = code;
            this.name = name;
            this.strength = strength;
            this.speed = speed;
            this.avatar = avatar;
            this.description = des;
            this.id = id;
        }
    }
}