using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    GameMenu gm;

    // Start is called before the first frame update
    void Start()
    {
        gm = GameObject.Find("Canvas").GetComponent<GameMenu>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnBecameInvisible() {
        if (CompareTag("Player") || CompareTag("PlayerDelay")) {
            gm.GameOver();

            Destroy(gameObject);
        }
    }
}
