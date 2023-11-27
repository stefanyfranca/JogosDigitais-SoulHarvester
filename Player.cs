using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float moveSpeed = 6f; //valocidade de movimento do personagem
    public float jumpForce;
    private Rigidbody2D rig;
    public bool isjumping;
    private Animator anim;
    public GameObject target;
    public GameObject shot;
    public float forca;
    public HeartSystem heart;

    void Start()
    {
         rig = GetComponent<Rigidbody2D>();
         anim = gameObject.GetComponent<Animator>();
    }

    void FixedUpdate()//metodo ultilizado na física.
    {
        jump();
        move();//função de mover o persongem
    }
     void Update()
    {
        Gun();
        jump();
        

        if(rig.velocity.x > 0)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }
        
        if(rig.velocity.x < 0)
        {
            transform.localScale = new Vector3(1, 1, 1);
        }

        if(rig.velocity.x > -0.5f && rig.velocity.x < 0.5f){
            anim.SetInteger("mod", 0);
        }else{
            anim.SetInteger("mod", 1);
        }
        
    }
    void move()
    {
        float a = Input.GetAxis("Horizontal");
        RaycastHit2D hit = Physics2D.Raycast(transform.position, transform.forward, 1f);
        Debug.DrawRay(transform.position, transform.forward * 1f, Color.red);

        rig.velocity = new Vector2(a * moveSpeed, rig.velocity.y);
    }
    void jump()
    {
        if(Input.GetButtonDown("Jump") && !isjumping)
        {
            rig.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            isjumping = true;
        }
    }

    public void Gun()
    {
        if(Input.GetMouseButtonDown(0) && Input.GetKey(KeyCode.A))
        {
            GameObject obj = Instantiate(shot, target.transform.position, Quaternion.identity);
            obj.GetComponent<Rigidbody2D>().AddForce(Vector2.left * forca, ForceMode2D.Impulse);
        }
        else if(Input.GetMouseButtonDown(0) && Input.GetKey(KeyCode.D))
        {
            GameObject obj = Instantiate(shot, target.transform.position, Quaternion.identity);
            obj.GetComponent<Rigidbody2D>().AddForce(Vector2.right * forca, ForceMode2D.Impulse);
        }
    }
  
    public void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.layer == 3)
        {
            isjumping = false;
        }

        if(collision.gameObject.tag == "bolinha")
        {
            heart.vida--;
        }
    }
    
}
