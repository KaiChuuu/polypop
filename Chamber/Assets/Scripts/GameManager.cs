using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    float timePlayed = 0;
    static int playerScore = 0; //In seconds

    public GameObject canvas;
    public GameObject player;

    public GameObject spawnField;
    public float spawnDelay = 5.0f;

    public GameObject enemyPrefab;

    public GameObject gates;
    public int disableGateTime = 10;

    // Start is called before the first frame update
    void Start()
    {
        SetupGame();
    }

    void SetupGame()
    {
        //StartCoroutine(SpawnEnemies());
        //StartCoroutine(UnlockGates());
    }
    
    IEnumerator SpawnEnemies()
    {
        while (player.GetComponent<Player>().GetPlayerAliveStatus())
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

        if (player.GetComponent<Player>().GetPlayerAliveStatus())
        {
            playerScore = Mathf.FloorToInt(timePlayed % 60);
            canvas.GetComponent<CanvasManager>().UpdateScoreBoard(playerScore);
        }
    }

    IEnumerator UnlockGates()
    {
        while (gates.GetComponent<GateManager>().GetGateAmount() > 0){

            Debug.Log("time");


            //Destroy Gate
            gates.GetComponent<GateManager>().DisableGate();

            yield return new WaitForSeconds(disableGateTime);
        }
    }
}
