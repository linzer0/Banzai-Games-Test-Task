using Components;
using UnityEngine;

namespace Monster
{
    public class MonsterController : MonoBehaviour
    {
        [HideInInspector] public GameObject Target;

        private DataComponent DataComponent;

        void Start()
        {
            DataComponent = gameObject.GetComponent<DataComponent>();
        }

        void Update()
        {
            if (Target != null)
            {
                transform.position = Vector3.MoveTowards(transform.position, Target.transform.position,
                    DataComponent.Speed * Time.deltaTime);
                transform.LookAt(Target.transform.position);
            }
        }
    }
}