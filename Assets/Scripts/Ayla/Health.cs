using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private float startingHealth; //5
    public float currentHealth { get; private set; }
    private Animator anim;
    private bool dead;
    public GameObject HurtEffect;

    // Propriedade pública para acessar e modificar canDamage
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
            Debug.Log("Game over");
            dead = true;
            anim.SetTrigger("die");
            GetComponent<zKaiController>().enabled = false;
            GameManager.instance.ShowGameOver();
            }
        }
    }

    public void AddHealth(float _value)
    {
        currentHealth = Mathf.Clamp(currentHealth + _value, 0, startingHealth);
    }

    public void HurtEffectAyla()
    {
    Vector3 offset = new Vector3(0f, 0.7f, 0f); // Ajuste vertical desejado
    Vector3 particlePosition = transform.position + offset;
    Instantiate(HurtEffect, particlePosition, transform.rotation);        
    //Destroy(HurtEffect,0.3f);
    }
}
