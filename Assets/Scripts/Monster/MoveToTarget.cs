using General;
using UnityEngine;

namespace Monster
{
    public class MoveToTarget : MonoBehaviour
    {
        public GameObject Target;

        private DataComponent DataComponent;

        void Start()
        {
            DataComponent = gameObject.GetComponent<DataComponent>();
        }

        void Update()
        {
            if (Target != null)
            {
                var targetPosition = Target.transform.position;
                transform.position = Vector3.MoveTowards(transform.position, targetPosition,
                    DataComponent.Speed * Time.deltaTime);
                
                transform.LookAt(targetPosition);
            }
        }
    }
}