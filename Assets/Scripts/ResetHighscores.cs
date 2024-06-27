using UnityEngine;
using UnityEngine.UI;

public class ResetHighscores : MonoBehaviour
{
    public Button resetButton;
    private HighscoreManager highscoreManager;

    void Start()
    {
        highscoreManager = HighscoreManager.Instance;
        if (highscoreManager == null)
        {
            Debug.LogError("HighscoreManager not found in the scene.");
        }
        resetButton.onClick.AddListener(ResetHighscoresList);
    }

    void ResetHighscoresList()
    {
        if (highscoreManager != null)
        {
            highscoreManager.ResetHighscores();
        }
    }
}
