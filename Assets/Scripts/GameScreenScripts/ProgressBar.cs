using System.Collections;
using UnityEngine;

public class ProgressBar : MonoBehaviour
{
    // Use this for initialization
    private float myhelth;

    private void Start()
    {
        myhelth = 1f;
    }

    // Update is called once per frame
    private void Update()
    {
        //if (Input.GetMouseButtonDown(0))
        //{
        //    myhelth -= 0.1f;
        //    SetHealthBar(myhelth);
        //}
    }

    public void SetHealthBar(float myHealth)
    {
        this.transform.localScale = new Vector3(Mathf.Clamp(myHealth, 0f, 1f), this.transform.localScale.y, this.transform.localScale.z);
    }
}