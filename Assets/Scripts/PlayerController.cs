using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public float runSpeed;

    Rigidbody myRb;
    Animator myAnim;

    bool facingRight;

    void Start()
    {
        myRb = GetComponent<Rigidbody>();
        myAnim = GetComponent<Animator>();
        facingRight = true;
    }

    void Update()
    {
        
    }

    void FixedUpdate()
    {
        float move = Input.GetAxis("Horizontal");
        myAnim.SetFloat("speed",Mathf.Abs (move));

        myRb.velocity = new Vector3(move * runSpeed, myRb.velocity.y, 0);

        if(move > 0 && !facingRight) 
            Flip();
            else if(move < 0 && facingRight) 
                Flip(); 
    }

    void Flip()
    {
        facingRight = !facingRight;
        Vector3 theScale = transform.localScale;
        theScale.z *= -1;
        transform.localScale = theScale;
    }
}
