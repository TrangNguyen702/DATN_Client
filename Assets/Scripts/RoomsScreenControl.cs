using System.Collections;
using UnityEngine;

public class RoomsScreenControl : MonoBehaviour
{
    // Use this for initialization
    public UIInput hosttextbox;

    public UIInput numbertextbox;
    public UIInput passowordtextbox;

    private void Start()
    {
        hosttextbox = GameObject.Find("HostTextbox").GetComponent<UIInput>();
        numbertextbox = GameObject.Find("NumberTextbox").GetComponent<UIInput>();
        passowordtextbox = GameObject.Find("PasswordTextbox").GetComponent<UIInput>();
    }

    // Update is called once per frame
    private void Update()
    {
    }
}