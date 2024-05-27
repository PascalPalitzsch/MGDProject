using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed;
    private float Move;
    public float minJumpForce;
    public float maxJumpForce;
    private float jumpCharge;
    public float maxJumpChargeTime;
    private float jumpChargeTimeCounter;
    private bool isChargingJump;
    private bool isGrounded;

    private Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!isChargingJump)
        {
            Move = Input.GetAxis("Horizontal");
            rb.velocity = new Vector2(speed * Move, rb.velocity.y);
        }

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            isChargingJump = true;
            jumpChargeTimeCounter = 0f;
            jumpCharge = minJumpForce;
            rb.velocity = new Vector2(0, rb.velocity.y);  // Stop horizontal movement while charging jump
        }

        if (Input.GetButton("Jump") && isChargingJump)
        {
            if (jumpChargeTimeCounter < maxJumpChargeTime)
            {
                jumpChargeTimeCounter += Time.deltaTime;
                jumpCharge = Mathf.Lerp(minJumpForce, maxJumpForce, jumpChargeTimeCounter / maxJumpChargeTime);
            }
            else
            {
                jumpCharge = maxJumpForce;
            }
        }

        if (Input.GetButtonUp("Jump") && isChargingJump)
        {
            isChargingJump = false;
            rb.velocity = new Vector2(rb.velocity.x, jumpCharge);
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            isGrounded = false;
        }
    }
}
