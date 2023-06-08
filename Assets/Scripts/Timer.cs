using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    public TMP_Text timerText;
    public TMP_Text highscoreText;
    public static float elapsedTime;
    private bool countingDown = true;
    private int highscore;

    private void Start()
    {
        highscore = PlayerPrefs.GetInt("highscore");
        highscoreText.text = "Highscore: " + FormatTime(highscore);
        StartTimer();
    }

    private void Update()
    {
        if (countingDown)
        {
            elapsedTime -= Time.deltaTime;
            if (elapsedTime <= 0f)
            {
                elapsedTime = 0f;
                countingDown = false;
            }
        }
        else
        {
            elapsedTime += Time.deltaTime;
            UpdateTimerText();
        }
    }

    public void StartTimer()
    {
        elapsedTime = 3f;
        countingDown = true;
    }

    public void StopTimer()
    {
        Debug.Log("StopTimer() Called");
        int score = Mathf.FloorToInt(elapsedTime);
        if (score > highscore)
        {
            highscore = score; 
            highscoreText.text = "Highscore: " + FormatTime(highscore);
            PlayerPrefs.SetInt("highscore", highscore);
            PlayerPrefs.Save();
            Debug.Log("Saved()");
        }

    }

    private void UpdateTimerText()
    {
        int minutes = Mathf.FloorToInt(elapsedTime / 60);
        int seconds = Mathf.FloorToInt(elapsedTime % 60);
        timerText.text = $"{minutes:00}:{seconds:00}";
    }

    private string FormatTime(int timeInSeconds)
    {
        int minutes = Mathf.FloorToInt(timeInSeconds / 60);
        int seconds = Mathf.FloorToInt(timeInSeconds % 60);
        return string.Format("{0:00}:{1:00}", minutes, seconds);
    }
}
