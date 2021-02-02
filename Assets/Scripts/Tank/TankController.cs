using Components;
using UnityEngine;

public class TankController : MonoBehaviour
{
    private DataComponent DataComponent;

    //Additive parameter
    private float rotationSpeed = 100f;

    void Start()
    {
        DataComponent = gameObject.GetComponent<DataComponent>();
    }

    void Update()
    {
        if (Input.GetButton("Vertical"))
        {
            var verticalValue = Input.GetAxis("Vertical") > 0 ? 1 : -1;

            if (DataComponent != null)
            {
                transform.position += (verticalValue * transform.forward) * (DataComponent.Speed * Time.deltaTime);
            }
        }

        if (Input.GetButton("Horizontal"))
        {
            var rotationValue = Input.GetAxis("Horizontal");

            transform.Rotate(rotationSpeed * rotationValue * Vector3.up * Time.deltaTime);
        }
    }
}