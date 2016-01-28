using System.Collections;
using UnityEngine;

public class clickhd : MonoBehaviour
{
    // Use this for initialization
    public static int mapSelectedIndex = 2;

    public UICenterOnChild mapSelected;

    public UIGrid mapList;

    private void Start()
    {
        mapSelected = GameObject.Find("UIGrid").GetComponent<UICenterOnChild>();
        mapList = GameObject.Find("UIGrid").GetComponent<UIGrid>();
    }

    // Update is called once per frame
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit2D hit = Physics2D.Raycast(GameObject.Find("Camera").GetComponent<Camera>().ScreenToWorldPoint(Input.mousePosition), Vector3.zero);  //click vao dap a
            if (hit.collider == null) return;
            if (hit.collider.gameObject.tag == "u1")
            {
                mapSelectedIndex = mapList.GetIndex(mapSelected.centeredObject.transform);
                AutoFade.LoadLevel("playscreen", 1.2f);
            }
        }
    }
}