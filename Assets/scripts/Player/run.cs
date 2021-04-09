using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class run : MonoBehaviour
{

    Rigidbody2D rb;
    float velx, vely;
    public float velocidad;
    public float alturaSalto;
    Animator anim;

    //Varibles para salto
    public Transform groundCheck;
    public bool isGrounded;
    public float radioDeteccionPiso;
    public LayerMask WhatIsGround;

    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        anim = gameObject.GetComponent<Animator>();
        
    }

    // Update is called once per frame
    void Update()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, radioDeteccionPiso, WhatIsGround);
        rotar();
    }

    private void rotar()
    {
        if (rb.velocity.x > 0)
        {
            transform.localScale = new Vector3(0.3F, 0.3F, 1);
        } 
        else {

                if (rb.velocity.x < 0)
                {
                    transform.localScale = new Vector3(-0.3F, 0.3F, 1);
                }
                    
             }
    }

    private void FixedUpdate()
    {
        Movimiento();
        salto();

        if (isGrounded) anim.SetBool("JumpPlayerBoy", false);
        else anim.SetBool("JumpPlayerBoy", true);

    }

    private void salto()
    {
        if (Input.GetButton("Jump") && isGrounded )
        {
            rb.velocity = new Vector2(rb.velocity.x, alturaSalto);
        }
        
    }

    private void Movimiento()
    {
        velx = Input.GetAxisRaw("Horizontal");
        vely = rb.velocity.y;
        rb.velocity = new Vector2(velx * velocidad, vely);

        //Agregar animaciones segun el paso
        if (rb.velocity.x != 0)
        {
            anim.SetBool("walkPlayer", true);
        }
        else {

            anim.SetBool("walkPlayer", false);
        }




    }


}
