using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject[] islands;

    private int currentIsland = 0;
    private GameObject currentIslandObject;

    float timePlayed = 0;
    static int playerScore = 0; //In seconds

    public GameObject canvas;
    public GameObject player;

    public GameObject gates;
    public int disableGateTime = 10;

    // Start is called before the first frame update
    void Start()
    {
        SetupGame();
    }

    void SetupGame()
    {
        currentIslandObject = Instantiate<GameObject>(islands[currentIsland]);
        

        //StartCoroutine(UnlockGates());
    }

    // Update is called once per frame
    void Update()
    {
        timePlayed += Time.deltaTime;

        if (player.GetComponent<Player>().GetPlayerAliveStatus())
        {
            playerScore = Mathf.FloorToInt(timePlayed % 60);
            canvas.GetComponent<CanvasManager>().UpdateScoreBoard(playerScore);
        }
    }

    public void GameOver()
    {
        //Display GameOver screen
        canvas.GetComponent<CanvasManager>().DisplayGameOverScreen(playerScore);

        //Stop enemy spawner
        currentIslandObject.GetComponent<MapManager>().DisableSpawners();
    }


    /*
    IEnumerator UnlockGates()
    {
        while (gates.GetComponent<GateManager>().GetGateAmount() > 0){

            Debug.Log("time");


            //Destroy Gate
            gates.GetComponent<GateManager>().DisableGate();

            yield return new WaitForSeconds(disableGateTime);
        }
    }
    */
}
