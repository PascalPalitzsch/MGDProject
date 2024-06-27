using UnityEngine;
using UnityEngine.SceneManagement;

public class EndLine : MonoBehaviour
{
    private HighscoreManager highscoreManager;

    void Start()
    {
        highscoreManager = HighscoreManager.Instance;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            string playerName = PlayerPrefs.GetString("PlayerName", "Unknown");
            float startTime = PlayerPrefs.GetFloat("StartTime", 0f);
            float completionTime = Time.time - startTime;

            highscoreManager.AddHighscore(playerName, completionTime);

            // Um sicherzustellen, dass die Szene nur einmal geladen wird
            if (SceneManager.GetActiveScene().name != "Final")
            {
                SceneManager.LoadScene("Final");
            }
        }
    }
}
