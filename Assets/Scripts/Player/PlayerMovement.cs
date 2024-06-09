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
    private Collider2D hitbox;
    private float hitboxOffset;

    void Start()
    {
        Rigidbody2D = GetComponent<Rigidbody2D>();
        Animator = GetComponent<Animator>();
        // Used to calculate the offset of the hitbox for the ground collision
        hitbox = GetComponent<Collider2D>();
        hitboxOffset = hitbox.offset.x;
    }

    void Update()
    {
        Horizontal = Input.GetAxisRaw("Horizontal");
        Animator.SetBool("running", Horizontal != 0.0f);

        if (Horizontal < 0.0f) {
            transform.localScale = new Vector3(-0.5f, 0.5f, 1.0f);
            hitboxOffset = hitbox.offset.x  * -1;
        } else if (Horizontal > 0.0f) {
            transform.localScale = new Vector3(0.5f, 0.5f, 1.0f);
            hitboxOffset = hitbox.offset.x;
        }

        Vector3 rayStart = new Vector3(Rigidbody2D.position.x + hitboxOffset, Rigidbody2D.position.y, 0);
        
        Debug.DrawRay(rayStart, Vector3.down, Color.white);
        if (Physics2D.Raycast(rayStart, Vector3.down, 0.1f)) {
            Grounded = true;
        } else Grounded = false;
        if (Input.GetKeyDown(KeyCode.W) && Grounded) {
            Jump();
        }
    }
    private void Jump() {
        Rigidbody2D.velocity = new Vector2(0,0);
        Rigidbody2D.AddForce(Vector2.up*JumpForce);
    }

    private void FixedUpdate() {
        Rigidbody2D.velocity = new Vector2(Horizontal*Speed,Rigidbody2D.velocity.y);
    }
    public void OnTriggerStay2D(Collider2D other) {
        if (other.CompareTag("Finish") && Input.GetKeyDown(KeyCode.S)) {
            GameManager.Instance.PreviousScene();
        }
    }
}
