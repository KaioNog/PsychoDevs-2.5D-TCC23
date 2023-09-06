using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileSpawn : MonoBehaviour
{
    public GameObject firePoint;
    public List<GameObject> vfx = new List<GameObject>();

    private GameObject effectToSpawn;
    private float timeToFire = 0;

    public bool canShoot;
    public playerData playerDataInstance;
    public ChangeHairColor hairColorChanger;
    private float durationShoot = 1f;

    private void Start()
    {
        //hairColorChanger = GetComponent<ChangeHairColor>();
        effectToSpawn = vfx [0];
        canShoot = false;
    }

    public void Update()
    {
        if(Input.GetKey(KeyCode.J) && Time.time >= timeToFire && !canShoot) 
        {
            Debug.Log("Shoot inativo");
        }

        if(Input.GetKey(KeyCode.J) && Time.time >= timeToFire && canShoot) 
        {
            Debug.Log("Mana insuficiente");
        }

        if(Input.GetKey(KeyCode.J) && Time.time >= timeToFire && canShoot && playerData.playerDataInstance.numberScoreMana >= 10) 
        {
            timeToFire = Time.time + 1 / effectToSpawn.GetComponent<ProjectileMove>().fireRate;
            StartCoroutine(SpawnVFX());

            Debug.Log("Shoot efetuado");
            playerData.playerDataInstance.subtractScore(m:10);
        }    
    }

    IEnumerator SpawnVFX()
    {
        float initialTime = Time.time;
        GameObject vfx;
        if(firePoint != null)
        {
            vfx = Instantiate (effectToSpawn, firePoint.transform.position, Quaternion.identity);
            Debug.Log("Atirou");
            hairColorChanger.ChangeHairToPink();
            Debug.Log("cabelo rosa");

            while (Time.time < initialTime + durationShoot)
            {
                yield return null;
            }

            hairColorChanger.ResetHairColor();
        }
        else
        {
            Debug.Log("No Fire Point");
        }
        
    }
}
