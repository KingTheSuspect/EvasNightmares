using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Movement : MonoBehaviour
{

    private Rigidbody2D rb;
    float horizontal;
    public float speed;
    public float standardSpeed;
    public float jumpForce;
    public float wallJumpForce;
    public bool IsJumping;
    bool rtoate;
    Vector3 scale;
    public bool isGrounded = true;
    public Animator anim;
    public bool isdead;
    public Vector2 checkPoint;
    //Transform whimsyPoint ,whimsy;
    public static bool hatModeForAnim;
    public ParticleSystem particleSystemm;


    public Transform wall;

    public bool left = true;
    public bool wallJumping = false;

    public float jumpingTimer = 0;
    public float jumpTime = 1;
    public bool cantMove = false;
    public bool cantJump = false;

    public bool invicible = false;



    void Start()
    {
        particleSystemm = GameObject.Find("dust").GetComponent<ParticleSystem>();
        rb = GetComponent<Rigidbody2D>();
        //whimsyPoint = GameObject.Find("hatposition").transform;
        //whimsy = GameObject.Find("whimsy").transform;

        standardSpeed = speed;

    }

    void Update()
    {

        if (GameObject.Find("whimsy").GetComponent<whimsyfallow>().hat)
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

        if (GameObject.Find("whimsy").GetComponent<whimsyfallow>().hatmode && !isdead)
        {
            jumpForce = 300;
            speed = 330;
            if (!GameObject.Find("whimsy").GetComponent<whimsyfallow>().hat)
            {
                GameObject.Find("whimsy").transform.localScale = new Vector2(this.transform.localScale.x, this.transform.localScale.y);

            }



        }

        else if (!isdead)
        {
            jumpForce = 250;
            speed = 250;
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
