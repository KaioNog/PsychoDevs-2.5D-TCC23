using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileSpawn : MonoBehaviour
{
    public GameObject firePoint;
    public List<GameObject> vfx = new List<GameObject>();

    private GameObject effectToSpawn;
    private float timeToFire = 0;

    public void Start()
    {
        effectToSpawn = vfx [0];
    }

    // Update is called once per frame
    public void Update()
    {
        if(Input.GetKey(KeyCode.J) && Time.time >= timeToFire) 
        {
            timeToFire = Time.time + 1 / effectToSpawn.GetComponent<ProjectileMove>().fireRate;
            SpawnVFX();
        }
    }

    public void SpawnVFX()
    {
        GameObject vfx;
        if(firePoint != null)
        {
            vfx = Instantiate (effectToSpawn, firePoint.transform.position, Quaternion.identity);
        }
        else
        {
            Debug.Log("No Fire Point");
        }
    }
}
