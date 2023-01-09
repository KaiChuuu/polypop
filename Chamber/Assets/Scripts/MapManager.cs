using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapManager : MonoBehaviour
{
    public GameObject[] mapSpawners;

    private GameObject mapEnemyAnchor;

    // Start is called before the first frame update
    void Start()
    {
        //Create enemy anchor
        mapEnemyAnchor = new GameObject("EnemyAnchor");
        mapEnemyAnchor.transform.SetParent(transform);

        InitializeSpawners();
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
}
