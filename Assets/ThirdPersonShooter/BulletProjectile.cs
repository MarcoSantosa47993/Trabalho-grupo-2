using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletProjectile : MonoBehaviour
{
    private Rigidbody bulletRigidbody;
    [SerializeField] private Transform vfxHitGreen;
    [SerializeField] private Transform vfxHitRed;


    private void Awake()
    {
        bulletRigidbody = GetComponent<Rigidbody>();
    }

    private void Start()
    {
      
        float speed = 40f;
        bulletRigidbody.velocity = transform.forward * speed;
    }

    private void OnTriggerEnter(Collider other)
    {
        /*if(other.GetComponent<BulletTarget>() != null)
        {
            print("olá");
            Instantiate(vfxHitGreen, transform.position, Quaternion.identity);
        }
        else 
        {
            
           
        }*/

        
        if(other.tag == "Enemy")
        {
            
            print("Inimigo");
            other.GetComponent<EnemyController>().TakeDamage(20);
            Instantiate(vfxHitGreen, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
        else
        {
              Instantiate(vfxHitGreen, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
            
    }
}
