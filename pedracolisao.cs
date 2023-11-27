using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pedracolisao : MonoBehaviour
{
public HeartSystem heart;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            heart.vida--;
        }
    }
}
