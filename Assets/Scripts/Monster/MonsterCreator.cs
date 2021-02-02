using System.Collections.Generic;
using UnityEngine;

namespace Monster
{
    public class MonsterCreator : MonoBehaviour
    {
        public int MonsterAmount = 10;
        
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
            
            var monsterController = monsterObject.GetComponent<MonsterController>();
            monsterController.Target = ChaseTarget;
        }

        private void CreateMonsters(int amount = 1)
        {
            for (int i = 0; i < amount; i++)
            {
                var monsterPosition = GetSpawnPosition();
                var monsterPrefab = MonsterPrefabs[Random.Range(0, MonsterPrefabs.Count)];
                
                CreateMonster(monsterPrefab, monsterPosition);
            }
        }

        private void OnMonsterDestroy()
        {
           CreateMonsters(); 
        }

        private Vector3 GetSpawnPosition()
        {
            var position = Vector3.one;
            position.x += Random.Range(0, 20);
            position.y += Random.Range(0, 20);
            position.z += Random.Range(0, 20);
            return position;
        }
    }
}