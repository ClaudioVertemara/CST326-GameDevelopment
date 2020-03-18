using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackEnemyOnClick : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0)) {

            RaycastHit hit;

            if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit)) {

                BoxCollider bColl = hit.collider as BoxCollider;

                if (bColl != null) {
                    if (bColl.gameObject.name == "Cube") {
                        bColl.gameObject.GetComponentInParent<Enemy>().ReduceHealth();
                    }
                }
            }
        }
    }
}
