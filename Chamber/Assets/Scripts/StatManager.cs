using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class StatManager : MonoBehaviour
{

    public GameObject highscoreManager;

    public GameObject displayRowGroupObject;

    public GameObject displayRowObject;

    // Start is called before the first frame update
    void Start()
    {
        highscoreManager = GameObject.Find("HighscoreManager");
        displayRowGroupObject = transform.Find("ScoreboardRows").gameObject;
        DisplaySavedMatches();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void DisplaySavedMatches()
    {
        List<HighscoreEntry> savedHighscoreEntries = highscoreManager.GetComponent<HighscoreManager>().GetSavedHighscoreEntries();

        // Display titles for columns
        // Required for equal spacing as objects in table, ~ needs to be the same gameObject?
        GameObject columnTitles = Instantiate(displayRowObject);
        columnTitles.transform.Find("MatchScoreColumn").GetComponent<TextMeshProUGUI>().text = "SCORE";
        columnTitles.transform.Find("MatchKillsColumn").GetComponent<TextMeshProUGUI>().text = "TOTAL KILLS";
        columnTitles.transform.Find("MatchDateColumn").GetComponent<TextMeshProUGUI>().text = "DATE";
        columnTitles.transform.SetParent(transform.Find("ScoreboardRows"));
        
        // Display match values for top games
        for (int i =0; i < savedHighscoreEntries.Count; i++)
        {

            GameObject singleMatch = Instantiate(displayRowObject);

            singleMatch.transform.Find("MatchScoreColumn").GetComponent<TextMeshProUGUI>().text = savedHighscoreEntries[i].score.ToString();
            singleMatch.transform.Find("MatchKillsColumn").GetComponent<TextMeshProUGUI>().text = savedHighscoreEntries[i].killCount.ToString();
            singleMatch.transform.Find("MatchDateColumn").GetComponent<TextMeshProUGUI>().text = savedHighscoreEntries[i].date;

            singleMatch.transform.SetParent(transform.Find("ScoreboardRows"));
        }
    }

    public void MenuButton()
    {
        SceneManager.LoadScene(0);
    }
}
