using System;
using System.Collections.Generic;
using General;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Monster
{
    public class MonsterCreator : MonoBehaviour
    {
        public int MonsterAmount = 10;
        public float XOffset;
        public float ZOffset;

        [SerializeField] private List<GameObject> MonsterPrefabs;
        [SerializeField] private GameObject ChaseTarget;
        [SerializeField] private ObjectPool ObjectPool;

        void Start()
        {
            ObjectPool.PrefabList = MonsterPrefabs;
            CreateMonsters(MonsterAmount);
        }

        void CreateMonster(Vector3 spawnPosition)
        {
            var monsterObject = ObjectPool.GetObjectFromPool();
            monsterObject.transform.position = spawnPosition;
            monsterObject.SetActive(true);

            var monsterComponentHolder = monsterObject.GetComponent<MonsterComponentHolder>();

            var healthController = monsterComponentHolder.HealthController;
            healthController.OnDeath += () => OnMonsterDestroy(healthController);

            var moveToTarget = monsterComponentHolder.MoveToTarget;
            moveToTarget.Target = ChaseTarget;
        }

        private void CreateMonsters(int amount = 1)
        {
            for (int i = 0; i < amount; i++)
            {
                var monsterPosition = GetPositionOutsideCameraView();

                CreateMonster(monsterPosition);
            }
        }

        private void OnMonsterDestroy(HealthController healthController)
        {
            CreateMonsters();
            healthController.OnDeath -= () => OnMonsterDestroy(healthController);
        }

        private Vector3 GetPositionOutsideCameraView()
        {
            var position = Vector3.one;
            position.x = (float) (Math.Pow(-1, Random.Range(1, 3)) * XOffset) + Random.Range(1, 4);
            position.z = (float) (Math.Pow(-1, Random.Range(1, 3)) * ZOffset) + Random.Range(1, 4);
            return position;
        }
    }
}