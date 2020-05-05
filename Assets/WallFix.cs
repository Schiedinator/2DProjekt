using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallFix : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            print("Hello");
            collision.gameObject.GetComponent<PlayerController>().enabled = false;
        }
    }
}
