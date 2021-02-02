using Components;
using UnityEngine;

public class HealthController : MonoBehaviour
{
    private DataComponent DataComponent;
    private float HealthAmount;

    [SerializeField] private string TriggerTag;
    [SerializeField] private bool DestroyTriggerObject;

    void Start()
    {
        DataComponent = gameObject.GetComponent<DataComponent>();
        if (DataComponent != null)
        {
            HealthAmount = DataComponent.Health;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag(TriggerTag))
        {
            MakeAttack(other.gameObject);

            if (DestroyTriggerObject)
            {
                Destroy(other.gameObject);
            }
        }
    }

    private void MakeAttack(GameObject triggeredObject)
    {
        var attackComponent = triggeredObject.GetComponent<AttackComponent>();
        
        if (attackComponent != null)
        {
            HealthAmount -= attackComponent.Damage * DataComponent.Armor;

            if (HealthAmount <= 0)
            {
                Destroy(gameObject);
            }
        }
    }
}