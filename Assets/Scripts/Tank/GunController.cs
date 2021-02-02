using Components;
using UnityEngine;

namespace Tank
{
    public class GunController : MonoBehaviour
    {

        [Header("Bullet Data")] 
        public GameObject Bullet;
        public float BulletSpeed;
        public float BulletLifeTime = 2.0f;

        [Header("Other")] 
        public Transform LaunchPosition;

        private AttackComponent AttackComponent;
        void Start()
        {
            AttackComponent = gameObject.GetComponent<AttackComponent>();
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
            var bullet = Instantiate(Bullet, LaunchPosition.position, Quaternion.identity);

            AddForceToBullet(bullet);
            AddAttackComponent(bullet);

            Destroy(bullet, BulletLifeTime);
        }

        private void AddForceToBullet(GameObject bullet)
        {
            var bulletRigidbody = bullet.GetComponent<Rigidbody>();
            bulletRigidbody.AddForce(LaunchPosition.forward * BulletSpeed, ForceMode.Force);
        }

        private void AddAttackComponent(GameObject bullet)
        {
            var attackComponent = bullet.AddComponent<AttackComponent>();
            attackComponent.Damage = AttackComponent.Damage;
        }
    }
}