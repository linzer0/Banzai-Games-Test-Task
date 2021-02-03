using System;
using System.Collections.Generic;
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

        void Start()
        {
            CreateMonsters(MonsterAmount);
        }

        void CreateMonster(GameObject prefab, Vector3 spawnPosition)
        {
            var monsterObject = Instantiate(prefab, spawnPosition, Quaternion.identity);

            var healthController = monsterObject.GetComponent<HealthController>();
            healthController.OnDeath += OnMonsterDestroy;
            healthController.OnDeath += () => { healthController.OnDeath -= OnMonsterDestroy; };

            var monsterController = monsterObject.GetComponent<MoveToTarget>();
            monsterController.Target = ChaseTarget;
        }

        private void CreateMonsters(int amount = 1)
        {
            for (int i = 0; i < amount; i++)
            {
                var monsterPosition = GetPositionOutsideCameraView();
                var monsterPrefab = MonsterPrefabs[Random.Range(0, MonsterPrefabs.Count)];

                CreateMonster(monsterPrefab, monsterPosition);
            }
        }

        private void OnMonsterDestroy()
        {
            CreateMonsters();
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