using System.Collections;
using UnityEngine;

public class Lazerenderscript : MonoBehaviour
{
    public GameObject explosionprefab;
    private int n = 3;

    private void Start()
    {
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
        Vector3 objectScale = this.transform.localScale;
        //   -this.GetComponent<Collider2D>().bounds.size.x / 2

        float distance = Vector3.Distance(collider.transform.position, ((GameObject)GameObject.Find("Root")).transform.position);
        //  float distance = Vector3.Distance(collider.transform.position, this.transform.position) + this.GetComponent<Collider2D>().bounds.size.x / 2;
        Vector3 newScale = new Vector3(distance / 4, objectScale.y, objectScale.z);
        this.transform.localScale = newScale;
        Instantiate(explosionprefab, collider.transform.position, Quaternion.identity);
        Destroy(gameObject);
        //  Destroy(collider.gameObject);
    }
}