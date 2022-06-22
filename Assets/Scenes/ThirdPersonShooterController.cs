using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Cinemachine;
using StarterAssets;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class ThirdPersonShooterController : MonoBehaviour
{
    [SerializeField] private CinemachineVirtualCamera aimVirtualCamera;
    [SerializeField] private LayerMask aimColliderLayerMask = new LayerMask();
    [SerializeField] private Transform debugTransform;
    [SerializeField] private Transform pfBulletProjectile;
    [SerializeField] private Transform spawnBulletPosition;
    private ThirdPersonController thirdPersonController;
   
    private StarterAssetsInputs starterAssetsInputs;
    private Animator animator;
    


    public Slider healthbar;
    private int HP = 100;
    public float shootingTime;
    private float timeSinceStartTime;
    private float startTime;
    private void Awake()
    {
        starterAssetsInputs = GetComponent<StarterAssetsInputs>();
         thirdPersonController  = GetComponent<ThirdPersonController>();
        animator = GetComponent<Animator>();

    }

    private void Update()
    {

        healthbar.value = HP;
        Vector3 mouseWorldPosition = Vector3.zero;
        Vector2 screenCenterPoint = new Vector2(Screen.width / 2f, Screen.height / 2f);
        Ray ray = Camera.main.ScreenPointToRay(screenCenterPoint);
        if (Physics.Raycast(ray, out RaycastHit raycastHit, 999f, aimColliderLayerMask))
        {
            debugTransform.position = raycastHit.point;
            mouseWorldPosition = raycastHit.point;
        }

        if (starterAssetsInputs.aim)
        {
            print("aiming");
            aimVirtualCamera.gameObject.SetActive(true);
            thirdPersonController.SetRotateOnMove(false);
            animator.SetLayerWeight(1, Mathf.Lerp(animator.GetLayerWeight(1),1f,Time.deltaTime * 10f));
            Vector3 worldAimTarget = mouseWorldPosition;
            worldAimTarget.y = transform.position.y;
            Vector3 aimDirection = (worldAimTarget - transform.position).normalized;

            transform.forward = Vector3.Lerp(transform.forward, aimDirection, Time.deltaTime * 20f);

        }
        else
        {
            aimVirtualCamera.gameObject.SetActive(false);
            thirdPersonController.SetRotateOnMove(true);
            animator.SetLayerWeight(1, Mathf.Lerp(animator.GetLayerWeight(1), 0f, Time.deltaTime * 10f));
        }
        timeSinceStartTime = Time.time - startTime;

        if (starterAssetsInputs.shoot && timeSinceStartTime >= shootingTime)
        {
           
            startTime = Time.time;
            print("Funfou");
            Vector3 aimDir = (mouseWorldPosition - spawnBulletPosition.position).normalized;
            Instantiate(pfBulletProjectile, spawnBulletPosition.position, Quaternion.LookRotation(aimDir, Vector3.up));
            starterAssetsInputs.shoot = false;
            AudioManager.instance.Play("shoot");


            Cursor.lockState = CursorLockMode.Locked;

            Cursor.visible = false;
            
            
        }

       


    


    }

    

    public void TakeDamage(int damageAmount)
    {
       
        HP -= damageAmount;
        if (HP <= 0)
        {

            
                SceneManager.LoadScene(3);
            

           
            


        }
       
    }
}



   
   

    
