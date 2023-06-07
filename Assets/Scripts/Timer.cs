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
    private int score;
    private int highscore;
    private List<int> highscores = new List<int>();

    private void Start()
    {
        highscore = PlayerPrefs.GetInt("Highscore", 0);
        highscores = LoadHighScores();
        highscoreText.text = "Highscore: " + highscore;
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
                StopTimer();
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
        score = Mathf.FloorToInt(elapsedTime);
        if (score > highscore)
        {
            highscore = score;
            highscoreText.text = "Highscore: " + highscore;
            PlayerPrefs.SetInt("Highscore", highscore);
        }

        highscores.Add(score);
        highscores.Sort((a, b) => b.CompareTo(a));
        highscores = highscores.GetRange(0, Mathf.Min(highscores.Count, 4));
        SaveHighScores(highscores);
    }

    private void UpdateTimerText()
    {
        int minutes = Mathf.FloorToInt(elapsedTime / 60);
        int seconds = Mathf.FloorToInt(elapsedTime % 60);
        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }

    private List<int> LoadHighScores()
    {
        List<int> loadedHighScores = new List<int>();
        for (int i = 1; i <= 4; i++)
        {
            int score = PlayerPrefs.GetInt("Highscore" + i, 0);
            loadedHighScores.Add(score);
        }
        return loadedHighScores;
    }

    private void SaveHighScores(List<int> highScores)
    {
        for (int i = 0; i < highScores.Count; i++)
        {
            PlayerPrefs.SetInt("Highscore" + (i + 1), highScores[i]);
        }
    }
}
