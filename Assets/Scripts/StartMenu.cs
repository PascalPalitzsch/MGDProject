using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;  // Stelle sicher, dass du die TextMeshPro-Namespaces verwendest
using UnityEngine.UI;

public class StartMenu : MonoBehaviour
{
    public TMP_InputField nameInputField; // Ändere das Typ des InputFields zu TMP_InputField
    public Button startButton; // Button bleibt gleich

    void Start()
    {
        startButton.onClick.AddListener(OnStartButtonClick);
    }

    void OnStartButtonClick()
    {
        string playerName = nameInputField.text;
        PlayerPrefs.SetString("PlayerName", playerName);
        SceneManager.LoadScene("level 1"); // Ändere dies zu deiner Levelszene
    }
}
