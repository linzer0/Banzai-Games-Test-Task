using UnityEngine;

namespace General
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