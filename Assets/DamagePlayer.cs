using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamagePlayer : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
       


        if (other.tag == "Player")
        {

            print("Player");
            other.GetComponent<ThirdPersonShooterController>().TakeDamage(50);
           
        }
       

    }
}
