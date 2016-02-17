using System.Collections;
using UnityEngine;

public class MenuControlScript : MonoBehaviour
{
    // Use this for initialization
    private void Start()
    {
    }

    // Update is called once per frame
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector3.zero);
            if (hit.collider == null) return;
            if (hit.collider.gameObject.tag == "menu_lobbybutton")
            {
                Debug.Log("lo");
            }
            else if (hit.collider.gameObject.tag == "menu_storebutton")
            {
                Debug.Log("store");
            }
            else if (hit.collider.gameObject.tag == "menu_hightscorebutton")
            {
                Debug.Log("hight");
            }
        }
    }
}