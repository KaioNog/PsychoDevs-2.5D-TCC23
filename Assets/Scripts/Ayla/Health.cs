using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private float startingHealth; //5
    public float currentHealth { get; private set; }
    private Animator anim;
    private bool dead;

    private void Awake()
    {
        anim = GetComponent<Animator>();
        currentHealth = startingHealth;
    }

    public void TakeDamage(float _damage)
    {
        currentHealth = Mathf.Clamp(currentHealth - _damage, 0, startingHealth);
        
        if(currentHealth > 0)
        {
            anim.SetTrigger("hurt");
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
}
