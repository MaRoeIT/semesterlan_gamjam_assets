using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_controller_top_down : MonoBehaviour
{
    // Variabel for å sette hastigheten til karakteren
    public float character_speed = 5f;
    // Variabel som holder på elementet sin rigidbody, brukes for å bevege karakteren. Husk å drag and dropp rigidbody fra karakteren inn på denne i inspektoren på unity.
    public Rigidbody2D rigid_body;
    // Variable for å holde på animatoren til elementet. Husk å drag and dropp Animator fra karakteren inn på denne i inspektoren på unity.
    public Animator animator;
    // Variabel for å holde på x og y aksene
    Vector2 movment;

    // Update oppdaterer seg basert på frame rate
    void Update()
    {
        // setter y og x aksene til å justeres basert på input.
        movment.x = Input.GetAxisRaw("Horizontal");
        movment.y = Input.GetAxisRaw("Vertical");
        // setter parameter bool til animator kalt idle til true når hastigheten på karakteren er 0
        if (animator.GetFloat("speed") == 0f )
        {
            animator.SetBool("idle", true);
        }
        else
        {
            animator.SetBool("idle", false);
        }

        // Setter parameterne i animatoren til å endre basert på bevegelsene til karakteren.
        animator.SetFloat("horizontal", movment.x);
        animator.SetFloat("vertical", movment.y);
        animator.SetFloat("speed", movment.sqrMagnitude);
        
    }

    // Fixed update oppdaterer 50 ganger i sekundet og derfor er mer stabilt vis man skal gjøre ting som krever pyshics slik at det ikke varierer basert på frame rate
    void FixedUpdate()
    {
        // bevegelsen for karkateren
        rigid_body.MovePosition(rigid_body.position + movment * character_speed * Time.fixedDeltaTime);
    }
}
