using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class zKaiController : MonoBehaviour
{
    private Animator Anim;
    private float velocity = 3.5f;
    //private float walkVelocity = 2f;
    private float inputHorizontal;
    private Quaternion playerRotation;
    private Vector3 Moving;
    private CharacterController controller;

    private float gravity = 9.8f;
    private float jumpForce = 5f;
    private float trampolineForce = 9f;
    private bool inAir = false;
    private bool doubleJump = false;
    private float velocityDash = 5f;
    private float durationDash = 0.15f;
    private bool activeDash = false;
    private bool activeCoyote = true;
    private float coyoteTime = 0;
    private float coyoteTimeDuration = 0.015f;
    private float durationBufferLeap = 0.05f;
    private float timeBufferLeap = 0f;

    private bool inWall = false;
    private Vector3 positionRaycast;
    private float centerRaycast = 0.5f;
    public LayerMask wallLayerMask;
    private float SideWallJump = 18f;
    private float wallJumpSeparation = 2.5f;

    private void Start()
    {
        Anim = this.GetComponent<Animator>();
        controller = this.GetComponent<CharacterController>();
        Application.targetFrameRate = 60;
    }

    private void Update()
    {
        Move();
    }

    void Move()
    {
        Anim.SetBool("jump", true); 
        inputHorizontal = Input.GetAxisRaw("Horizontal");

        if(!inWall)
        {
            Moving.z = inputHorizontal * velocity;
        }


        if(controller.isGrounded)
        {
            inAir = false;
            activeDash = false;
            activeCoyote = true;
            Anim.SetBool("jump", false); 
            Anim.SetBool("run", false);
            Anim.SetBool("dash", false);
            Anim.SetBool("wall", false);
            if(timeBufferLeap > 0)
            {
                Leap(jumpForce);
            } 
        }
        else
        {
            inAir = true;
            WallCollision();

            if(activeCoyote)
            {
                activeCoyote = false;
                coyoteTime = Time.time;
                Moving.y = 0;
            }

            if(coyoteTime + coyoteTimeDuration < Time.time)
            {    
            
            if(doubleJump && Input.GetButtonDown("Jump"))
            {
                doubleJump = false;
                Moving.y = jumpForce;
            }

            if(!doubleJump && Input.GetButtonDown("Jump") && inAir)
            {
                timeBufferLeap = durationBufferLeap;
            }
            Anim.SetBool("dash", false);
            timeBufferLeap -= Time.deltaTime;
            Moving.y -= gravity*Time.deltaTime;
            }
        }

        if(inputHorizontal != 0)
        {
            playerRotation = Quaternion.LookRotation(new Vector3(0, 0, inputHorizontal));
            this.transform.rotation = playerRotation;
            Anim.SetBool("run", true);
        }


        if(Input.GetButtonDown("Jump") && !inAir)
        {
            Leap(jumpForce);
            doubleJump = true;
        }

        if(Input.GetButtonDown("Fire2") && !activeDash)
        {
            StartCoroutine(Dash());
        }

        /*if(Input.GetButtonDown("Fire3") && !inAir)
        {
            Moving.z = inputHorizontal * runVelocity;
            Anim.SetBool("run", true);
        }*/

        controller.Move(Moving*Time.deltaTime);
    }

    IEnumerator Dash()
    {
        float initialTime = Time.time;
        activeDash = true;
        while (Time.time < initialTime + durationDash)
        {
            Anim.SetBool("dash", true);
            Moving = this.transform.TransformDirection(Vector3.forward * velocityDash);
            Moving.y = 0;
            controller.Move(Moving * Time.deltaTime);
            yield return null;
        }
    }

    void Leap(float force)
    {
        WallCollision();
        inAir = true;
        doubleJump = true;
        activeCoyote = false;
        if(inWall)
        {
            playerRotation = Quaternion.LookRotation(this.transform.TransformDirection(Vector3.forward * -1));
            this.transform.rotation = playerRotation;
            Moving = this.transform.TransformDirection(Vector3.forward * SideWallJump * velocity);
        }
        inWall = false;
        Anim.SetBool("wall", false);
        coyoteTime -= coyoteTimeDuration;
        Anim.SetBool("jump", true);
        Moving.y = force;
        timeBufferLeap = 0f;
    }

    void OnTriggerStay(Collider other)
    {
        if(other.gameObject.CompareTag("Trampoline"))
        {
            Leap(trampolineForce);
        }
    }

    void WallCollision()
    {
        float lengthRaycast = 0.5f;
        positionRaycast = this.transform.position;
        positionRaycast.y += centerRaycast;

        if(Physics.Raycast(positionRaycast, this.transform.TransformDirection(Vector3.forward), lengthRaycast, wallLayerMask))
        {
            //Debug.DrawRay(positionRaycast, Vector3.forward * lengthRaycast, Color.red);

            if(controller.isGrounded)
            {
                Moving = this.transform.TransformDirection(Vector3.forward) * wallJumpSeparation * velocity * -1;
            }
            else
            {
                Anim.SetBool("jump", false);
                Anim.SetBool("run", false);
                Anim.SetBool("wall", true);
                
                if(!inWall)
                {
                    Moving.y = 0;
                }
                inWall = true;
                inAir = false;
                gravity = 1.8f;
            }
        }
        else
        {
            inWall = false;
            Anim.SetBool("wall", false);
            gravity = 9.8f;
        }
    }

    /*void onCollisionEnter(Collision collision)
    {
        if(collision.gameObject.layer == 7)
        {
            Debug.Log("Tocou");
        }
    }*/
}
