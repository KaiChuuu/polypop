using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class HighscoreManager : MonoBehaviour
{
    private Highscores highscoreEntries;

    public int savedScoreListLimit = 5;

    //Singleton class
    public static HighscoreManager instance;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);

        GrabSavedScoreboard();
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GrabSavedScoreboard()
    {
        string savedHighscoreEntriesJson = PlayerPrefs.GetString("HighscoreEntries", "");

        //If no entry has been created before
        if ("".Equals(savedHighscoreEntriesJson))
        {
            highscoreEntries = new Highscores();
            highscoreEntries.highscoreEntryList = new List<HighscoreEntry>();
        }
        else
        {
            highscoreEntries = JsonUtility.FromJson<Highscores>(savedHighscoreEntriesJson);
        }
    }

    public void UpdateScoreboard(int playerScore, int playerTotalKills)
    {
        DateTime localDay = DateTime.Today;
        string highscoreDay = localDay.ToString("d"); // MM/DD/YYYY

        // For empty scoreboards
        if (highscoreEntries.highscoreEntryList.Count == 0)
        {
            highscoreEntries.highscoreEntryList.Add(
                new HighscoreEntry
                {
                    score = playerScore,
                    killCount = playerTotalKills,
                    date = highscoreDay
                });
        }
        // For filled scoreboards
        else
        {
            for (int i = 0; i < highscoreEntries.highscoreEntryList.Count; i++)
            {
                if (highscoreEntries.highscoreEntryList[i].score == playerScore)
                {
                    if(highscoreEntries.highscoreEntryList[i].killCount < playerTotalKills)
                    {
                        highscoreEntries.highscoreEntryList.Insert(i,
                        new HighscoreEntry
                        {
                            score = playerScore,
                            killCount = playerTotalKills,
                            date = highscoreDay
                        });
                    }
                    else
                    {
                        int newPosition = CheckListFromTotalKills(i+1, playerScore, playerTotalKills, highscoreDay);

                        highscoreEntries.highscoreEntryList.Insert(newPosition,
                        new HighscoreEntry
                        {
                            score = playerScore,
                            killCount = playerTotalKills,
                            date = highscoreDay
                        });
                    }

                    if (highscoreEntries.highscoreEntryList.Count > 5)
                    {
                        highscoreEntries.highscoreEntryList.RemoveAt(highscoreEntries.highscoreEntryList.Count - 1);
                    }

                    break;
                }

                if (highscoreEntries.highscoreEntryList[i].score < playerScore)
                {
                    highscoreEntries.highscoreEntryList.Insert(i,
                        new HighscoreEntry
                        {
                            score = playerScore,
                            killCount = playerTotalKills,
                            date = highscoreDay
                        });

                    if (highscoreEntries.highscoreEntryList.Count > 5)
                    {
                        highscoreEntries.highscoreEntryList.RemoveAt(highscoreEntries.highscoreEntryList.Count - 1);
                    }

                    break;
                }

                if (i == highscoreEntries.highscoreEntryList.Count - 1 && highscoreEntries.highscoreEntryList.Count < savedScoreListLimit)
                {
                    highscoreEntries.highscoreEntryList.Add(
                        new HighscoreEntry
                        {
                            score = playerScore,
                            killCount = playerTotalKills,
                            date = highscoreDay
                        });
                }
            }
        }

        string updatedHighscoreEntriesJson = JsonUtility.ToJson(highscoreEntries);
        PlayerPrefs.SetString("HighscoreEntries", updatedHighscoreEntriesJson);
        PlayerPrefs.Save();
    }

    public int CheckListFromTotalKills(int continuedIndex, int playerScore, int playerTotalKills, string highscoreDay)
    {
        for(int y = continuedIndex; y < highscoreEntries.highscoreEntryList.Count; y++)
        {
            if (highscoreEntries.highscoreEntryList[y].score == playerScore) 
            {
                if (highscoreEntries.highscoreEntryList[y].killCount < playerTotalKills)
                {
                    return y;
                }
            }
            else
            {
                return y;
            }
        }
        return highscoreEntries.highscoreEntryList.Count;
    }

    public List<HighscoreEntry> GetSavedHighscoreEntries()
    {
        return highscoreEntries.highscoreEntryList;
    }

    public class Highscores
    {
        public List<HighscoreEntry> highscoreEntryList;
    }
}
