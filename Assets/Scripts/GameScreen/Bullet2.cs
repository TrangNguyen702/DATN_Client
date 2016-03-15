using System.Collections;
using UnityEngine;

public class Bullet2 : MonoBehaviour

{
    public GameObject explosionprefab;
    private int n = 3;
    public GameObject boss;

    private void Start()
    {
        boss = (GameObject)GameObject.Find("Tank");
    }

    // Update is called once per frame
    private void Update()
    {
        Vector3 objectScale = this.transform.localScale;
        if (objectScale.x < 0.6)
        {
            // Debug.Log("la " + objectScale.x);
            Vector3 newScale = new Vector3(objectScale.x + 0.1f, objectScale.y, objectScale.z);
            this.transform.localScale = newScale;
        }
        if (objectScale.x >= 0.6)
        {
            n--;
            if (n == 0)
                Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.name != boss.name && !collider.tag.Equals("bullet") && !collider.tag.Equals("gamemenuitem"))
        {
            Vector3 objectScale = this.transform.localScale;
            float distance = Vector3.Distance(collider.transform.position, ((GameObject)GameObject.Find("Root")).transform.position);
            Vector3 newScale = new Vector3(distance / 4, objectScale.y, objectScale.z);
            this.transform.localScale = newScale;
            Instantiate(explosionprefab, collider.transform.position, Quaternion.identity);
            if (collider.tag.Equals("tankbot"))
            {
                Destroy(collider.gameObject);
                //tru diem
            }
        }
    }
}