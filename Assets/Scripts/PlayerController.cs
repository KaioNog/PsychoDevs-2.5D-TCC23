using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public float runSpeed;
    public float walkSpeed;
    bool facingRight;

    Rigidbody myRb;
    Animator myAnim;

    bool grounded = false;
    Collider[] groundCollisions;
    float groundCheckRadius = 0.2f;
    public LayerMask groundLayer;
    public Transform groundCheck;
    public float jumpHeight;

    //for wallJump
    public float gravity = 25;
    private float verticalVelocity;
    private CharacterController controller;


    void Start()
    {
        myRb = GetComponent<Rigidbody>();
        myAnim = GetComponent<Animator>();
        controller = GetComponent<CharacterController>();
        facingRight = true;
    }

    void Update()
    {}

    void FixedUpdate()
    {
        groundCollisions = Physics.OverlapSphere(groundCheck.position, groundCheckRadius, groundLayer);
        if(groundCollisions.Length>0) 
            grounded = true;
        else grounded = false;
        myAnim.SetBool("grounded", grounded);

        if(grounded && Input.GetAxis("Jump") > 0)
        {
            grounded = false;
            myAnim.SetBool("grounded", grounded);
            myRb.AddForce(new Vector3(0, jumpHeight, 0));
        }

        float move = Input.GetAxis("Horizontal");
            myAnim.SetFloat("speed",Mathf.Abs (move));
            myRb.velocity = new Vector3(move * runSpeed, myRb.velocity.y, 0);

        //walk
        float sneaking = Input.GetAxisRaw("Fire3");
        myAnim.SetFloat("sneaking",sneaking);

        float firing = Input.GetAxis("Fire1");
        myAnim.SetFloat("shooting", firing);

        if((sneaking > 0 || firing > 0) && grounded)
        {
            myRb.velocity = new Vector3 (move * walkSpeed, myRb.velocity.y, 0);
        }
        else
        {
            myRb.velocity = new Vector3 (move * runSpeed, myRb.velocity.y, 0);
        }

        if(move > 0 && !facingRight) 
            Flip();
            else if(move < 0 && facingRight) 
                Flip(); 
    }

    void Flip()
    {
        //transforma a escala z - -1 = rotacionar em 180 graus
        facingRight = !facingRight;
        Vector3 theScale = transform.localScale;
        theScale.z *= -1;
        transform.localScale = theScale;
    }

    public float GetFacing()
    {
        if(facingRight) return 1;
        else return -1;
    }
}