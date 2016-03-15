using System.Collections;
using UnityEngine;

public class MenuGameMovement : MonoBehaviour
{
    public Transform target;
    public float speed;
    // private Camera camera;

    // Use this for initialization
    private void Start()
    {
        //   camera = GetComponent<Camera>();
        speed = 1;
    }

    // Update is called once per frame
    private void Update()
    {
        // camera.orthographicSize = (Screen.height / 100f) / 4f;
        if (target)
        {
            transform.position = Vector3.Lerp(transform.position, target.position, speed) + new Vector3(0, -12, 0);
        }
    }
}