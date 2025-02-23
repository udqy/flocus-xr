using UnityEngine;
using UnityEngine.SceneManagement;

public class BreakController : MonoBehaviour
{
    void Start()
    {
        // Find the Pomodoro controller that was carried over
        Pomodoro pomodoroController = FindFirstObjectByType<Pomodoro>();
        
        if (pomodoroController != null)
        {
            // Start the break timer automatically
            pomodoroController.ResetTimer();
            pomodoroController.ToggleStartPause();
        }
        else
        {
            Debug.LogError("Pomodoro controller not found in Break scene!");
        }
    }
}