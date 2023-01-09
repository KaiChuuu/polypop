using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    private GameObject enemyAnchor;

    public EnemySettings[] enemyTypes;
    private int difficultyLevel = 0;
    
    public int spawnSpeed;

    public int spawnMaxAmount = 2;

    private IEnumerator spawnerCoroutine;

    // Start is called before the first frame update
    void Start()
    {

    }
    
    //Spawner should be on level terrain otherwise issues can occur
    private IEnumerator SpawnEnemies()
    {
        while (true)
        {
            //Extra 1 in range, Math.Random max range is not inclusive
            int spawnAmount = Random.Range(difficultyLevel+1, difficultyLevel + spawnMaxAmount + 1);
            Debug.Log(spawnAmount);
            for(int i =0; i<spawnAmount; i++)
            {
                Vector3 spawnPosition = transform.position;

                Vector3 spawnRange = transform.gameObject.GetComponent<BoxCollider>().size;
                spawnRange /= 2;

                float randomXPosition = Random.Range(-spawnRange.x, spawnRange.x);
                float randomZPosition = Random.Range(-spawnRange.z, spawnRange.z);

                spawnPosition.x += randomXPosition;
                spawnPosition.z += randomZPosition;

                int enemyType = 0;
                if (difficultyLevel > enemyTypes.Length - 1)
                {
                    enemyType = enemyTypes.Length - 1;
                }
                else
                {
                    enemyType = Random.Range(0, difficultyLevel + 1);
                }
                EnemySettings selectedEnemy = enemyTypes[enemyType];

                GameObject enemy = Instantiate<GameObject>(selectedEnemy.enemyModel);

                //Set anchor for enemy gameObjects
                enemy.transform.SetParent(enemyAnchor.transform, true);

                GameObject enemyModel = enemy.transform.Find("EnemyModel").gameObject;

                //Give enemy corresponding stats
                enemyModel.GetComponent<IEnemyTemplate>().SetEnemyStats(difficultyLevel, selectedEnemy.speed, selectedEnemy.health);

                enemyModel.transform.position = spawnPosition;
            }

            yield return new WaitForSeconds(spawnSpeed);
        }
    }

    public void SetEnemyAnchor(GameObject mapEnemyAnchor)
    {
        enemyAnchor = mapEnemyAnchor;
    }

    public void StartSpawner()
    {
        spawnerCoroutine = SpawnEnemies();
        StartCoroutine(spawnerCoroutine);
    }

    public void StopSpawner()
    {
        StopCoroutine(spawnerCoroutine);
    }

    public void IncreaseDifficulty()
    {
        difficultyLevel++;
    }

    public void SetDifficulty(int difficulty)
    {
        difficultyLevel = difficulty;
    }
}