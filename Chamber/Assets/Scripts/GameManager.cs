using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class GameManager : MonoBehaviour
{
    public GameObject[] islands;

    private int currentIsland = 0;
    private GameObject currentIslandObject;

    float timePlayed = 0;
    static int playerScore = 0; //In seconds
    static int playerTotalKills = 0;

    public GameObject canvas;
    public GameObject player;

    public GameObject gates;
    public int disableGateTime = 10;

    public WeaponSettings[] gunList;

    public GameObject highscoreManager;

    // Start is called before the first frame update
    void Start()
    {
        SetupGame();
    }

    void SetupGame()
    {
        highscoreManager = GameObject.Find("HighscoreManager");

        currentIslandObject = Instantiate<GameObject>(islands[currentIsland]);

        playerScore = 0;
        playerTotalKills = 0;

        //StartCoroutine(UnlockGates());
    }

    // Update is called once per frame
    void Update()
    {
        timePlayed += Time.deltaTime;

        if (player.GetComponent<Player>().GetPlayerAliveStatus())
        {
            playerScore = Mathf.FloorToInt(timePlayed);
            canvas.GetComponent<CanvasManager>().UpdateScoreBoard(playerScore);
        }
    }

    public WeaponSettings LocateSelectedWeapon()
    {
        string storedGunType = PlayerPrefs.GetString("SelectedGun", "Pistol");

        for (int i = 0; i < gunList.Length; i++)
        {
            if (storedGunType.Equals(gunList[i].weaponName))
            {
                return gunList[i];
            }
        }

        //Return default as Pistol
        //Though should never happen
        return gunList[0];
    }

    public void UpdateKillTotal()
    {
        playerTotalKills++;
    }

    public void GameOver()
    {
        //Save scores if best top 5 matches
        highscoreManager.GetComponent<HighscoreManager>().UpdateScoreboard(playerScore, playerTotalKills);

        //Display GameOver screen
        canvas.GetComponent<CanvasManager>().DisplayGameOverScreen(playerScore, playerTotalKills);

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
