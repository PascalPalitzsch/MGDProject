using UnityEngine;
using TMPro;
using System.Collections.Generic;

public class HighscoreDisplay : MonoBehaviour
{
    public TMP_Text highscoreText;

    void Start()
    {
        Debug.Log("HighscoreDisplay Start() called.");
        HighscoreManager highscoreManager = HighscoreManager.Instance;
        if (highscoreManager != null)
        {
            List<HighscoreEntry> topHighscores = highscoreManager.GetTopHighscores(5);
            DisplayHighscores(topHighscores);
        }
        else
        {
            Debug.LogError("HighscoreManager instance not found.");
        }
    }

    public void DisplayHighscores(List<HighscoreEntry> highscores)
    {
        highscoreText.alignment = TextAlignmentOptions.Center; // Zentriere den Text
        highscoreText.text = "<b><size=36>Top 5 Highscores</size></b>\n\n"; // Header mit größerer Schriftgröße und Fettformatierung
        Debug.Log("Displaying Highscores, count: " + highscores.Count);
        for (int i = 0; i < highscores.Count; i++)
        {
            string entry = $"<b>{i + 1}. {highscores[i].playerName}</b>: <color=#00FF00>{highscores[i].time.ToString("F2")}s</color>";
            Debug.Log(entry);
            highscoreText.text += entry + "\n\n"; // Zusätzlicher Abstand zwischen den Einträgen
        }
    }
}
