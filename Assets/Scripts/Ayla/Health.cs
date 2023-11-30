using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private float startingHealth; //5
    public float currentHealth { get; private set; }
    private Animator anim;
    private bool dead;
    public GameObject HurtEffect;
    public GameObject dieEffect;

    public bool CanDamage;

    private void Awake()
    {
        anim = GetComponent<Animator>();
        currentHealth = startingHealth;
        CanDamage = true;
    }

    public void TakeDamage(float _damage)
    {
        if(CanDamage)
        {
            {
            currentHealth = Mathf.Clamp(currentHealth - _damage, 0, startingHealth);

            CameraFollow cameraShake = Camera.main.GetComponent<CameraFollow>();
            if (cameraShake != null)
            {
                cameraShake.TriggerShake();
            }

            }
        }

        if(currentHealth > 0)
        {
            anim.SetTrigger("hurt");
            HurtEffectAyla();
            //iframes
        }
        else
        {
            if(!dead)
            {
            anim.SetTrigger("die");
            dead = true;
            Instantiate(dieEffect, transform.position, transform.rotation);
            GetComponent<zKaiController>().enabled = false;
            GameManager.instance.ShowGameOver();

            // Para a música da fase
            FindObjectOfType<AudioManager>().Stop("TrilhaSonora");
            // Inicia a música de Game Over
            FindObjectOfType<AudioManager>().Play("GameOver");  
            }
        }
    }

    public void AddHealth(float _value)
    {
        currentHealth = Mathf.Clamp(currentHealth + _value, 0, startingHealth);
    }

    public void HurtEffectAyla()
    {
    FindObjectOfType<AudioManager>().Play("Dano"); 
    Vector3 offset = new Vector3(0f, 0.7f, 0f); // Ajuste vertical desejado
    Vector3 particlePosition = transform.position + offset;
    Instantiate(HurtEffect, particlePosition, transform.rotation);        
    //Destroy(HurtEffect,0.3f);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "ToxicWater")
        {
            TakeDamage(20);
        }
    }
}
