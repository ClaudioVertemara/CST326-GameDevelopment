using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//Claudio Vertemara
//CST 326 Mario (Project 2)
//Feb 16, 2020
public class BreakBricks : MonoBehaviour
{

    public Text coinsText;
    public int coins = 0;

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
                    Destroy(bColl.gameObject);

                    coins += 5;

                    if (coins < 10) {
                        coinsText.text = ("x 0" + coins.ToString());
                    } else {
                        coinsText.text = ("x " + coins.ToString());
                    }
                }
            }
        }
    }
}
