using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class HighscoreEntry
{
    public string playerName;
    public float time;
}

public class HighscoreManager : MonoBehaviour
{
    public static HighscoreManager Instance { get; private set; }
    public List<HighscoreEntry> highscores = new List<HighscoreEntry>();
    public int maxEntries = 10;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        LoadHighscores();
    }

    public void AddHighscore(string playerName, float time)
    {
        Debug.Log($"Adding highscore: {playerName}, Time: {time}");

        // Überprüfen, ob der Highscore bereits existiert
        foreach (var entry in highscores)
        {
            if (entry.playerName == playerName && Mathf.Approximately(entry.time, time))
            {
                Debug.Log("Duplicate highscore entry detected. Skipping add.");
                return;
            }
        }

        highscores.Add(new HighscoreEntry { playerName = playerName, time = time });
        highscores.Sort((x, y) => x.time.CompareTo(y.time));

        if (highscores.Count > maxEntries)
        {
            highscores.RemoveAt(highscores.Count - 1);
        }

        SaveHighscores();
        Debug.Log("Highscores after adding:");
        PrintHighscores();
    }

    public void SaveHighscores()
    {
        for (int i = 0; i < highscores.Count; i++)
        {
            PlayerPrefs.SetString("HighscoreName" + i, highscores[i].playerName);
            PlayerPrefs.SetFloat("HighscoreTime" + i, highscores[i].time);
        }
    }

    public void LoadHighscores()
    {
        highscores.Clear();
        for (int i = 0; i < maxEntries; i++)
        {
            if (PlayerPrefs.HasKey("HighscoreName" + i))
            {
                string name = PlayerPrefs.GetString("HighscoreName" + i);
                float time = PlayerPrefs.GetFloat("HighscoreTime" + i);
                highscores.Add(new HighscoreEntry { playerName = name, time = time });
            }
        }
        Debug.Log("Highscores after loading:");
        PrintHighscores();
    }

    public void ResetHighscores()
    {
        highscores.Clear();
        for (int i = 0; i < maxEntries; i++)
        {
            PlayerPrefs.DeleteKey("HighscoreName" + i);
            PlayerPrefs.DeleteKey("HighscoreTime" + i);
        }
        SaveHighscores(); // Leere Highscore-Liste speichern
        Debug.Log("Highscores after resetting:");
        PrintHighscores();
    }

    public List<HighscoreEntry> GetTopHighscores(int top)
    {
        return highscores.GetRange(0, Mathf.Min(top, highscores.Count));
    }

    private void PrintHighscores()
    {
        for (int i = 0; i < highscores.Count; i++)
        {
            Debug.Log($"{i + 1}. {highscores[i].playerName}: {highscores[i].time.ToString("F2")}s");
        }
    }
}
