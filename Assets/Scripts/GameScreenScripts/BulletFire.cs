using System.Collections;
using UnityEngine;

public class BulletFire : MonoBehaviour
{
    // Use this for initialization
    public int speed;

    public Vector2 directionvector;
    private int n = 40;

    private void Start()
    {
        speed = 6;
    }

    // Update is called once per frame
    private void Update()
    {
        //  Debug.Log("la :" + directionvector.x + directionvector.y);
        transform.position += new Vector3(directionvector.x * Time.deltaTime * speed, directionvector.y * Time.deltaTime * speed, 0);
        Vector3 objectScale = this.transform.localScale;
        if (objectScale.x < 2.5)
        {
            // Debug.Log("la " + objectScale.x);
            Vector3 newScale = new Vector3(objectScale.x + 0.3f, objectScale.y + 0.3f, objectScale.z);
            this.transform.localScale = newScale;
        }
        if (objectScale.x >= 2.5)
        {
            n--;
            if (n == 0)
                Destroy(gameObject);
        }
    }
}