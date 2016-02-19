using System.Collections;
using UnityEngine;

public class ButtonOnClickScript : MonoBehaviour
{
    public UIInput HostNametxb;
    public UIInput Numbertxb;
    public UIInput Passwordtxb;

    public GameObject RowRoomPrefab;
    private int RoomNumber = 1;

    // Use this for initialization
    private void Start()
    {
        HostNametxb = GameObject.Find("HostTextbox").GetComponent<UIInput>();
        Numbertxb = GameObject.Find("NumberTextbox").GetComponent<UIInput>();
        Passwordtxb = GameObject.Find("PasswordTextbox").GetComponent<UIInput>();
    }

    private void OnClick()
    {
        if (gameObject.name == "btnAddRoom")
        {
            ((GameObject)GameObject.Find("ContentRooms")).SetActive(false);
            ((GameObject)GameObject.Find("Window")).transform.Find("ContentCreateRoom").gameObject.SetActive(true);
            GameObject.Find("TabRoom").GetComponent<UIToggledObjects>().activate[0] = GameObject.Find("ContentCreateRoom");
        }
        else if (gameObject.name == "BackToTabRooms")
        {
            ((GameObject)GameObject.Find("ContentCreateRoom")).SetActive(false);
            ((GameObject)GameObject.Find("Window")).transform.Find("ContentRooms").gameObject.SetActive(true);
            GameObject.Find("TabRoom").GetComponent<UIToggledObjects>().activate[0] = GameObject.Find("ContentRooms");
        }
        else if (gameObject.name == "CreateButton")
        {
            Debug.Log(HostNametxb.text + Numbertxb.text + Passwordtxb.text);
            GameObject mygameobject = (GameObject)Instantiate(RowRoomPrefab, new Vector3(this.transform.position.x,
                this.transform.position.y, this.RowRoomPrefab.transform.position.z), Quaternion.identity);
            //   if (Selection.activeTransform != null)
            mygameobject.transform.Find("RoomName").GetComponent<UILabel>().text = "ashdfkj";
            mygameobject.transform.localScale = new Vector3(1, 1, 1);
            //  NGUITools.AddChild((GameObject.Find("Window")).transform.Find("Grid").gameObject, mygameobject);

            //  Debug.Log(mygameobject.transform.parent.name);

            ((GameObject)GameObject.Find("ContentCreateRoom")).SetActive(false);
            ((GameObject)GameObject.Find("Window")).transform.Find("ContentRooms").gameObject.SetActive(true);
            //   GameObject.Find("Window").transform.Find("Grid").gameObject.GetComponent<UIGrid>().AddChild(mygameobject.transform);
            GameObject.Find("Grid").GetComponent<UIGrid>().AddChild(mygameobject.transform);
            mygameobject.transform.localScale = new Vector3(1, 1, 1);
            GameObject.Find("TabRoom").GetComponent<UIToggledObjects>().activate[0] = GameObject.Find("ContentRooms");
            GameObject.Find("Grid").GetComponent<UIGrid>().Reposition();
        }
    }

    // Update is called once per frame
    private void Update()
    {
    }
}