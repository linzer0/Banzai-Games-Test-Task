using System.Collections.Generic;
using General;
using UnityEngine;

namespace Tank
{
    public class WeaponChanger : MonoBehaviour
    {
        [SerializeField] private List<GameObject> WeaponList;
        [SerializeField] private Transform GunPosition;

        [SerializeField] private ObjectPool BulletPool;

        private int CurrentWeaponIndex;
        private GameObject CurrentWeaponObject;
        private GunController currentGunController;

        private List<GameObject> ActiveGuns = new List<GameObject>();

        private void Start()
        {
            CreateAllGuns();
            SetWeapon(0);
        }

        private void CreateAllGuns()
        {
            foreach (var gunPrefab in WeaponList)
            {
                var newGun = Instantiate(gunPrefab, Vector3.zero, gunPrefab.transform.rotation);
                newGun.transform.SetParent(GunPosition, false);

                var gunController = newGun.GetComponent<GunController>();
                gunController.ObjectPool = BulletPool;

                newGun.SetActive(false);

                ActiveGuns.Add(newGun);
            }
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Q))
            {
                CurrentWeaponIndex--;
                SetPreviousWeapon();
            }

            if (Input.GetKeyDown(KeyCode.E))
            {
                SetNextWeapon();
            }
        }

        private void SetPreviousWeapon()
        {
            if (CurrentWeaponIndex - 1 >= 0)
            {
                UnSetWeapon(CurrentWeaponIndex);
                CurrentWeaponIndex--;
                SetWeapon(CurrentWeaponIndex);
            }
        }

        private void SetNextWeapon()
        {
            if (CurrentWeaponIndex + 1 < WeaponList.Count)
            {
                UnSetWeapon(CurrentWeaponIndex);
                CurrentWeaponIndex++;
                SetWeapon(CurrentWeaponIndex);
            }
        }

        private void UnSetWeapon(int index)
        {
            if (index >= 0 && index < ActiveGuns.Count - 1)
            {
                ActiveGuns[index].SetActive(false);
            }
        }

        private void SetWeapon(int index)
        {
            if (index >= 0 && index < ActiveGuns.Count)
            {
                ActiveGuns[index].SetActive(true);
            }
        }
    }
}