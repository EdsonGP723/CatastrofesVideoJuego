using UnityEngine;
using TMPro;
using System;

public class DecisionTimer : MonoBehaviour
{
    public TextMeshProUGUI timerText;
    public float timeLimit = 10f;
    private float currentTime;
    private bool isRunning = false;
    public Action onTimerEnd;

    void Start()
    {
        currentTime = timeLimit;
        UpdateTimerText();
    }

    void Update()
    {
        if (isRunning)
        {
            currentTime -= Time.deltaTime;
            UpdateTimerText();

            if (currentTime <= 0f)
            {
                currentTime = 0f;
                isRunning = false;
                onTimerEnd?.Invoke();
            }
        }
    }

    public void StartTimer()
    {
        currentTime = timeLimit;
        isRunning = true;
        UpdateTimerText();
        ShowTimer(true); // Mostrar el temporizador cuando se inicie
    }

    public void StopTimer()
    {
        isRunning = false;
        ShowTimer(false); // Ocultar el temporizador cuando se detenga
    }

    public void ShowTimer(bool show)
    {
        timerText.gameObject.SetActive(show);
    }

    private void UpdateTimerText()
    {
        timerText.text = Mathf.Ceil(currentTime).ToString();
    }
}
