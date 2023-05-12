using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoots : MonoBehaviour
{
    public Camera cam;
    public float fireRate = 2.0f;
    public int ExDemage = 0;
    public int ExFire = 1;
    public float diagon = 30.0f;
    private float nextFire = 0.0f;



    void Update()
    {
        if (Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            if (ExFire >= 0)
            {
                Fire();
            }
            
        }
    }


    void Fire()
    {
        Collider[] hitColliders = Physics.OverlapSphere(transform.position, diagon);
        float minDistance = Mathf.Infinity;
        GameObject closestEnemy = null;

        foreach (Collider hitCollider in hitColliders)
        {
            if (hitCollider.CompareTag("enemies"))
            {
                float distance = Vector3.Distance(transform.position, hitCollider.transform.position);
                if (distance < minDistance)
                {
                    minDistance = distance;
                    closestEnemy = hitCollider.gameObject;
                }
            }
        }

        if (closestEnemy != null)
        {
            if (closestEnemy.name == "Speed Burrow")
            {
                closestEnemy.GetComponent<Enemy>().Down_health(70 + ExDemage);
                Debug.Log("100 Shoot");
            }else
            {
                closestEnemy.GetComponent<Enemy>().Down_health(50 + ExDemage);
                Debug.Log("50 Shoot");
            }
            
        }
    }   
}
