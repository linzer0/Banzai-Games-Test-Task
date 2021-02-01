using UnityEngine;

public class BaseController : MonoBehaviour
{
    public float movingSpeed;

    [HideInInspector] public float rotationSpeed = 100f;


    void Update()
    {
        if (Input.GetButton("Vertical"))
        {
            var verticalValue = Input.GetAxis("Vertical") > 0 ? 1 : -1;

            transform.position += (verticalValue * transform.forward) * (movingSpeed * Time.deltaTime);
        }

        if (Input.GetButton("Horizontal"))
        {
            var rotationValue = Input.GetAxis("Horizontal");

            transform.Rotate(rotationSpeed * rotationValue * Vector3.up * Time.deltaTime);
        }
    }
}