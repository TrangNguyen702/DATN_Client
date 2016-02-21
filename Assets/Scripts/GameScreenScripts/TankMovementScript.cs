using System.Collections;
using UnityEngine;

public class TankMovementScript : MonoBehaviour
{
    // Use this for initialization
    public GameObject thebody;

    public GameObject thehead;
    public int speedgo;
    public int speedrotation;
    public Vector3 move_vector;
    public GameObject bullet_prefab;

    private void Start()
    {
        speedgo = 2;
        speedrotation = 4;
        thebody = (GameObject)GameObject.Find("Body");
        thehead = (GameObject)GameObject.Find("Head");
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        move_vector = new Vector3(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"), 0);
        //go with speedgo
        transform.position += move_vector * Time.deltaTime * speedgo;
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