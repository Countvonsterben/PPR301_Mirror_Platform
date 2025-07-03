using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnderworldMovement : MonoBehaviour
{
    public Transform player;
    private Rigidbody2D rb;
    //public float mirrorY = 0f;
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private float jumpForce = 7f;

    //jump
    private float jumpCooldown = 0.5f;
    private float lastJumpTime = -Mathf.Infinity;
    private bool isGrounded = false;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.gravityScale = -1f; // TEST GRAVITY -- 3/07
    }

    /* void FixedUpdate() TEST REMOVAL 3/07
    {
        if (player == null) return; THIS ISNT KEPT
        Vector3 playerPos = player.position;
         float mirroredY = mirrorY - (playerPos.y - mirrorY);
         transform.position = new Vector3(playerPos.x, mirroredY, playerPos.z);

        Vector2 currentPos = rb.position;
        rb.position = new Vector2(player.position.x, currentPos.y); */

    void Update()
    {
        float dirX = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(dirX * moveSpeed, rb.velocity.y);

        if (Input.GetKeyDown(KeyCode.E) && Time.time - lastJumpTime >= jumpCooldown && isGrounded)
        {
            rb.velocity = new Vector2(rb.velocity.x, -jumpForce);
            lastJumpTime = Time.time;
        }
    }

    public void Jump() //needed if we are doing neg gravity
    {
        rb.velocity = new Vector2(rb.velocity.x, -jumpForce);
    }

    //jump constraint test 3/07
        void OnCollisionEnter2D(Collision2D collision)
    {
        foreach (ContactPoint2D contact in collision.contacts)
        {
            if (contact.normal.y <= 0.5f)
            {
                isGrounded = true;
            }
        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        isGrounded = false;
    }
}

