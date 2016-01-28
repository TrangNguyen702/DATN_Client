using UnityEngine;
using System.Collections;

public class ExplosionMovement : MonoBehaviour
{
    // Use this for initialization
    public int n;
    void Start()
    {
        n = 0;
    }

    // Update is called once per frame
    void Update()
    {
        n++;

        if (n == 20)
        {
            Destroy(gameObject);
        }
    }
}