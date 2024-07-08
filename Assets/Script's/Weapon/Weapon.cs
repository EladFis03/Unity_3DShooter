using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Weapon : MonoBehaviour
{
    [SerializeField] Camera FPCamera;
    [SerializeField] float range = 100f;
    [SerializeField] float damage = 30f;
    [SerializeField] ParticleSystem muzzleFlash;
    [SerializeField] GameObject ImpactEffect;
    [SerializeField] Ammo ammoSlot;
    [SerializeField] AmmoType ammoType;
    [SerializeField] float timeBetweenShots = 0.5f;
    [SerializeField] TextMeshProUGUI ammoText;
    [Tooltip("FX prefab for every shoot")] [SerializeField] GameObject shootSfx;
    [Tooltip("where to send the used SFX after that shoot")] [SerializeField] Transform parent;

    bool canShoot = true;


    private void OnEnable()
    {
        canShoot = true;
    }

    //Update is called once per frame
    void Update()
    {
        // new method to show the player the ammo amount of each weapon
        DisplayAmmo();
        // if the user his hiting the fire button
        if (Input.GetMouseButtonDown(0) && canShoot == true)
        {
            StartCoroutine(Shoot());
        }
    }

    private void MusicFire()
    {
        GameObject SFX = Instantiate(shootSfx, transform.position, Quaternion.identity);
        SFX.transform.parent = parent;
    }

    private void DisplayAmmo()
    {
        int currentAmmo = ammoSlot.GetCurrentAmmo(ammoType);
        // converting the integer into a string
        ammoText.text = currentAmmo.ToString();
    }

    IEnumerator Shoot()
    {
        canShoot = false;
        if (ammoSlot.GetCurrentAmmo(ammoType) > 0)
        {
            PlayMuzzleFlash();
            ProcessRaycast();
            MusicFire();
            ammoSlot.ReduceCurrentAmmo(ammoType);
        }
        yield return new WaitForSeconds(timeBetweenShots);
        canShoot = true;
    }

    private void PlayMuzzleFlash()
    {
        muzzleFlash.Play();
    }

    private void ProcessRaycast()
    {
        RaycastHit hit;
        // does the raycast has hit somthing along the path?
        // where did we shoot from and whats the direction of the shoot?
        if (Physics.Raycast(FPCamera.transform.position, FPCamera.transform.forward, out hit, range))
        {
            CreateHitImpact(hit);
            // use code EnemyHealth to decrese his health
            EnemyHealth target = hit.transform.GetComponent<EnemyHealth>();
            if (target == null) return;
            // call a method on EnemyHealth that decreases the enemys health
            target.TakeDamage(damage);
        }
        else
        {
            return;
        }
    }


    private void CreateHitImpact(RaycastHit hit)
    {
        GameObject impact = Instantiate(ImpactEffect, hit.point, Quaternion.LookRotation(hit.normal));
        Destroy(impact, 0.1f);
    }
}
