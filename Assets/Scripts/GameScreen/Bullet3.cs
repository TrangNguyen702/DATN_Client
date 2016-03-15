using System.Collections;
using UnityEngine;

public class Bullet3 : MonoBehaviour
{
    public GameObject bullet_prefab;

    public Vector2 pullbackdirection;
    public Vector3 u1;
    public Vector3 u2;
    public Vector3 u3;
    public Vector3 u4;
    public Vector3 u5;
    public GameObject Gunfight;

    private void Start()
    {
        Transform[] allChildren = ((GameObject)(GameObject)GameObject.Find("Tank")).transform.GetComponentsInChildren<Transform>();
        foreach (Transform t in allChildren)
        {
            if (t != null && t.gameObject.name == "Gunfight")
            {
                Gunfight = t.gameObject;
                // Debug.Log("ra roi ");
            }
        }
        Vector3 mousePositionInWorld = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        StartCoroutine(_Wait(0.000000000000001f));
    }

    // Update is called once per frame
    private void Update()
    {
    }

    private IEnumerator _Wait(float duration)
    {
        Vector3 mousePositionInWorld = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        getRandomVector(mousePositionInWorld - Gunfight.transform.position);

        var bullet2_1 = (GameObject)Instantiate(bullet_prefab, Gunfight.transform.position, Quaternion.identity);
        bullet2_1.GetComponent<Bullet31>().directionvector = u1;

        yield return new WaitForSeconds(duration);   //Wait
        var bullet2_2 = (GameObject)Instantiate(bullet_prefab, Gunfight.transform.position, Quaternion.identity);
        bullet2_2.GetComponent<Bullet31>().directionvector = u2;

        yield return new WaitForSeconds(duration);   //Wait
        var bullet2_3 = (GameObject)Instantiate(bullet_prefab, Gunfight.transform.position, Quaternion.identity);
        bullet2_3.GetComponent<Bullet31>().directionvector = u3;

        yield return new WaitForSeconds(duration);   //Wait
        var bullet2_4 = (GameObject)Instantiate(bullet_prefab, Gunfight.transform.position, Quaternion.identity);
        bullet2_4.GetComponent<Bullet31>().directionvector = u4;
    }

    public Vector2 getnormalizedVector(Vector2 target)
    {
        float mauso = Mathf.Sqrt(target.x * target.x + target.y * target.y);
        return new Vector2(target.x / mauso, target.y / mauso);
    }

    public void getRandomVector(Vector3 input)
    {
        float n = 0.3f;
        u1 = new Vector3(input.x + n, input.y - n, input.z);
        u2 = new Vector3(input.x + n, input.y + n, input.z);
        u3 = new Vector3(input.x - n, input.y + n, input.z);
        u4 = new Vector3(input.x - n, input.y - n, input.z);
        u5 = new Vector3(input.x + n, input.y - n, input.z);
    }
}