using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class RetryButton : MonoBehaviour
{
    public Button retryButton;

    void Start()
    {
        retryButton.onClick.AddListener(OnRetryButtonClick);
    }

    void OnRetryButtonClick()
    {
        // Setze den Startzeitpunkt des Timers auf die aktuelle Zeit
        PlayerPrefs.SetFloat("StartTime", Time.time);

        // Lade die Startszene neu (ersetze "level 1" durch den Namen deiner Startszene)
        SceneManager.LoadScene("level 1");
    }
}
