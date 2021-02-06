using System.Collections.Generic;
using UnityEngine;

namespace General
{
    public class ObjectPool : MonoBehaviour
    {
        [SerializeField] private List<GameObject> Pool;
        [SerializeField] private Transform PoolParent;
        [SerializeField] private int ObjectCount;

        private List<GameObject> prefabList;

        public List<GameObject> PrefabList
        {
            get => prefabList;
            set => prefabList = value;
        }

        public void Start()
        {
            ObjectCount = Pool.Count;
            if (PoolParent == null)
            {
                PoolParent = transform;
            }
        }

        public GameObject GetObjectFromPool()
        {
            if (Pool.Count != 0)
            {
                AddNewObjectToPool();
                return GetLastObject();
            }

            if (Pool.Count < ObjectCount / 2)
            {
                AddNewObjectToPool();
                return GetLastObject();
            }

            return InstanceNow();
        }

        private GameObject GetLastObject()
        {
            var lastIndex = Pool.Count - 1;
            var lastObject = Pool[lastIndex];
            lastObject.SetActive(true);
            Pool.RemoveAt(lastIndex);
            return lastObject;
        }
        

        private void AddNewObjectToPool()
        {
            var newObject = InstanceNow();

            newObject.SetActive(false);
            newObject.transform.SetParent(gameObject.transform, true);

            Pool.Add(newObject);
        }

        private GameObject InstanceNow()
        {
            var randomPrefab = PrefabList[Random.Range(0, PrefabList.Count - 1)];
            var newObject = Instantiate(randomPrefab, Vector3.zero, Quaternion.identity);
            newObject.transform.SetParent(gameObject.transform, true);

            return newObject;
        }
    }
}