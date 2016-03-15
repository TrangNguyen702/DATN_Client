using System.Collections;
using UnityEngine;

public class Bullet1 : MonoBehaviour
{
    // Use this for initialization
    //  public Vector3 startpoint;
    // private Rigidbody2D rig;

    public int speed;
    // public int lifetime;
    //public Vector3 startpoint;
    //public Vector3 endpoint;

    public Vector2 directionvector;
    public GameObject explosionprefab;
    public GameObject boss;

    //public int n;

    private void Start()
    {
        boss = (GameObject)GameObject.Find("Tank");
        speed = 20;
        // lifetime = 1000;
        //  n = 0;
        //  startpoint = new Vector3(0, 0, 0);
        //  endpoint = new Vector3(50, 50, 0);
    }

    // Update is called once per frame
    private void Update()
    {
        transform.position += new Vector3(directionvector.x * Time.deltaTime * speed, directionvector.y * Time.deltaTime * speed, 0);

        //Debug.Log("start : " + startpoint.x + "/" + startpoint.y);
        //Debug.Log("end : " + endpoint.x + "/" + endpoint.y);
        // Debug.Log("vec to Sau khi chuan hoa: x= " + (-startpoint + endpoint).normalized.x + " y = " + (-startpoint + endpoint).normalized.y);
        //  transform.Translate((-transform.position + endpoint).normalized * Time.deltaTime * speed);
        //Vector2 move = new Vector2((-transform.position + endpoint).normalized.x, (-transform.position + endpoint).normalized.y);
        //if (move != Vector2.zero)
        //{
        //    rig.MovePosition(rig.position + move * 10 * Time.deltaTime);
        //}
        //if (endpoint != null)
        //{
        //    transform.position = Vector3.MoveTowards(transform.position, endpoint * 10000000, Time.deltaTime * speed);
        //    n++;
        //}
        //if (n > lifetime) { Debug.Log("x= " + endpoint.x + " y= " + endpoint.y); Destroy(gameObject); Debug.Log("huy"); }
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        // Debug.Log("abc");
        if (collider.name != boss.name && !collider.tag.Equals("bullet") && !collider.tag.Equals("gamemenuitem"))
        {
            Instantiate(explosionprefab, gameObject.transform.position, Quaternion.identity);
            Destroy(gameObject);
            if (collider.tag.Equals("tankbot"))
            {
                //Debug.Log("chet");
                //Debug.Log(collider.gameObject.transform.parent.name);
                //GameObject u = (GameObject)collider.gameObject.transform.parent.gameObject;
                //Destroy(u);
            }
        }
    }
}