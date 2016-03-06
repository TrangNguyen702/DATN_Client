using System.Collections;
using UnityEngine;

public class Bullet4 : MonoBehaviour
{
    // Use this for initialization
    public GameObject bullet_prefab;

    public Vector2 pullbackdirection;
    public GameObject Gunfight;

    private void Start()
    {
        Transform[] allChildren = ((GameObject)(GameObject)GameObject.Find("Tank")).transform.GetComponentsInChildren<Transform>();
        foreach (Transform t in allChildren)
        {
            if (t != null && t.gameObject.name == "Gunfight")
            {
                Gunfight = t.gameObject;
                Debug.Log("ra roi 4");
            }
        }
        Vector3 mousePositionInWorld = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        pullbackdirection = getnormalizedVector(mousePositionInWorld - Gunfight.transform.position);
        StartCoroutine(_Wait(0.1f));
    }

    // Update is called once per frame
    private void Update()
    {
    }

    private IEnumerator _Wait(float duration)
    {
        var obj = (GameObject)Instantiate(bullet_prefab, Gunfight.transform.position, Quaternion.identity);
        obj.GetComponent<Bullet4_1>().directionvector = pullbackdirection;
        yield return new WaitForSeconds(duration);   //Wait
        var obj1 = (GameObject)Instantiate(bullet_prefab, Gunfight.transform.position, Quaternion.identity);
        obj1.GetComponent<Bullet4_1>().directionvector = pullbackdirection;
        yield return new WaitForSeconds(duration);   //Wait
        var obj2 = (GameObject)Instantiate(bullet_prefab, Gunfight.transform.position, Quaternion.identity);
        obj2.GetComponent<Bullet4_1>().directionvector = pullbackdirection;
        yield return new WaitForSeconds(duration);   //Wait
        var obj3 = (GameObject)Instantiate(bullet_prefab, Gunfight.transform.position, Quaternion.identity);
        obj3.GetComponent<Bullet4_1>().directionvector = pullbackdirection;
        //yield return new WaitForSeconds(duration);   //Wait

        //var obj4 = (GameObject)Instantiate(bullet_prefab, ((GameObject)GameObject.Find("Gunfight")).transform.position, Quaternion.identity);
        //obj4.GetComponent<BulletFire>().directionvector = pullbackdirection;
    }

    public Vector2 getnormalizedVector(Vector2 target)
    {
        float mauso = Mathf.Sqrt(target.x * target.x + target.y * target.y);
        return new Vector2(target.x / mauso, target.y / mauso);
    }
}