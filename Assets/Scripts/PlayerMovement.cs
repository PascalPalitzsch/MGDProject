using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed;
    private float moveDirection;
    public float minJumpForce;
    public float maxJumpForce;
    private float jumpCharge;
    public float maxJumpChargeTime;
    private float jumpChargeTimeCounter;
    private bool isChargingJump;
    private bool isGrounded;

    private Rigidbody2D rb;

    private bool moveLeft;
    private bool moveRight;

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
            // Tastatureingaben
            float horizontalInput = Input.GetAxis("Horizontal");

            // Touch-Eingaben
            if (moveLeft)
            {
                horizontalInput = -1;
            }
            else if (moveRight)
            {
                horizontalInput = 1;
            }

            rb.velocity = new Vector2(speed * horizontalInput, rb.velocity.y);
        }

        // Sprungsteuerung über Tastatur
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            StartJump();
        }
        if (Input.GetButton("Jump") && isChargingJump)
        {
            ChargeJump();
        }
        if (Input.GetButtonUp("Jump") && isChargingJump)
        {
            PerformJump();
        }
    }

    public void MoveLeft(bool isPressed)
    {
        moveLeft = isPressed;
    }

    public void MoveRight(bool isPressed)
    {
        moveRight = isPressed;
    }

    public void Jump()
    {
        if (isGrounded)
        {
            StartJump();
        }
    }

    private void StartJump()
    {
        isChargingJump = true;
        jumpChargeTimeCounter = 0f;
        jumpCharge = minJumpForce;
        rb.velocity = new Vector2(0, rb.velocity.y);  // Stop horizontal movement while charging jump
        StartCoroutine(ChargeJumpRoutine());
    }

    private IEnumerator ChargeJumpRoutine()
    {
        while (isChargingJump)
        {
            if (jumpChargeTimeCounter < maxJumpChargeTime)
            {
                jumpChargeTimeCounter += Time.deltaTime;
                jumpCharge = Mathf.Lerp(minJumpForce, maxJumpForce, jumpChargeTimeCounter / maxJumpChargeTime);
            }
            else
            {
                jumpCharge = maxJumpForce;
                break;
            }
            yield return null;
        }

        if (isChargingJump)
        {
            isChargingJump = false;
            rb.velocity = new Vector2(rb.velocity.x, jumpCharge);
        }
    }

    private void ChargeJump()
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

    private void PerformJump()
    {
        isChargingJump = false;
        rb.velocity = new Vector2(rb.velocity.x, jumpCharge);
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
