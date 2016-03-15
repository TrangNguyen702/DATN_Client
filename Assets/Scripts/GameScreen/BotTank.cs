using System.Collections;
using UnityEngine;

public class BotTank : MonoBehaviour
{
    // Use this for initialization

    public int performancestrength;
    public int performanceArmor;
    public int performanceSpeed;

    public int typeofhead;

    public GameObject thebody;

    public GameObject thehead;
    public int speedgo;
    public int speedrotation;
    public Vector3 move_vector;
    private System.Random rand = new System.Random();
    public int n = 200;

    private void Start()
    {
        Transform[] allChildren = GetComponentsInChildren<Transform>();
        foreach (Transform t in allChildren)
        {
            if (t != null && t.gameObject.name == "Body")
                thebody = t.gameObject;
            else if (t != null && t.gameObject.name == "Head")
                thehead = t.gameObject;
        }
        speedgo = 5;
        speedrotation = 4;
        //  thebody = (GameObject)GameObject.Find("Body");
        // thehead = (GameObject)GameObject.Find("Head");
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        transform.position += move_vector * Time.deltaTime * speedgo;
        n--;
        if (n == 1)
        {
            n = 100;
            move_vector = new Vector3(rand.Next(-1, 1), rand.Next(-1, 1), 0);
            //new Vector3(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"), 0);
            //go with speedgo

            //rotation
            if (move_vector.x == 1)
            {
                if (move_vector.y == 1)
                {
                    Rotatetowardstarget(new Vector3(0, 0, 45));
                }
                else if (move_vector.y == 0)
                {
                    Rotatetowardstarget(new Vector3(0, 0, 0));
                }
                else if (move_vector.y == -1)
                {
                    Rotatetowardstarget(new Vector3(0, 0, 315));
                }
            }
            else if (move_vector.x == 0)
            {
                if (move_vector.y == 1)
                {
                    Rotatetowardstarget(new Vector3(0, 0, 90));
                }
                else if (move_vector.y == 0)
                {
                }
                else if (move_vector.y == -1)
                {
                    Rotatetowardstarget(new Vector3(0, 0, 270));
                }
            }
            else if (move_vector.x == -1)
            {
                if (move_vector.y == 1)
                {
                    Rotatetowardstarget(new Vector3(0, 0, 135));
                }
                else if (move_vector.y == 0)
                {
                    Rotatetowardstarget(new Vector3(0, 0, 180));
                }
                else if (move_vector.y == -1)
                {
                    Rotatetowardstarget(new Vector3(0, 0, 225));
                }
            }

            if (Input.GetMouseButtonDown(0))
            {
            }
        }
    }

    public void Rotatetowardstarget(Vector3 target)
    {
        if (Vector3.Distance(thebody.transform.eulerAngles, target) > 0.01f)
        {
            if ((thebody.transform.eulerAngles.z - target.z) > 180f)
            {
                target.z += 360;
            }
            else if ((thebody.transform.eulerAngles.z - target.z) < -180f)
            {
                target.z -= 360;
            }
            thebody.transform.eulerAngles = Vector3.Lerp(thebody.transform.rotation.eulerAngles, target, speedrotation * Time.deltaTime);
        }
        else
        {
            thebody.transform.eulerAngles = target;
        }
    }
}