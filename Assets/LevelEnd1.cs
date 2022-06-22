using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelEnd1 : MonoBehaviour
{
    
    private void OnTriggerEnter(Collider other)
    {
        
        SceneManager.LoadScene(7
            );

     

    }
}
