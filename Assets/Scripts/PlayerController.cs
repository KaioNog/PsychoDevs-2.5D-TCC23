using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public float runSpeed;
    public float walkSpeed;

    Rigidbody myRb;
    Animator myAnim;

    bool facingRight;

    //for jumping
    bool grounded = false;
    Collider[] groundCollisions;
    float groundCheckRadius = 0.2f;
    public LayerMask groundLayer;
    public Transform groundCheck;
    public float jumpHeight;

    void Start()
    {
        myRb = GetComponent<Rigidbody>();
        myAnim = GetComponent<Animator>();
        facingRight = true;
    }

    void Update()
    {
        
    }

    //o Update é chamado a cada frame, o fixed update é chamado toda vez que um mecanismo físico for executado (run) em um tempo fixo e constante (se atualmente está pressionando o botão)
    void FixedUpdate()
    {
        //OverlapSphere desenha uma pequena esfere e retorna a colisão
        groundCollisions = Physics.OverlapSphere(groundCheck.position, groundCheckRadius, groundLayer);
        if(groundCollisions.Length>0) 
            grounded = true;
        else grounded = false;
        myAnim.SetBool("grounded", grounded);

        //jump
        if(grounded && Input.GetAxis("Jump") > 0)
        {
            grounded = false;
            myAnim.SetBool("grounded", grounded);
            //myAnim.SetFloat("verticalSpeed", myRB.velocity.y);
            myRb.AddForce(new Vector3(0, jumpHeight, 0));
        }

        //run and walk
        float move = Input.GetAxis("Horizontal");
        myAnim.SetFloat("speed",Mathf.Abs (move));

        myRb.velocity = new Vector3(move * runSpeed, myRb.velocity.y, 0);

        float sneaking = Input.GetAxisRaw("Fire3");
        myAnim.SetFloat("sneaking",sneaking);

        if(sneaking > 0 && grounded)
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
