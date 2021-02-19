using General;
using UnityEngine;

namespace Tank
{
    public class MovementController : MonoBehaviour
    {
        private DataComponent DataComponent;
        private float Speed = 10;

        [Tooltip("Additive parameter")] public float rotationSpeed = 100f;

        void Start()
        {
            DataComponent = gameObject.GetComponent<DataComponent>();

            if (DataComponent != null)
            {
                Speed = DataComponent.Speed;
            }
        }

        void Update()
        {
            if (Input.GetButton("Vertical"))
            {
                var verticalValue = Input.GetAxis("Vertical") > 0 ? 1 : -1;

                var objectTransform = transform;
                objectTransform.position += objectTransform.forward * (verticalValue * (Speed * Time.deltaTime));
            }

            if (Input.GetButton("Horizontal"))
            {
                var rotationValue = Input.GetAxis("Horizontal");

                transform.Rotate(Vector3.up * (rotationSpeed * rotationValue * Time.deltaTime));
            }
        }
    }
}