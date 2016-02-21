using System;
using System.Collections;
using UnityEngine;

public class CreateBotScript : MonoBehaviour
{
    public GameObject _myPrefabs;
    private System.Random rand = new System.Random();

    private void Start()
    {
    }

    private int RandomNumber(int check)
    {
        if (check == 1)
            return rand.Next(-4, 9);
        else return rand.Next(-6, 2);
    }

    // Update is called once per frame
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector3.zero);
            if (hit.collider == null) return;
            if (hit.collider.gameObject.tag == "createbotbutton")
            {
                CreateNBot(5);
            }
        }
    }

    //sinh n bot o vi tri ngau nhien
    public void CreateNBot(int n)
    {
        for (int i = 0; i < n; i++)
        {
            GameObject mygameobject = (GameObject)Instantiate(_myPrefabs, new Vector3(this.transform.position.x + rand.Next(-40, 20), this.transform.position.y + rand.Next(-20, 20), this.transform.position.z), Quaternion.identity);
            mygameobject.name = rand.Next(0, 3000).ToString();
        }
    }
}