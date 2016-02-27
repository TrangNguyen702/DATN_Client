using System.Collections;
using UnityEngine;

public class HeaderMovementScript : MonoBehaviour
{
    private System.Random rand = new System.Random();
    public GameObject bullet_prefab;
    private Animator anim;
    public Vector2 pullbackdirection;

    public Vector3 u1;
    public Vector3 u2;
    public Vector3 u3;
    public Vector3 u4;
    public Vector3 u5;

    // Use this for initialization
    private void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    private void Update()
    {
        Vector3 mousePositionInWorld = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector3 toMousePosition = mousePositionInWorld - transform.position;
        float AngleRad = Mathf.Atan2(toMousePosition.y - transform.position.y, toMousePosition.x - transform.position.x);
        // Get Angle in Degrees
        float AngleDeg = (180 / Mathf.PI) * AngleRad;
        // Rotate Object
        this.transform.rotation = Quaternion.Euler(0, 0, AngleDeg);

        if (Input.GetMouseButtonDown(0))
        {
            ////multil bullet
            //getRandomVector(mousePositionInWorld - ((GameObject)GameObject.Find("Gunfight")).transform.position);
            //var obj = (GameObject)Instantiate(bullet_prefab, ((GameObject)GameObject.Find("Gunfight")).transform.position, Quaternion.identity);
            //pullbackdirection = u1;// getnormalizedVector(getRandomVector(mousePositionInWorld) - obj.transform.position);
            //obj.GetComponent<BulletMovement1>().directionvector = pullbackdirection;
            //var obj1 = (GameObject)Instantiate(bullet_prefab, ((GameObject)GameObject.Find("Gunfight")).transform.position, Quaternion.identity);
            //pullbackdirection = u2;// getnormalizedVector(getRandomVector(mousePositionInWorld) - obj1.transform.position);
            //obj1.GetComponent<BulletMovement1>().directionvector = pullbackdirection;
            //var obj2 = (GameObject)Instantiate(bullet_prefab, ((GameObject)GameObject.Find("Gunfight")).transform.position, Quaternion.identity);
            //pullbackdirection = u3;//getnormalizedVector(getRandomVector(mousePositionInWorld) - obj2.transform.position);
            //obj2.GetComponent<BulletMovement1>().directionvector = pullbackdirection;
            //var obj3 = (GameObject)Instantiate(bullet_prefab, ((GameObject)GameObject.Find("Gunfight")).transform.position, Quaternion.identity);
            //pullbackdirection = u4;//getnormalizedVector(getRandomVector(mousePositionInWorld) - obj3.transform.position);
            //obj3.GetComponent<BulletMovement1>().directionvector = pullbackdirection;
            //var obj4 = (GameObject)Instantiate(bullet_prefab, ((GameObject)GameObject.Find("Gunfight")).transform.position, Quaternion.identity);
            //pullbackdirection = u5;// getnormalizedVector(getRandomVector(mousePositionInWorld) - obj4.transform.position);
            //obj4.GetComponent<BulletMovement1>().directionvector = pullbackdirection;
            ////multi bullet

            ////neu la dan dien electronic
            //var obj = (GameObject)Instantiate(bullet_prefab, new Vector3(((GameObject)GameObject.Find("Gunfight")).transform.position.x, ((GameObject)GameObject.Find("Gunfight")).transform.position.y, this.transform.position.z + 1), Quaternion.identity);
            //obj.transform.rotation = Quaternion.Euler(0, 0, AngleDeg);
            //obj.transform.parent = this.transform;
            ////neu la dan dien electronic

            ////neu la dan thuong
            //var obj = (GameObject)Instantiate(bullet_prefab, ((GameObject)GameObject.Find("Gunfight")).transform.position, Quaternion.identity);
            //pullbackdirection = getnormalizedVector(mousePositionInWorld - obj.transform.position);
            //obj.GetComponent<BulletMovement1>().directionvector = pullbackdirection;
            ////giat sung
            //StartCoroutine(_Wait(0.1f));
            ////neu la dan thuong

            //neu la dan lua

            // pullbackdirection = getnormalizedVector(mousePositionInWorld - ((GameObject)GameObject.Find("Gunfight")).transform.position);
            var obj = (GameObject)Instantiate(bullet_prefab, ((GameObject)GameObject.Find("Gunfight")).transform.position, Quaternion.identity);
            // obj.GetComponent<BulletFires>().pullbackdirection = pullbackdirection;

            //neu la dan lua
        }
    }

    public Vector2 getnormalizedVector(Vector2 target)
    {
        float mauso = Mathf.Sqrt(target.x * target.x + target.y * target.y);
        return new Vector2(target.x / mauso, target.y / mauso);
    }

    private IEnumerator _Wait(float duration)
    {
        transform.position -= new Vector3(pullbackdirection.x * Time.deltaTime, pullbackdirection.y * Time.deltaTime, 0);
        //  Debug.Log("chay");
        yield return new WaitForSeconds(duration);   //Wait
        transform.position = ((GameObject)GameObject.Find("Body")).transform.position;
    }

    public void getRandomVector(Vector3 input)
    {
        u1 = new Vector3(input.x + 0.1f, input.y - 0.1f, input.z);
        u2 = new Vector3(input.x + 0.1f, input.y + 0.1f, input.z);
        u3 = new Vector3(input.x - 0.1f, input.y + 0.1f, input.z);
        u4 = new Vector3(input.x - 0.1f, input.y - 0.1f, input.z);
        u5 = new Vector3(input.x + 0.2f, input.y - 0.2f, input.z);
    }
}