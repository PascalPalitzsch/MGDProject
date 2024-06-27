using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;

public class StartMenu : MonoBehaviour
{
    public TMP_InputField nameInputField;
    public Button startButton;

    void Start()
    {
        startButton.onClick.AddListener(OnStartButtonClick);
    }

    void OnStartButtonClick()
    {
        string playerName = nameInputField.text;
        PlayerPrefs.SetString("PlayerName", playerName);
        PlayerPrefs.SetFloat("StartTime", Time.time);
        SceneManager.LoadScene("level 1");
    }
}
