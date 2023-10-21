using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class PlayerController : MonoBehaviour
{

    
    private float horizontal;
    public float speed = 200;
    public float jumpForce = 200;
    private float firstspeed, firstjump;
    public static bool hatModeForAnim;
    private bool rtoate;
    private bool IsJumping;
    private Vector3 scale;
    private bool isGrounded = true;
    [HideInInspector]public bool isdead;

    //Wall Slide
    private bool isWallSliding;
    private float wallSlidingSpeed = 2f;
    [SerializeField]private Transform wallCheckPoint;
    [SerializeField]private LayerMask wallLayer;

    //Wall Jump
    private bool isWallJumping;
    private float wallJumpingDirection;
    private float wallJumpingTime = 0.2f;
    private float wallJumpingCounter;
    private float wallJumpingDuration = 0.4f;
    [SerializeField]private Vector2 wallJumpingPower = new Vector2(8f, 16f);

    [SerializeField] private float wevaspeed = 250, wevajumpForce = 250;
    [HideInInspector] public bool invicible = false;
    [HideInInspector] public Vector2 checkPoint;

    private Animator anim;
    private ParticleSystem particleSystemm;
    private Rigidbody2D rb;

    void Start()
    {
        particleSystemm = GetComponentInChildren<ParticleSystem>();
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        firstjump = jumpForce;
        firstspeed = speed;

    }

    void Update()
    {

        if (GameObject.FindGameObjectWithTag("Whimsy").GetComponent<whimsyfallow>().hat)
        {
            hatModeForAnim = true;
        }

        else
        {
            hatModeForAnim = false;
        }


        if (rb.velocity.magnitude > 0.1f) // Karakter hareket ediyorsa
        {
            if (particleSystemm.isPlaying == false)
            {
                particleSystemm.Play();
            }
        }
        else // Karakter yerinde duruyorsa
        {
            particleSystemm.Stop();
        }

        anim.SetBool("HatModeAnim", hatModeForAnim);

        WallSlide();
        WallJump();

        if (!isWallJumping)
        {
            Flip();
        }

        if (!isdead)
        {
            if (GameObject.FindGameObjectWithTag("Whimsy").GetComponent<whimsyfallow>().hatmode)
            {
                jumpForce = wevajumpForce;
                speed = wevaspeed;
                if (!GameObject.FindGameObjectWithTag("Whimsy").GetComponent<whimsyfallow>().hat)
                {
                    GameObject.FindGameObjectWithTag("Whimsy").transform.localScale = new Vector2(this.transform.localScale.x, this.transform.localScale.y);
                }
            }
            else
            {
                jumpForce = firstjump;
                speed = firstspeed;
            }
        }
        

        if (Input.GetButtonDown("Jump"))
        {

            if (!IsJumping)
            {

                rb.velocity = Vector2.zero;

                rb.AddForce(new Vector2(0, jumpForce));

                IsJumping = true;

            }

        }

        if (horizontal != 0)
        {

            whimsu.isRandomMoving = false;

        }

        else
        {
            whimsu.isRandomMoving = true;
        }

    }

    private void FixedUpdate()
    {

        anim.SetFloat("speed", Mathf.Abs(horizontal));
        horizontal = Input.GetAxisRaw("Horizontal");

        if (!isWallJumping)
        {
            rb.velocity = new Vector2(horizontal * Time.deltaTime * speed, rb.velocity.y);
        }
        

        if (horizontal < 0 && rtoate == false)
        {

            if (GameObject.Find("Camera").GetComponent<CameraFollow>().isFollowingCharachter)
                GameObject.Find("Camera").GetComponent<CameraFollow>().isFollowingOffset.x = -1;

            Flip();

        }

        else if (horizontal > 0 && rtoate == true)
        {

            Flip();

            if (GameObject.Find("Camera").GetComponent<CameraFollow>().isFollowingCharachter)
                GameObject.Find("Camera").GetComponent<CameraFollow>().isFollowingOffset.x = 1;

        }

    }

    private void WallJump()
    {
        if (Input.GetAxis("Horizontal") == 0)
        {
            return;
        }
        if (isWallSliding)
        {
            isWallJumping = false;
            wallJumpingDirection = -transform.localScale.x;
            wallJumpingCounter = wallJumpingTime;

            CancelInvoke(nameof(StopWallJumping));
        }
        else
        {
            wallJumpingCounter -= Time.deltaTime;
        }

        if (Input.GetButtonDown("Jump") && wallJumpingCounter > 0f)
        {
            isWallJumping = true;
            rb.velocity = new Vector2(wallJumpingDirection * wallJumpingPower.x, wallJumpingPower.y);
            wallJumpingCounter = 0f;

            if (transform.localScale.x != wallJumpingDirection)
            {
                rtoate = !rtoate;
                Vector3 localScale = transform.localScale;
                localScale.x *= -1f;
                transform.localScale = localScale;
            }

            Invoke(nameof(StopWallJumping), wallJumpingDuration);
        }
    } 
    private void StopWallJumping()
    {
        isWallJumping = false;
    }

    private bool isWalled()
    {
        return Physics2D.OverlapCircle(wallCheckPoint.position, 0.2f, wallLayer);
    }

    private void WallSlide()
    {
        if (isWalled() && !isGrounded && horizontal == 0f)
        {
            isWallSliding = true;
            rb.velocity = new Vector2(rb.velocity.x, Mathf.Clamp(rb.velocity.y, -wallSlidingSpeed, float.MaxValue));
        }
        else
        {
            isWallSliding = false;
        }
    }

    private void Flip()
    {
        if (!rtoate && horizontal < 0f || rtoate && horizontal > 0f)
        {
            rtoate = !rtoate;
            Vector3 localScale = transform.localScale;
            localScale.x *= -1;
            transform.localScale = localScale;
        }
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.transform.CompareTag("Ground"))
        {

            IsJumping = false;

            isGrounded = true;

        }


    }

    private void OnCollisionExit2D(Collision2D collision)
    {

        if (collision.transform.CompareTag("Ground"))
        {

            StartCoroutine(GroundExit());

            isGrounded = false;

        }


    }

    private IEnumerator GroundExit() {
        yield return new WaitForSeconds(0.1f);
        if (!isGrounded)
           IsJumping = true;

        }


}
