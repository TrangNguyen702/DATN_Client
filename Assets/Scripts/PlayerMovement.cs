using System;
using System.Collections;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rig;
    private Animator anim;
    private ClientNetwork client = new ClientNetwork();
    public GameObject _myPrefabs;
    private int count = 0;
    private System.Random rand = new System.Random();
    public GameObject Bullet;

    // public GameObject Explosion;
    public int bulletDirection;

    private float bulletRotation;

    // Use this for initialization
    private void Start()
    {
        bulletDirection = 0;
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

    private void OnApplicationQuit()
    {
        client.closeSocket();
    }

    private void OnMouseDown()
    {
        Debug.Log("sbc");
        if (_myPrefabs != null)
        {
            for (int i = 0; i < 20; i++)
                Instantiate(_myPrefabs, new Vector3(RandomNumber(1), RandomNumber(2), 0), Quaternion.identity);
            count += 20;
        }
        //    Debug.Log(count);
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
        //neu di binh thuong
        Vector2 move_vector = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        if (move_vector != Vector2.zero)
        {
            anim.SetBool("isWalking", true);
            anim.SetFloat("input_x", move_vector.x);
            anim.SetFloat("input_y", move_vector.y);
        }
        else anim.SetBool("isWalking", false);
        rig.MovePosition(rig.position + move_vector * Time.deltaTime * 3);

        //neu click chuot
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 vec = this.transform.position;
            if (Bullet != null)
            {
                getBulletInfor();
                var obj = (GameObject)Instantiate(Bullet, this.transform.position, Quaternion.identity);
                obj.GetComponent<BulletMovement>().direction = bulletDirection;
                obj.GetComponent<BulletMovement>().BossName = this.gameObject.name;

                var rotationVector = obj.transform.rotation.eulerAngles;
                rotationVector.z = bulletRotation;
                obj.transform.rotation = Quaternion.Euler(rotationVector);
            }

            //sinh bot
        }
    }

    public void getBulletInfor()
    {
        if (anim.GetFloat("input_x") == 0)
        {
            if (anim.GetFloat("input_y") == 1)
            {
                bulletDirection = 0;
                bulletRotation = 0;
            }
            else if (anim.GetFloat("input_y") == -1)
            {
                bulletDirection = 1;
                bulletRotation = 180;
            }
        }
        else if (anim.GetFloat("input_y") == 0)
        {
            if (anim.GetFloat("input_x") == -1)
            {
                bulletDirection = 2;
                bulletRotation = 90;
            }
            else if (anim.GetFloat("input_x") == 1)
            {
                bulletDirection = 3;
                bulletRotation = -90;
            }
        }
    }
}