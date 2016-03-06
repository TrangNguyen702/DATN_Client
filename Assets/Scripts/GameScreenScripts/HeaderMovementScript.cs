using System.Collections;
using UnityEngine;

public class HeaderMovementScript : MonoBehaviour
{
    private System.Random rand = new System.Random();
    public GameObject bullet_prefab;
    private Animator anim;
    public Vector2 pullbackdirection;

    public Vector3 u1;
    public Vector3 u2;
    public Vector3 u3;
    public Vector3 u4;
    public Vector3 u5;

    public int typeofbullet;
    public GameObject[] bulletprefab = new GameObject[4];

    private SpriteRenderer headspriterender;
    public Sprite head1;
    public Sprite head2;
    public Sprite head3;
    public Sprite head4;

    public int strength = 100;
    public int strengthmax = 100;

    public GameObject progressbar;
    public GameObject Gunfight;
    public GameObject thebody;

    public enum SpritePackingRotation
    {
        up = -90,
        right = 0,
        downad = 90,
        left = 180
    }

    public SpritePackingRotation initial;

    // Use this for initialization
    private void Start()
    {
        Transform[] allChildren = this.transform.parent.GetComponentsInChildren<Transform>();
        foreach (Transform t in allChildren)
        {
            if (t != null && t.gameObject.name == "ProgressContent")
                progressbar = t.gameObject;
            else if (t != null && t.gameObject.name == "Gunfight")
            {
                Gunfight = t.gameObject;
                // Debug.Log("ra roi ");
            }
            else if (t != null && t.gameObject.name == "Body")
            {
                thebody = t.gameObject;
            }
        }

        headspriterender = gameObject.GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
        typeofbullet = 1;
    }

    // Update is called once per frame
    private void Update()
    {
        Vector3 mousePositionInWorld = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 toMousePosition = ((Vector2)mousePositionInWorld - (Vector2)transform.position).normalized;
        float AngleRad = Mathf.Atan2(toMousePosition.y, toMousePosition.x) * Mathf.Rad2Deg + (int)initial; ;
        this.transform.rotation = Quaternion.AngleAxis(AngleRad, Vector3.forward);

        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector3.zero);  //click vao dap a4
            if (hit.collider == null)
            {
                if (typeofbullet == 1)
                {
                    var obj1 = (GameObject)Instantiate(bulletprefab[0], Gunfight.transform.position, Quaternion.identity);
                    pullbackdirection = getnormalizedVector(mousePositionInWorld - obj1.transform.position);
                    obj1.GetComponent<Bullet1>().directionvector = pullbackdirection;
                    //giat sung
                    StartCoroutine(_Wait(0.1f));
                }
                else if (typeofbullet == 2)//dan chum// script la 3
                {
                    var bullet3 = (GameObject)Instantiate(bulletprefab[1], Gunfight.transform.position, Quaternion.identity);
                }
                else if (typeofbullet == 3) // dan lua , script la 4
                {
                    var bullet3 = (GameObject)Instantiate(bulletprefab[2], Gunfight.transform.position, Quaternion.identity);
                }
                else if (typeofbullet == 4) //dan electronic// script la 2
                {
                    var bullet4 = (GameObject)Instantiate(bulletprefab[3], new Vector3(Gunfight.transform.position.x, Gunfight.transform.position.y, this.transform.position.z + 1), Quaternion.identity);
                    bullet4.transform.rotation = Quaternion.Euler(0, 0, AngleRad);
                    bullet4.transform.parent = this.transform;
                }
            }
            else if (hit.collider.tag != "gamemenuitem")
            {
                if (typeofbullet == 1)
                {
                    var obj1 = (GameObject)Instantiate(bulletprefab[0], Gunfight.transform.position, Quaternion.identity);
                    pullbackdirection = getnormalizedVector(mousePositionInWorld - obj1.transform.position);
                    obj1.GetComponent<Bullet1>().directionvector = pullbackdirection;
                    //giat sung
                    StartCoroutine(_Wait(0.1f));
                }
                else if (typeofbullet == 2)//dan chum// script la 3
                {
                    var bullet3 = (GameObject)Instantiate(bulletprefab[1], Gunfight.transform.position, Quaternion.identity);
                    //  bullet3.GetComponent<Bullet3>().Gunfight = Gunfight;
                }
                else if (typeofbullet == 3) // dan lua , script la 4
                {
                    var bullet3 = (GameObject)Instantiate(bulletprefab[2], Gunfight.transform.position, Quaternion.identity);
                    // bullet3.GetComponent<Bullet4>().Gunfight = Gunfight;
                }
                else if (typeofbullet == 4) //dan electronic// script la 2
                {
                    var bullet4 = (GameObject)Instantiate(bulletprefab[3], new Vector3(Gunfight.transform.position.x, Gunfight.transform.position.y, this.transform.position.z + 1), Quaternion.identity);

                    bullet4.transform.rotation = Quaternion.Euler(0, 0, AngleRad);
                    bullet4.transform.parent = this.transform;
                }
            }
            else {
                if (hit.collider.gameObject.name == "Item1")
                {
                    headspriterender.sprite = head1;
                    typeofbullet = 1;
                }
                else if (hit.collider.gameObject.name == "Item2")
                {
                    headspriterender.sprite = head2;
                    typeofbullet = 2;
                }
                else if (hit.collider.gameObject.name == "Item3")
                {
                    headspriterender.sprite = head3;
                    typeofbullet = 3;
                }
                else if (hit.collider.gameObject.name == "Item4")
                {
                    headspriterender.sprite = head4;
                    typeofbullet = 4;
                }
            }
        }
    }

    public Vector2 getnormalizedVector(Vector2 target)
    {
        float mauso = Mathf.Sqrt(target.x * target.x + target.y * target.y);
        return new Vector2(target.x / mauso, target.y / mauso);
    }

    private IEnumerator _Wait(float duration)
    {
        transform.position -= new Vector3(pullbackdirection.x * Time.deltaTime, pullbackdirection.y * Time.deltaTime, 0);
        //  Debug.Log("chay");
        yield return new WaitForSeconds(duration);   //Wait
        transform.position = thebody.transform.position;
    }

    public void getRandomVector(Vector3 input)
    {
        u1 = new Vector3(input.x + 0.1f, input.y - 0.1f, input.z);
        u2 = new Vector3(input.x + 0.1f, input.y + 0.1f, input.z);
        u3 = new Vector3(input.x - 0.1f, input.y + 0.1f, input.z);
        u4 = new Vector3(input.x - 0.1f, input.y - 0.1f, input.z);
        u5 = new Vector3(input.x + 0.2f, input.y - 0.2f, input.z);
    }

    public void strengthchange(int n)
    {
        strength -= n;
        if (strength >= 0)
        {
            float i = strength / strengthmax;
            progressbar.GetComponent<ProgressBar>().SetHealthBar(i);
        }
    }
}