using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapManager : MonoBehaviour
{
    public GameObject[] mapSpawners;

    private GameObject mapEnemyAnchor;

    public GameObject backgroundObjectAnchor;
    public GameObject[] backgroundObjects;
    public GameObject backgroundSpawnerLocation;
    public int[] backgroundSpawnDelay = { 3, 5 };

    // Start is called before the first frame update
    void Start()
    {
        //Create enemy anchor
        mapEnemyAnchor = new GameObject("EnemyAnchor");
        mapEnemyAnchor.transform.SetParent(transform);

        InitializeSpawners();
        StartCoroutine(SpawnBackground());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void InitializeSpawners()
    {
        for(int i =0; i<mapSpawners.Length; i++)
        {
            //Pass map enemy anchor
            mapSpawners[i].GetComponent<EnemySpawner>().SetEnemyAnchor(mapEnemyAnchor);

            mapSpawners[i].GetComponent<EnemySpawner>().StartSpawner();
        }
    }

    public void DisableSpawners()
    {
        for(int i =0; i<mapSpawners.Length; i++)
        {
            mapSpawners[i].GetComponent<EnemySpawner>().StopSpawner();
        }
    }

    public void IncreaseDifficulty()
    {
        for (int i = 0; i < mapSpawners.Length; i++)
        {
            mapSpawners[i].GetComponent<EnemySpawner>().IncreaseDifficulty();
        }
    }

    private IEnumerator SpawnBackground()
    {
        while (true)
        {
            int randomBackgroundObject = Random.Range(0, backgroundObjects.Length);
            GameObject newBackgroundObject = Instantiate<GameObject>(backgroundObjects[randomBackgroundObject]);

            Vector3 spawnPosition = backgroundSpawnerLocation.transform.position;

            Vector3 spawnRange = backgroundSpawnerLocation.GetComponent<BoxCollider>().size;
            spawnRange /= 2;

            float randomXPosition = Random.Range(-spawnRange.x, spawnRange.x);
            float randomZPosition = Random.Range(-spawnRange.z, spawnRange.z);

            spawnPosition.x += randomXPosition;
            spawnPosition.z += randomZPosition;

            newBackgroundObject.transform.position = spawnPosition;

            newBackgroundObject.transform.SetParent(backgroundObjectAnchor.transform, true);

            int delayNextSpawn = Random.Range(backgroundSpawnDelay[0], backgroundSpawnDelay[1]);
            yield return new WaitForSeconds(delayNextSpawn);
        }
    }
}
