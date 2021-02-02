using UnityEngine;

namespace Tank
{
    public class ShootController : MonoBehaviour
    {
        public GameObject Bullet;
        public Transform LaunchPosition;

        public float BulletSpeed;

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
            var bulletRigidbody = bullet.GetComponent<Rigidbody>();
            bulletRigidbody.AddForce(LaunchPosition.forward * BulletSpeed, ForceMode.Force);
        }
    }
}