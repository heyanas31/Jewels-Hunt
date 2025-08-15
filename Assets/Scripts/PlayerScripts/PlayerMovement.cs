using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    PlayerControls controls;
    public float speed = 160;
    public float jumpforce= 6.6f;
    float direction = 0;
    bool isFacingRight = true;
    bool isgrounded;
    public Transform groundcheck;
    public LayerMask groundLayer;
    public Rigidbody2D playerRB;

    public Animator animator;
    private void Awake()
    {
        controls = new PlayerControls();
        controls.Enable();
        controls.Land.Move.performed += ctx =>
        {
            direction = ctx.ReadValue<float>();
        };

        controls.Land.Jump.performed += ctx => Jump();
    }
    void FixedUpdate()
    {
        isgrounded = Physics2D.OverlapCircle(groundcheck.position, 0.1f,groundLayer);
        animator.SetBool("onground", isgrounded);
        if (playerRB != null)
        {
            playerRB.linearVelocity = new Vector2(direction * speed * Time.fixedDeltaTime, playerRB.linearVelocity.y);
        }
        animator.SetFloat("speed", Mathf.Abs(direction));

        if (isFacingRight && direction < 0 || !isFacingRight && direction > 0)
        {
            Flip();
        }
    }

    void Flip()
    {
        isFacingRight = !isFacingRight;
        transform.localScale = new Vector2(transform.localScale.x * -1, transform.localScale.y);
    }
    void Jump()
    {
        if (isgrounded)
        {
            AudioManager.instance.Play("Jump");
            if (playerRB != null)
            {
                playerRB.linearVelocity = new Vector2(playerRB.linearVelocity.x, jumpforce);
            }
        }
    }
}

