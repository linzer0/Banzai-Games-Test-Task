﻿using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

namespace Tank
{
    public class WeaponChanger : MonoBehaviour
    {
        [SerializeField] private List<GameObject> WeaponList;
        [SerializeField] private Transform GunPosition;
        
        private int CurrentWeaponIndex;
        private GameObject CurrentWeaponObject;

        void Start()
        {
            SetWeapon(0);
        }

        void Update()
        {

            if (Input.GetKeyDown(KeyCode.Q))
            {
                SetPreviousWeapon();
            }

            if (Input.GetKeyDown(KeyCode.E))
            {
                SetNextWeapon();
            }
        }

        void SetPreviousWeapon()
        {
            if (CurrentWeaponIndex - 1 >= 0)
            {
                CurrentWeaponIndex--;
                SetWeapon(WeaponList[CurrentWeaponIndex]);
            }
        }

        void SetNextWeapon()
        {
            if (CurrentWeaponIndex + 1 < WeaponList.Count)
            {
                CurrentWeaponIndex++;
                SetWeapon(WeaponList[CurrentWeaponIndex]);
            }
        }

        void SetWeapon(int index)
        {
            if (index >= 0 && index < WeaponList.Count)
            {
                CurrentWeaponIndex = index;
                SetWeapon(WeaponList[CurrentWeaponIndex]);
            }
        }

        void SetWeapon(GameObject prefab)
        {
            if (CurrentWeaponObject != null)
            {
                Destroy(CurrentWeaponObject);
            }
            
            CurrentWeaponObject = Instantiate(prefab, Vector3.zero, prefab.transform.rotation);
            CurrentWeaponObject.transform.SetParent(GunPosition, false);
        }
        
    }
}