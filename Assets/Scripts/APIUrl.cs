using System.Collections;
using UnityEngine;

public class APIUrl : MonoBehaviour
{
    public static string UrlLogin;
    public static string UrlSignup;
    public static string UrlEvent;
    public static string UrlUserId;
    public static string UrlCharater;
    public static string UrlItems;
    public static string UrlPutItemId;

    public string UrlServer;

    // Use this for initialization
    private void Start()
    {
        UrlServer = "http://192.168.1.100:3000";
        UrlLogin = UrlServer + "/api/users/login";
        UrlSignup = UrlServer + "/api/users";
        UrlUserId = UrlServer + "/api/users";
        UrlCharater = UrlServer + "/api/characters";
        UrlEvent = UrlServer + "/api/events?access_token=";
        UrlItems = UrlServer + "/api/Items?access_token=";
        UrlPutItemId = UrlServer + "/api/users";
    }

    // Update is called once per frame
    private void Update()
    {
    }
}