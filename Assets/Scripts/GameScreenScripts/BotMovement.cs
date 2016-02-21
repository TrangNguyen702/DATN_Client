using System.Collections;
using UnityEngine;

public class BotMovement : MonoBehaviour
{
    private Rigidbody2D rig;
    private Animator anim;
    private ClientNetwork client = new ClientNetwork();
    private System.Random rand = new System.Random();
    private float checkTime = 0;
    private Vector2 move_vector;
    private Vector2 direct_vector;

    public int bulletDirection;
    private float bulletRotation;
    public GameObject Bullet;

    private int n;

    // Use this for initialization
    private void Start()
    {
        n = 0;
        rig = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        //var init = client.setupSocket("192.168.1.100", 8082);
        //if (!init) Debug.Log("Error init socket");
    }

    private void OnApplicationQuit()
    {
    }

    private int RandomNumber()
    {
        return rand.Next(1, 5);
    }

    // Update is called once per frame
    private void Update()
    {
        n++;
        // client.Update();
        checkTime += Time.deltaTime;
        if (checkTime > 2)
        {
            checkTime = 0;
            var direct = RandomNumber();
            move_vector = new Vector2(1, 1);
            if (direct == 1) { move_vector = new Vector2(0, move_vector.y); }
            else if (direct == 2) { move_vector = new Vector2(0, -move_vector.y); }
            else if (direct == 3) { move_vector = new Vector2(move_vector.x, 0); }
            else { move_vector = new Vector2(-move_vector.x, 0); }

            if (move_vector != Vector2.zero)
            {
                anim.SetBool("isWalking", true);
                anim.SetFloat("input_x", move_vector.x);
                anim.SetFloat("input_y", move_vector.y);
            }
            else anim.SetBool("isWalking", false);
        }
        rig.MovePosition(rig.position + move_vector * Time.deltaTime);

        if (n > 10)
        {
            // Vector3 vec = this.transform.position;
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
            n = 0;
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