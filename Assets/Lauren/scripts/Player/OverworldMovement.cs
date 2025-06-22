using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OverworldMovement : MonoBehaviour
{
    private Rigidbody2D rb;

    /// <summary> SPRITE STUFF FOR LATER
    /// private SpriteRenderer sprite;
    /// private Animator anim;
    /// </summary>

    //private float dirX = 0f;
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private float jumpForce = 7f;

    //underworld play
    public UnderworldMovement underworldPlayer;

    //jump
    private float jumpCooldown = 0.5f;
    private float lastJumpTime = -Mathf.Infinity;


    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        //sprite = GetComponent<SpriteRenderer>();
        //anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    private void Update()
    {
        float dirX = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(dirX * moveSpeed, rb.velocity.y);

        if (Input.GetKeyDown(KeyCode.E) && Time.time - lastJumpTime >= jumpCooldown) //E but this wil be spacebar later
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            lastJumpTime = Time.time;


            //TRIGGER REFLECT JUMP
            if (underworldPlayer != null)
            {
                underworldPlayer.Jump();
            }
        }

        //UpdateAnimationUpdate();
    }



    /*private void UpdateAnimationUpdate() sprite animations for later
    {

        if (dirX > 0f)
        {
            anim.SetBool("running" ,true);
            sprite.flipX = false;
        }
        else if (dirX < 0f)
        {
            anim.SetBool("running", true);
            sprite.flipX = true;
        }
        else
        {
            anim.SetBool("running", false);
        }
    } */
}
