using System.Collections;
using UnityEngine;

public class CreateMap : MonoBehaviour
{
    public GameObject HomeTownMap;
    public GameObject MatrixMap;
    public GameObject RainForest;
    public GameObject Desert;
    public int index;

    // Use this for initialization
    private void Start()
    {
        index = 0;
        //int index = clickhd.mapSelectedIndex;

        if (index == 0)
        {
            Instantiate(HomeTownMap, new Vector3(-10, 10, 0), Quaternion.identity);
        }
        else if (index == 1)
        {
            Instantiate(MatrixMap, new Vector3(0, 0, 0), Quaternion.identity);
        }
        else if (index == 2)
        {
            Instantiate(RainForest, new Vector3(0, 0, 0), Quaternion.identity);
        }
        else if (index == 3)
        {
            Instantiate(Desert, new Vector3(0, 0, 0), Quaternion.identity);
        }
    }

    // Update is called once per frame
    private void Update()
    {
    }
}