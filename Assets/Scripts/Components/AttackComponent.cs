using UnityEngine;

namespace Components
{
    public class AttackComponent : MonoBehaviour
    {
        [SerializeField] private float damage;
        public float Damage
        {
            get => damage;
            set => damage = value;
        }
    }
}