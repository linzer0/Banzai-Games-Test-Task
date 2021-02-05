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