using System.Collections;
using UnityEngine;

public class HandleRoomRowClick : MonoBehaviour
{
    // Use this for initialization
    private void Start()
    {
    }

    // Update is called once per frame
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("0");
            RaycastHit2D hit = Physics2D.Raycast(GameObject.Find("Camera").GetComponent<Camera>().ScreenToWorldPoint(Input.mousePosition), Vector3.zero);  //click vao dap a
            Debug.Log("1");
            //   if (hit.collider == null) return;
            Debug.Log("2");
            if (hit.collider.gameObject.tag == "HandleClickRoomRow")
            {
                Debug.Log("abc");
            }
        }
    }
}