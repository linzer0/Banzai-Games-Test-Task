using UnityEngine;

public class DataComponent : MonoBehaviour
{
    private float Health;
    private float Armor;
    public float Speed { get; private set; }
    private float Damage;

    public DataConfig DataConfig;

    void Start()
    {
        SetData();
    }

    private void SetData()
    {
        if (DataConfig != null)
        {
            Health = DataConfig.Health;
            Armor = DataConfig.Armor;
            Speed = DataConfig.Speed;
            Damage = DataConfig.Damage;
        }
        else
        {
            Debug.Log("Please, attach Data Config");
        }
    }
}