using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSwitch : MonoBehaviour
{
    [SerializeField] int CurrentWeapon = 0;



    // Start is called before the first frame update
    void Start()
    {
        SetWeaponActive();
    }

    // Update is called once per frame
    void Update()
    {
        int previousWeapon = CurrentWeapon;

        ProcessKeyInput();
        ProcessScrollWheel();

        if (previousWeapon != CurrentWeapon)
        {
            SetWeaponActive();
        }
    }

    private void ProcessKeyInput()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            CurrentWeapon = 0;
        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            CurrentWeapon = 1;
        }

        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            CurrentWeapon = 2;
        }
    }

    private void ProcessScrollWheel()
    {
        // if we are scrolling in a praticelar diraction (scrolling DOWN)
        if (Input.GetAxis("Mouse ScrollWheel") < 0)
        {
            // if the current weapon is the last in the childs list
            if (CurrentWeapon >= transform.childCount - 1)
            {
                // go back to the first weapon
                CurrentWeapon = 0;
            }
            else
            {
                // if we arent at the last child of the list will go forword one
                CurrentWeapon++;
            }
        }
        // if we are scrolling in a praticelar diraction (scrolling UP)
        if (Input.GetAxis("Mouse ScrollWheel") > 0)
        {
            // if the current weapon is the first in the childs list
            if (CurrentWeapon <= 0)
            {
                // go back to the last weapon
                CurrentWeapon = transform.childCount - 1;
            }
            else
            {
                // if we arent at the first child of the list will go backwords one
                CurrentWeapon--;
            }
        }
    }

    private void SetWeaponActive()
    {
        int weaponIndex = 0;
        foreach (Transform weapon in transform)
        {
            if (weaponIndex == CurrentWeapon)
            {
                weapon.gameObject.SetActive(true);
            }
            else
            {
                weapon.gameObject.SetActive(false);
            }
            weaponIndex++;
        }
    }
}
