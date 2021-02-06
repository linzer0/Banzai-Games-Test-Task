using System.Collections.Generic;
using Components;
using General;
using UnityEngine;

namespace Tank
{
    public class GunController : MonoBehaviour
    {
        [Header("Bullet Data")] public GameObject Bullet;
        public float BulletSpeed;
        public float BulletLifeTime = 2.0f;

        [Header("Other")] public Transform LaunchPosition;

        private AttackComponent AttackComponent;
        private ObjectPool objectPool;

        public ObjectPool ObjectPool
        {
            get => objectPool;
            set => objectPool = value;
        }


        void Start()
        {
            AttackComponent = gameObject.GetComponent<AttackComponent>();

            objectPool.PrefabList = new List<GameObject>() {Bullet};
        }

        void Update()
        {
            if (Input.GetKeyDown(KeyCode.X))
            {
                CreateBullet();
            }
        }

        private void CreateBullet()
        {
            var bullet = objectPool.GetObjectFromPool();

            bullet.transform.position = LaunchPosition.position;
            bullet.SetActive(true);

            var bulletComponentHolder = bullet.GetComponent<BulletComponentHolder>();

            AddForceToBullet(bulletComponentHolder.Rigidbody);

            bulletComponentHolder.AttackComponent.Damage = AttackComponent.Damage;

            Destroy(bullet, BulletLifeTime);
        }

        private void AddForceToBullet(Rigidbody rigidbody)
        {
            rigidbody.AddForce(LaunchPosition.forward * BulletSpeed, ForceMode.Force);
        }
    }
}