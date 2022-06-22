using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyController : MonoBehaviour
{
    private int HP = 100;
    public Slider healthbar;
    public Animator animator;
    private float timeSinceStartTime;
    private float startTime;


    private void Update()
    {
        healthbar.value = HP;
    }

    public void TakeDamage(int damageAmount)
    {
        HP -= damageAmount;
        if(HP <= 0 )
        {
            
            animator.SetTrigger("Death");
            GetComponent<Collider>().enabled = false;
            
        }
        else
        {
            animator.SetTrigger("GetHit");
        }
    }
}
