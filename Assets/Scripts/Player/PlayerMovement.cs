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
    private bool touchingStair = false;
    private Collider2D hitbox;
    private float hitboxOffset;

    private int health = 1;

    // Singleton functionality, there should only be one instance of this object
    public static PlayerMovement Instance {
        get;
        private set;
    }

    void Awake()
    {
        // Corrective singleton
        // We check if the instance exists
        if(Instance != null){
            Destroy(gameObject);
        } else {
            // If not, we pick the space
            Instance = this;
        }
    }

    void Start()
    {
        Rigidbody2D = GetComponent<Rigidbody2D>();
        Animator = GetComponent<Animator>();
        hitbox = GetComponent<Collider2D>();
        hitboxOffset = hitbox.offset.x;
        health += GameData.upgradeLevels["suitUpgrade"];
    }

    void Update()
    {
        Horizontal = Input.GetAxisRaw("Horizontal");
        Animator.SetBool("running", Horizontal != 0.0f);

        if (Horizontal < 0.0f)
        {
            transform.localScale = new Vector3(-0.5f, 0.5f, 1.0f);
            hitboxOffset = hitbox.offset.x * -1;
        }
        else if (Horizontal > 0.0f)
        {
            transform.localScale = new Vector3(0.5f, 0.5f, 1.0f);
            hitboxOffset = hitbox.offset.x;
        }

        Vector3 rayStart = new Vector3(Rigidbody2D.position.x + hitboxOffset, Rigidbody2D.position.y, 0);

        if (Physics2D.Raycast(rayStart, Vector3.down, 0.1f))
        {
            Grounded = true;
        }
        else
        {
            Grounded = false;
        }

        if (Input.GetKeyDown(KeyCode.W) && Grounded)
        {
            Jump();
        }

        if (Input.GetKeyDown(KeyCode.S))
        {
            if (touchingStair)
            {
                GameManager.Instance.PreviousScene();
                Speed = 0;
            }
        }
    }

    private void Jump()
    {
        Rigidbody2D.velocity = new Vector2(0, 0);
        Rigidbody2D.AddForce(Vector2.up * JumpForce);
    }

    private void FixedUpdate()
    {
        Rigidbody2D.velocity = new Vector2(Horizontal * Speed, Rigidbody2D.velocity.y);
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Finish"))
        {
            touchingStair = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Finish"))
        {
            touchingStair = false;
        }
    }

    public void getHit(int dmg)
    {
        health -= dmg;
        HUD.Instance.updateHealth();
        if(health <= 0){
            GameManager.Instance.PlayerDied();
            Speed = 0;
        }
    }

    public int GetHealth(){
        return health;
    }
    public void PushBack(Vector2 direction, float force)
    {
        Rigidbody2D.AddForce(direction * force, ForceMode2D.Impulse);
    }
}
