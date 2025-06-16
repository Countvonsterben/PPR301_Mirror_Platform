using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnderworldMovement : MonoBehaviour
{
    public Transform player;
    private Rigidbody2D rb;
    //public float mirrorY = 0f;
    public float jumpForce = 7f;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        if (player == null) return;
        /* Vector3 playerPos = player.position;
         float mirroredY = mirrorY - (playerPos.y - mirrorY);
         transform.position = new Vector3(playerPos.x, mirroredY, playerPos.z); */

        Vector2 currentPos = rb.position;
        rb.position = new Vector2(player.position.x, currentPos.y);
    }

    public void Jump() //needed if we are doing neg gravity
    {
        rb.velocity = new Vector2(rb.velocity.x, -jumpForce);
    }
}

