using System;
using System.Collections;
using UnityEngine;

public class BulletMovement : MonoBehaviour
{
    private Rigidbody2D rig;
    private Animator anim;
    private int n = 0;
    public int direction;  // 0 = up, 1 = down, 2 = left, 3 = right
    private Vector2 move_vector;
    public GameObject Explosion;
    public string BossName;

    // Use this for initialization
    private void Start()
    {
        if (direction == 0) //up
        {
            move_vector = new Vector2(0, 1);
        }
        else if (direction == 1) //down
        {
            move_vector = new Vector2(0, -1);
        }
        else if (direction == 2) //left
        {
            move_vector = new Vector2(-1, 0);
        }
        else if (direction == 3) //right
        {
            move_vector = new Vector2(1, 0);
        }
        rig = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        try
        {
            // client.setupSocket("localhost", 8082);
        }
        catch (Exception e)
        {
            Debug.Log(e);
        }
    }

    // Update is called once per frame
    private void Update()
    {
        n++;

        if (move_vector != Vector2.zero)
        {
            rig.MovePosition(rig.position + move_vector * 10 * Time.deltaTime);
        }
        if (n == 100)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.name != BossName)
        {
            Instantiate(Explosion, this.transform.position, Quaternion.identity);
            Destroy(gameObject);
            if (collider.tag.Equals("people"))
            {
                Destroy(collider.gameObject);
            }
        }
    }
}