using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Claudio Vertemara
//CST 326 Mario (Project 2)
//Feb 23, 2020

public class CameraFollow : MonoBehaviour
{
    public Transform target;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (target != null) {
            transform.position = new Vector3(target.position.x, transform.position.y, transform.position.z);
        }
    }
}
