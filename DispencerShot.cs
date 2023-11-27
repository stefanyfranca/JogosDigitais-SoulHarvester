using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DispencerShot : MonoBehaviour
{
    public GameObject targetbolinha;
    public GameObject circulo;
    public float forca;
    // Start is called before the first frame update
    public void Bolinha()
        {
            GameObject obj = Instantiate(circulo, targetbolinha.transform.position, Quaternion.identity);
            obj.GetComponent<Rigidbody2D>().AddForce(Vector2.left * forca, ForceMode2D.Impulse);
        }
    

    void Start()
    {
        InvokeRepeating("Bolinha",0f,2f);
    }

    // Update is called once per frame
    void Update()
    {
    }
}
