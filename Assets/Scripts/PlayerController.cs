using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class PlayerController : MonoBehaviour
{

    private Rigidbody2D rb;
    private float horizontal;
    public float speed = 200;
    public float jumpForce = 200;
    private float firstspeed, firstjump;
    [SerializeField] private float wevaspeed = 250, wevajumpForce = 250;
    [SerializeField] private float wallJumpForce;
    [SerializeField] private bool IsJumping;
    private bool rtoate;
    private Vector3 scale;
    private bool isGrounded = true;
    private Animator anim;
    public bool isdead;
    [HideInInspector]public Vector2 checkPoint;
    public static bool hatModeForAnim;
    private ParticleSystem particleSystemm;
    private Transform wall;
    private bool left = true;
    private bool wallJumping = false;
    private float jumpingTimer = 0;
    private float jumpTime = 1;
    private bool cantMove = false;
    private bool cantJump = false;
    [HideInInspector]public bool invicible = false;



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
        

        if ((Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow)) && (!IsJumping || wallJumping) && !cantJump)
        {

            if (wallJumping)
            {

                var walls = GameObject.FindGameObjectsWithTag("wall");

                if (walls.Length > 0 && IsJumping)
                {
                    var closestWall = walls.OrderBy(wall => Vector3.Distance(this.transform.position, wall.transform.position)).ToList()[0];

                    wall = closestWall.transform;

                    if (this.transform.position.x < closestWall.transform.position.x)
                    {

                        left = true;

                    }

                    else if (this.transform.position.x > closestWall.transform.position.x)
                    {

                        left = false;

                    }

                }

                if (left)
                {

                    rb.velocity = new Vector2(-wallJumpForce, wallJumpForce);

                    jumpingTimer = 0;

                    cantMove = true;

                    wallJumping = false;

                    IsJumping = true;

                    cantJump = true;

                }

                else if (!left)
                {

                    rb.velocity = new Vector2(wallJumpForce, wallJumpForce);

                    jumpingTimer = 0;

                    cantMove = true;

                    wallJumping = false;

                    IsJumping = true;

                    cantJump = true;

                }

            }

            else if (!IsJumping)
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

        if (jumpingTimer >= jumpTime)
        {

            cantMove = false;

            cantJump = false;

        }
            

        jumpingTimer += Time.deltaTime;

    }

    private void FixedUpdate()
    {

        anim.SetFloat("speed", Mathf.Abs(horizontal));

        horizontal = Input.GetAxisRaw("Horizontal");

        if (!cantMove)
        {

            rb.velocity = new Vector2(horizontal * Time.deltaTime * speed, rb.velocity.y);

        }

        if (horizontal < 0 && rtoate == false)
        {

            if (GameObject.Find("Camera").GetComponent<CameraFollow>().isFollowingCharachter)
                GameObject.Find("Camera").GetComponent<CameraFollow>().isFollowingOffset.x = -1;

            rotate();

        }

        else if (horizontal > 0 && rtoate == true)
        {

            rotate();

            if (GameObject.Find("Camera").GetComponent<CameraFollow>().isFollowingCharachter)
                GameObject.Find("Camera").GetComponent<CameraFollow>().isFollowingOffset.x = 1;

        }

    }

    void rotate()
    {
        rtoate = !rtoate;
        scale = gameObject.transform.localScale;
        scale.x = scale.x * -1;
        gameObject.transform.localScale = scale;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.transform.CompareTag("Ground"))
        {

            IsJumping = false;

            isGrounded = true;

            cantMove = false;

            wallJumping = false;

            cantJump = false;

        }

        if (collision.transform.CompareTag("wall") && !isGrounded)
        {

            wallJumping = true;

            cantMove = false;

            cantJump = false;

        }

    }

    private void OnCollisionExit2D(Collision2D collision)
    {

        if (collision.transform.CompareTag("Ground"))
        {

            StartCoroutine(GroundExit());

            isGrounded = false;

        }

        if (collision.transform.CompareTag("wall"))
        {

            StartCoroutine(WallExit());

            isGrounded = false;

        }

    }

    private IEnumerator GroundExit() {

            yield return new WaitForSeconds(0.1f);

            if (!isGrounded)
                IsJumping = true;

        }

    private IEnumerator WallExit()
    {

        yield return new WaitForSeconds(0.1f);

        if (!wallJumping)
            cantJump = true;

    }

}
