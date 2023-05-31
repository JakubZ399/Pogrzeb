using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class GunShoot : MonoBehaviour
{
    private RaycastHit hit;
    private Ray ray;

    public GameObject impactEffect;

    public int damage = 10;
    public float rateOfFire = 2;
    public float currentFireCooldown;

    public float recoilStrength = 1f;
    
    public Camera _playerCamera;
    public static Camera _playerCameraStatic;

    public GameObject _buzzEffect;

    private void Awake()
    {
        _buzzEffect.SetActive(false);
        _playerCameraStatic = _playerCamera;
    }

    void Update()
    {
       ray = Camera.main.ViewportPointToRay(new Vector3(.5f, .5f, 0));
       if(Input.GetMouseButton(0) && currentFireCooldown == 0)
       {
           _buzzEffect.SetActive(true);
           _playerCamera.DOShakeRotation(0.1f, recoilStrength, 1, 90f);

           if(Physics.Raycast(ray, out hit, Mathf.Infinity))
           {
               currentFireCooldown = rateOfFire;
               GameObject impactEffectGO = Instantiate(impactEffect, hit.point, Quaternion.identity) as GameObject;
               Destroy(impactEffectGO, 5);
               if(hit.collider.gameObject.tag == "Cube")
               {
                   Cube cube = hit.collider.gameObject.GetComponent<Cube>();
                   cube.TakeDamage(damage);
               }
               
           } 
       }
       else if(Input.GetKeyUp(KeyCode.Mouse0))
       {
           _buzzEffect.SetActive(false);
       }
        else
        {
            
            currentFireCooldown -=  Time.deltaTime;
            if(currentFireCooldown <= 0)
            {
                currentFireCooldown = 0;
            }
        }
    }
}
