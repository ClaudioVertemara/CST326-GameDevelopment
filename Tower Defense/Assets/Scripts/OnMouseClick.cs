using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnMouseClick : MonoBehaviour
{
    public GameObject coinManager;
    public GameObject weapon;

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

                    if (bColl.gameObject.name.Contains("WeaponBase") && bColl.gameObject.tag != "WeaponAdded") {

                        if (coinManager.GetComponent<CoinManager>().BuyWeapon()) {
                            Instantiate(weapon, bColl.gameObject.transform.position, Quaternion.identity, bColl.gameObject.transform);

                            bColl.gameObject.tag = "WeaponAdded";
                        } else {
                            Debug.Log("Not Enough Coins!");
                        }
                    }
                }
            }
        }
    }
}
