using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerScanner : MonoBehaviour
{
    public ScoreManager sm;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Physics.Raycast(transform.position, transform.right, out RaycastHit rh, 10f);

        if (rh.transform != null) {
            transform.Translate(transform.up * Time.deltaTime);
            sm.UpdateScore(transform.position.y);
        }
    }
}
