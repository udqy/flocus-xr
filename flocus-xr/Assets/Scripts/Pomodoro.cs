using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System;

public class Pomodoro : MonoBehaviour
{
    [Header("Timer Settings")]
    public int workMinutes = 25;
    public int breakMinutes = 5;

    [Header("UI References")]
    public TextMeshProUGUI timerText;
    public Button startPauseButton;
    public Button resetButton;
    public Button modeToggleButton;
    public TextMeshProUGUI startPauseButtonText;
    public TextMeshProUGUI modeToggleButtonText;

    private float currentTime;
    private bool isRunning = false;
    private bool isWorkMode = true;

    void Start()
    {
        ResetTimer();
    }

    void Update()
    {
        if (isRunning)
        {
            currentTime -= Time.deltaTime;

            if (currentTime <= 0)
            {
                currentTime = 0;
                isRunning = false;
                PlaySound();
                ToggleMode();
            }

            UpdateTimerDisplay();
        }
    }

    public void ToggleStartPause()
    {
        isRunning = !isRunning;
        startPauseButtonText.text = isRunning ? "Pause" : "Start";
    }

    public void ResetTimer()
    {
        isRunning = false;
        currentTime = isWorkMode ? workMinutes * 60 : breakMinutes * 60;
        UpdateTimerDisplay();
        startPauseButtonText.text = "Start";
    }

    public void ToggleMode()
    {
        isWorkMode = !isWorkMode;
        modeToggleButtonText.text = isWorkMode ? "Break" : "Work";
        ResetTimer();
    }

    private void UpdateTimerDisplay()
    {
        int minutes = Mathf.FloorToInt(currentTime / 60);
        int seconds = Mathf.FloorToInt(currentTime % 60);
        timerText.text = string.Format("{0:00}\n{1:00}", minutes, seconds);
    }

    private void PlaySound()
    {
        // Add sound effect when timer completes
        GetComponent<AudioSource>().Play();
    }
}