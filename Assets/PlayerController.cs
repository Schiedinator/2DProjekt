using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rb;
    private Animator anim;
    private enum State { idle, running, jumping}
    private State state = State.idle;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        float hdirection = Input.GetAxis("Horizontal");

        if (hdirection < 0)
        {
            rb.velocity = new Vector2(-5, rb.velocity.y);
            transform.localScale = new Vector2(-1, 1);
        }

        else if (hdirection > 0)
        {
            rb.velocity = new Vector2(5, rb.velocity.y);
            transform.localScale = new Vector2(1, 1);
        }

        else
        {
            //anim.SetBool("running", false );
        }

        if (Input.GetButtonDown("Jump"))                                                                       //  über   inputs                       GetKeyDown(KeyCode.Space))    old
        {
            rb.velocity = new Vector2(rb.velocity.x, 10f);
            state = State.jumping;      //damit spiel weis das mir springen
        }

        VelocityState();                                                                                                                            //rennt die zeilen 50 bis 68                    ist eine "methode"
        anim.SetInteger("state", (int)state);          //state int davor weil Zeile 9 sind ja nummern, deshalb kann man als int bezeichnen              system aktualisiert automatisch unseren status von charakterS

    }

    private void VelocityState()
    {
        if(state == State.jumping)
        {

        }

        else if(Mathf.Abs(rb.velocity.x) > 2f) //epsilon wenn es einfach höher als 0 ist, besser als 0.xxxx - kleinstgröße nummer - alt if(rb.velocity.x > 0.1f)     Returns the smallest integral value that is greater than or equal to the specified single-precision floating-point number        old > Mathf.Epsilon
                                                 //gibt ein kleinen slide wenn 2f
        {
            //Moving
            state = State.running;
        }
        else
        {
            state = State.idle;     //wenn er nicht mehr rennen soll
        }

    }
}