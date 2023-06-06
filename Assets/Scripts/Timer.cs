using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    public TMP_Text timerText;
    public static float elapsedTime;
    private bool countingDown = true;


    private void Start()
    {
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
        // Optionally add any logic here when stopping the timer
    }

    private void UpdateTimerText()
    {
        int minutes = Mathf.FloorToInt(elapsedTime / 60);
        int seconds = Mathf.FloorToInt(elapsedTime % 60);
        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }
}