using System.Collections;
using UnityEngine;

public class Explosion1 : MonoBehaviour
{
    // Use this for initialization
    public int n;

    private void Start()
    {
        n = 0;
    }

    // Update is called once per frame
    private void Update()
    {
        // n++;

        if (n == 20)
        {
            Destroy(gameObject);
        }
    }
}