using UnityEngine;
using TMPro;

public class TimerDisplay : MonoBehaviour
{
    public TMP_Text timerText;
    private float startTime;

    void Start()
    {
        // Lade den Startzeitpunkt aus PlayerPrefs oder setze ihn auf die aktuelle Zeit, falls nicht vorhanden
        startTime = PlayerPrefs.GetFloat("StartTime", Time.time);
    }

    void Update()
    {
        float currentTime = Time.time - startTime;
        timerText.text = "Time: " + currentTime.ToString("F2") + "s";
    }
}
