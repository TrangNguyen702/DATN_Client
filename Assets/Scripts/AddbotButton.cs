using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class AddbotButton : MonoBehaviour
{
    public GameObject _myPrefabs;
    private int count = 0;
    private System.Random rand = new System.Random();

    // Use this for initialization
    private void Start()
    {
        this.GetComponent<Button>().onClick.AddListener(delegate { OnClickHandle(); });
    }

    // Update is called once per frame
    private void Update()
    {
    }

    private void OnClickHandle()
    {
        if (_myPrefabs != null)
        {
            for (int i = 0; i < 20; i++)
                Instantiate(_myPrefabs, new Vector3(RandomNumber(1), RandomNumber(2), 0), Quaternion.identity);
            count += 20;
        }
        Debug.Log(count);
    }

    private int RandomNumber(int check)
    {
        if (check == 1)
            return rand.Next(-4, 9);
        else return rand.Next(-6, 2);
    }
}