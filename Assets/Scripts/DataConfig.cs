using UnityEngine;

[CreateAssetMenu(fileName = "DataConfig", menuName = "Game/DataConfig", order = 0)]
public class DataConfig : ScriptableObject
{
    [SerializeField] private float health;
    [SerializeField] private float armor;
    [SerializeField] private float speed;
    [SerializeField] private float damage;

    public float Health => health;
    public float Armor => armor;
    public float Speed => speed;
    public float Damage => damage;
}