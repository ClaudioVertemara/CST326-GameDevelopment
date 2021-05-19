using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TowerScript : MonoBehaviour
{
    public bool isTower = false;
    public bool isTop = false;
    public bool upgradeLock=false;
    private bool spawnNext = true;
    private Rigidbody rb;
    private int delay=0;
    public GameObject Camera;
    public float moveSpeed = 4.0f;
    public Transform goal;
    public Button right;
    public Button left;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(StartCounter());
        Camera = GameObject.Find("Main Camera");
        rb = GetComponent<Rigidbody>();

        right = GameObject.FindGameObjectWithTag("RightButton").GetComponent<Button>();
        left = GameObject.FindGameObjectWithTag("LeftButton").GetComponent<Button>();
        right.onClick.AddListener(rightButton);
        left.onClick.AddListener(leftButton);
    }

    // Update is called once per frame

    //TODO
    /*
        increase camera height(and distance back), spawn speed, spawn height
                these are to make it so visibility improves,
                spawn height gives moretime,(better than making objects fall slower
                spawn rate makes more of a sense of urgency as it currently is too relaxed
         */
    void Update()
    {
        transform.rotation *= Quaternion.Euler(0, 0, 0);
        Vector3 temp = transform.position;
        temp.z = 0;
        transform.position = temp;
        if (transform.tag == "Player" || transform.tag == "PlayerDelay")
        {
            if (Input.GetButton("Horizontal") && Input.GetAxis("Horizontal") > 0)
            {
                Vector3 pos = transform.position;
                pos.x += .01f;
                float step = moveSpeed * Time.deltaTime;
                transform.position = Vector3.Lerp(transform.position, pos, moveSpeed);
            }
            if(Input.GetButton("Horizontal") && Input.GetAxis("Horizontal") < 0)
            {
                Vector3 pos = transform.position;
                pos.x -= .01f;
                float step = moveSpeed * Time.deltaTime;
                transform.position = Vector3.Lerp(transform.position, pos, moveSpeed);
            }
        }
        if (!upgradeLock && isTower && !isTop)
        {
            delay += 1;
            if (delay > 100)
            {
                upgradeLock = true;
                isTop = true;
                transform.tag = "Tower";
                if (spawnNext) {
                    spawnNext = false;
                    Camera.GetComponent<SpawnerScript>().SpawnUpdated();
                }
                Vector3 pos = transform.position;
                Camera.GetComponent<SpawnerScript>().setMax(pos.y+1.0f+transform.localScale.y);
            }
        }
    }

    void leftButton() {
        if (transform.tag == "Player" || transform.tag == "PlayerDelay") {
            Vector3 pos = transform.position;
            pos.x -= .1f;
            float step = moveSpeed * Time.deltaTime;
            transform.position = Vector3.Lerp(transform.position, pos, moveSpeed);
        }
    }

    void rightButton() {
        if (transform.tag == "Player" || transform.tag == "PlayerDelay") {
            Vector3 pos = transform.position;
            pos.x += .1f;
            float step = moveSpeed * Time.deltaTime;
            transform.position = Vector3.Lerp(transform.position, pos, moveSpeed);
        }
    }

    void OnBecameInvisible()
    {
        if (transform.tag == "Player" || transform.tag == "PlayerDelay")
        {
            GameObject.Find("Canvas").GetComponent<GameMenu>().GameOver();
        }
        rb.constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationY | RigidbodyConstraints.FreezeRotationZ | RigidbodyConstraints.FreezePositionZ | RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezePosition;
    }
    private IEnumerator StartCounter() {
        yield return new WaitForSeconds(10);
        rb.constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationY | RigidbodyConstraints.FreezeRotationZ | RigidbodyConstraints.FreezePositionZ | RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezePosition;
    }
        public bool getTower()
    {
        return isTower;
    }
    public bool getTop()
    {
        return isTop;
    }
    public void setTower(bool val)
    {
        isTower = val;
    }
    public void setTop(bool val)
    {
        isTop = val;
    }
    void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag == "Tower" && transform.tag=="Player")
        {
            if (collision.transform.GetComponent<TowerScript>().getTop() || collision.transform.GetComponent<TowerScript>().getTower() && !getTower())
            {
                setTower(true);
                collision.transform.GetComponent<TowerScript>().setTop(false);
                transform.tag = "PlayerDelay";
            }
        }

    }
}
