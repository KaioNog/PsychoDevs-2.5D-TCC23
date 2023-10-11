using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class zKaiController : MonoBehaviour
{
    private Animator Anim;
    private float velocity = 3.5f;
    private float inputHorizontal;
    private Quaternion playerRotation;
    private Vector3 Moving;
    private CharacterController controller;

    private float gravity = 9.8f;
    private float jumpForce = 5f;
    private float trampolineForce = 9f;
    private bool inAir = false;
    private bool doubleJump = false;
    private float velocityDash = 6f;
    private float durationDash = 0.20f;
    private bool activeDash = false;
    public bool canDash = false;
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

    public LayerMask movementMask;
    Camera cam;
    public Interactable focus;
    public float interactionRadius = 2f; // Raio de interação com o inimigo

    public bool canShield = false;
    public bool activeShield = false;
    public float durationShield = 3f;
    private Health health;
    public GameObject ShieldEffect;
    public GameObject DashEffect;
    public ChangeHairColor hairColorChanger;

    private Transform barcoTransform; // Referência ao transform do barco
    private Vector3 offset; // Offset entre o jogador e o barco
    private bool isOnBoat; // Flag para verificar se o jogador está no barco

    private void Start()
    {
        Anim = this.GetComponent<Animator>();
        controller = this.GetComponent<CharacterController>();
        Application.targetFrameRate = 60;
        cam = Camera.main;
        hairColorChanger = GetComponent<ChangeHairColor>();
    }

    private void Update()
    {
        Move();

        if(Input.GetKeyDown(KeyCode.K)) 
        {
            Anim.SetBool("atk", true);
        }
        else
        {
            Anim.SetBool("atk", false);
        }


        // Verifica se o jogador está no barco
        if (isOnBoat && Input.GetButtonDown("Jump"))
        {
            // Faz o jogador pular enquanto está no barco
            JumpFromBoat();
        }
        // Verifica se o jogador está no barco
        if (barcoTransform != null)
        {
            // Move o jogador com base no movimento do barco e no offset
            Vector3 newPosition = barcoTransform.position + offset;
            transform.position = newPosition;
        }
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

        //dash
        if(Input.GetButtonDown("Fire1") && !canDash)
        {
            Debug.Log("Dash inativo");
        }
        if(Input.GetButtonDown("Fire1") && canDash)
        {
            Debug.Log("Mana insuficiente");
        }
        if(Input.GetButtonDown("Fire1") && !activeDash && canDash && playerData.playerDataInstance.numberScoreMana >= 10)
        {
            StartCoroutine(Dash());
            Debug.Log("Dash efetuado");

            playerData.playerDataInstance.subtractScore(m:10);
        }

        if(Input.GetButtonDown("Fire2") && !canShield)
        {
            Debug.Log("Escudo inativo");
            return;
        }

        if(Input.GetButtonDown("Fire2") && canShield)
        {
            Debug.Log("Mana insuficiente");
        }

        if(Input.GetButtonDown("Fire2") && !activeShield && canShield && playerData.playerDataInstance.numberScoreMana >= 10)
        {
            Debug.Log("Escudo efetuado");
            StartCoroutine(Shield());
            playerData.playerDataInstance.subtractScore(m:10);
        }

        controller.Move(Moving*Time.deltaTime);
    }

    IEnumerator Dash()
    {
            float initialTime = Time.time;
            activeDash = true;
            DashEffect.SetActive(true);
            hairColorChanger.ChangeHairToYellow(); 

            while (Time.time < initialTime + durationDash)
            {
                Anim.SetBool("dash", true);
                
                Moving = this.transform.TransformDirection(Vector3.forward * velocityDash);
                Moving.y = 0;
                controller.Move(Moving * Time.deltaTime);
                yield return null;
            }
            DashEffect.SetActive(false);
            hairColorChanger.ResetHairColor(); 
    }

        IEnumerator Shield()
        {
            float initialTime = Time.time;
            activeShield = true;

            // Desativar o dano enquanto o escudo está ativo
            Health health = GetComponent<Health>();
            //health.CanDamage = true;
            health.CanDamage = false;
            ShieldEffect.SetActive(true);

            hairColorChanger.ChangeHairToBlue();

            while (Time.time < initialTime + durationShield)
            {
                yield return null;
            }

            // Reativar o dano após o tempo de duração do escudo
            health.CanDamage = true;
            activeShield = false;  
            ShieldEffect.SetActive(false);
            hairColorChanger.ResetHairColor();
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


    // Método chamado quando o jogador entra no trigger do barco
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Boat"))
        {
            barcoTransform = other.transform;
            offset = transform.position - barcoTransform.position;
            isOnBoat = true;
        }
    }

    // Método chamado quando o jogador sai do trigger do barco
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Boat"))
        {
            barcoTransform = null;
            offset = Vector3.zero;
            isOnBoat = false;
        }
    }

    // Método para fazer o jogador pular para fora do barco
    public void JumpFromBoat()
    {
        Debug.Log("Saltou do barco");
        isOnBoat = false;
        barcoTransform = null;
        offset = Vector3.zero;
    }
}
