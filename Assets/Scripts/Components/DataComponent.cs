using UnityEngine;

namespace Components
{
    public class DataComponent : MonoBehaviour
    {
        [SerializeField] private float health;
        [SerializeField] private float armor;
        [SerializeField] private float speed;

        public float Health => health;
        public float Armor => armor;
        public float Speed => speed;
    }
}