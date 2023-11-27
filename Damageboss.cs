using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damageboss : MonoBehaviour
{
    // Start is called before the first frame update
    public HeartSystem heart;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            heart.vida--;
        }
    }
}
