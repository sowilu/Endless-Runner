using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float jumpHeight = 5f;

    private bool isGrounded = true;
    private bool isCrouched = false;
    private Rigidbody2D rb;
    private Animator animator;
    private CapsuleCollider2D capsuleCollider;
    private Vector2 colliderSize;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        capsuleCollider = GetComponent<CapsuleCollider2D>();
        colliderSize = capsuleCollider.size;
    }

    void Update()
    {
        //JUMP
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded && !isCrouched)
        {
            var jumpVelocity = Mathf.Sqrt(2 * jumpHeight * Mathf.Abs(Physics2D.gravity.y * rb.gravityScale));
            rb.velocity = new Vector2(rb.velocity.x, jumpVelocity);
            isGrounded = false;
            animator.speed = 0;
        }

        //CROUCH
        if (isGrounded && (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow)))
        {
            isCrouched = true;
            transform.localScale = new Vector3(-1.2f, 0.5f, 1);
            capsuleCollider.size = new Vector2(capsuleCollider.size.x / 2, capsuleCollider.size.y / 3);
        }
        else if (Input.GetKeyUp(KeyCode.S) || Input.GetKeyUp(KeyCode.DownArrow))
        {
            isCrouched = false;
            transform.localScale = new Vector3(-1, 1, 1);
            capsuleCollider.size = colliderSize;
        }
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        animator.speed = 1;
        isGrounded = true;
    }
}
