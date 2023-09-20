using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float movementSpeed;
    [SerializeField] public Rigidbody2D rb;
    [SerializeField] public Transform rbT;
    [SerializeField] public Transform foot_1;
    [SerializeField] public Transform foot_2;
    [SerializeField] public Transform foot_3;
    [SerializeField] public Transform foot_4;
    [SerializeField] public LayerMask groundLayers;
    [SerializeField] public LayerMask jumpingPad;
    [SerializeField] float gravity = 5f;
    public int extraJumps=1;
    int jumpCount = 0;
    float jumpCooldown, dashCooldown;
    public float jumpForce = 20f;
    public bool isGrounded;
    public float dashDistance = 15f;
    bool isDashing;
    int dashCount = 0;
    public float rotationPower;
    private bool rotating = false;
    public GameObject particles;
    public GameObject trail;

    float mx;

    void Update()
    {
            mx = Input.GetAxisRaw("Horizontal");

            if (Input.GetButtonDown("Jump"))
                Jump();

            if (Input.GetKeyDown(KeyCode.LeftShift))
                StartCoroutine(Dash());
        /*
        if (!rotating && !isGrounded) 
            StartCoroutine(Rotate(Vector3.forward * -90, 0.2f));
        */
            AntiGravity();
            CheckGrounded();
            SetParticlesActive();
            SetTrailActive();
            JumpingPad();
    }

    private void FixedUpdate()
    {
        if(!isDashing)
            rb.velocity = new Vector2(movementSpeed, rb.velocity.y);
    }

    void Jump()
    {
        if (isGrounded)
        {
            /*
            movementSpeed = 50f;
            if (gravity > 0f)
                gravity = -500f;
            else
                gravity = 500f;
            */
            movementSpeed = 11f;
            if (isGrounded || jumpCount < extraJumps)
            {
                Vector2 movement = new Vector2(rb.velocity.x, jumpForce);
                rb.velocity = movement;
                jumpCount++;
            }
        }

    }

    void JumpingPad()
    {
        if (Physics2D.OverlapCircle(foot_1.position, 0.5f, jumpingPad) || Physics2D.OverlapCircle(foot_2.position, 0.5f, jumpingPad) ||
            Physics2D.OverlapCircle(foot_3.position, 0.5f, jumpingPad) || Physics2D.OverlapCircle(foot_4.position, 0.5f, jumpingPad))
        {
            Vector2 movement = new Vector2(rb.velocity.x, 25f);
            rb.velocity = movement;
        }
    }


    void CheckGrounded()
    {
        if (Physics2D.OverlapCircle(foot_1.position, 0.5f, groundLayers) || Physics2D.OverlapCircle(foot_2.position, 0.5f, groundLayers) ||
            Physics2D.OverlapCircle(foot_3.position, 0.5f, groundLayers) || Physics2D.OverlapCircle(foot_4.position, 0.5f, groundLayers))
        {
            rb.gravityScale = gravity;
            dashCount = 0;
            isGrounded = true;
            jumpCount = 0;
            jumpCooldown = Time.time + 0.0f;
        }
        else
        {
            if (Time.time < jumpCooldown)
                isGrounded = true;
            else
                isGrounded = false;
        }
    }

    IEnumerator Dash()
    {
        if (dashCount==0)
        {
            dashCount++;
            isDashing = true;
            rb.velocity = new Vector2(50f, 0f);
            rb.AddForce(new Vector2(dashDistance, 0f), ForceMode2D.Impulse);
            gravity = rb.gravityScale;
            rb.gravityScale = 0;
            yield return new WaitForSeconds(0.15f);
            rb.gravityScale = gravity;
            isDashing = false;
        }
    }

    private IEnumerator Rotate(Vector3 angles, float duration)
    {
        rotating = true;
        Quaternion startRotation = rb.transform.rotation;
        Quaternion endRotation = Quaternion.Euler(angles) * startRotation;
        for (float t = 0; t < duration; t += Time.deltaTime)
        {
            rb.transform.rotation = Quaternion.Lerp(startRotation, endRotation, t / duration);
            yield return null;
        }
        rb.transform.rotation = endRotation;
        rotating = false;
    }

    void SetParticlesActive()
    {
        if (isGrounded)
            particles.SetActive(true);
        else
            particles.SetActive(false);
    }

    public void SetTrailActive()
    {
          trail.SetActive(false);
    }

    void AntiGravity()
    {
        try
        {
            if (inPortal.instance.hit)
            {
                gravity = -5f;
                rb.gravityScale = gravity;
                jumpForce = -17f;
            }
            else
            {
                gravity = 5f;
                rb.gravityScale = gravity;
                jumpForce = 17f;
            }
        }
        catch
        {
            gravity = 5f;
            rb.gravityScale = gravity;
            jumpForce = 17f;
        }
    }

}
