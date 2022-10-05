using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    float timePlayed = 0;
    static int playerScore = 0;

    public GameObject canvas;
    public GameObject player;

    public GameObject spawnField;
    public float spawnDelay = 5.0f;

    public GameObject enemyPrefab;

    // Start is called before the first frame update
    void Start()
    {
        setupGame();
    }

    void setupGame()
    {
        StartCoroutine(SpawnEnemies());
    }
    
    IEnumerator SpawnEnemies()
    {
        while (player.GetComponent<Player>().getPlayerAliveStatus())
        {
            int spawnAmount = Random.Range(1, 3);

            //Debug.Log(spawnField.gameObject.transform.position);
            Vector3 spawnPosition = spawnField.gameObject.transform.position;

            Vector3 spawnRange = spawnField.gameObject.GetComponent<BoxCollider>().size;
            spawnRange /= 2;

            float randomXPosition = Random.Range(-spawnRange.x, spawnRange.x);
            float randomZPosition = Random.Range(-spawnRange.z, spawnRange.z);

            spawnPosition.x += randomXPosition;
            spawnPosition.z += randomZPosition;
            //Debug.Log(spawnPosition);

            //Spawn Enemy
            GameObject enemy = Instantiate<GameObject>(enemyPrefab);
            enemy.transform.position = spawnPosition;

            yield return new WaitForSeconds(spawnDelay);
        }
    }

    // Update is called once per frame
    void Update()
    {
        timePlayed += Time.deltaTime;

        //Debug.Log(Mathf.FloorToInt(timePlayed % 60));

        if (player.GetComponent<Player>().getPlayerAliveStatus())
        {
            playerScore = Mathf.FloorToInt(timePlayed % 60);
            canvas.GetComponent<CanvasManager>().updateScoreBoard(playerScore);
        }
    }
}
