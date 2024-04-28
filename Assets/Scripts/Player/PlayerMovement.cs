using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float JumpForce;
    public float Speed;

    private Rigidbody2D Rigidbody2D;
    private Animator Animator;
    private float Horizontal;
    private bool Grounded;

    void Start()
    {
        Rigidbody2D = GetComponent<Rigidbody2D>();
        Animator = GetComponent<Animator>();
    }

    void Update()
    {
        Horizontal = Input.GetAxisRaw("Horizontal");
        Animator.SetBool("running", Horizontal != 0.0f);

        if (Horizontal < 0.0f) {
            transform.localScale = new Vector3(-0.5f, 0.5f, 1.0f);
        } else if (Horizontal > 0.0f) {
            transform.localScale = new Vector3(0.5f, 0.5f, 1.0f);
        }


        if (Physics2D.Raycast(transform.position, Vector3.down, 0.1f)) {
            Grounded = true;
        } else Grounded = false;
        if (Input.GetKeyDown(KeyCode.W) && Grounded) {
            Jump();
        }
    }
    private void Jump() {
        Rigidbody2D.AddForce(Vector2.up*JumpForce);
    }

    private void FixedUpdate() {
        Rigidbody2D.velocity = new Vector2(Horizontal*Speed,Rigidbody2D.velocity.y);

    }
}
