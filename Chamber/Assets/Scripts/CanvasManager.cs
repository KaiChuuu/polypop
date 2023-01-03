using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

[RequireComponent(typeof(Button))]
public class CanvasManager : MonoBehaviour
{
    //During game UI
    public TextMeshProUGUI scoreBoard;

    //Game over UI
    public GameObject gameOverObjects;

    public TextMeshProUGUI finalScore;
    public TextMeshProUGUI finalKillCount;

    public Button playAgainButton;
    public Button shopButton;


    // Start is called before the first frame update
    void Start()
    {
        playAgainButton.onClick.AddListener(PlayAgainButton);
        shopButton.onClick.AddListener(AccessShop);
        gameOverObjects.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /*************************************************/
    //During game UI
    /*************************************************/
    public void UpdateScoreBoard(int score)
    {
        scoreBoard.text = score.ToString();
    }

    /*************************************************/
    //Game over UI
    /*************************************************/
    public void DisplayGameOverScreen(int finalScoreCount, int finalTotalKills)
    {
        //Disable during game UI
        //Reset scoreboard text?
        scoreBoard.gameObject.SetActive(false);
        
        gameOverObjects.SetActive(true);


        finalScore.text = finalScoreCount.ToString();
        finalKillCount.text = finalTotalKills.ToString();
    }

    public void PlayAgainButton()
    {
        SceneManager.LoadScene(0);
    }

    public void AccessShop()
    {
        SceneManager.LoadScene(2);
    }
}
