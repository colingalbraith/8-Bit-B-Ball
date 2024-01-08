using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StopwatchManager : MonoBehaviour
{
    public string levelName; // Name of the current level (make sure to set this in the Inspector)
    public string nextSceneName; // Name of the next scene to load (set this in the Inspector)

    public Text timerText; // Reference to the UI Text component to display the timer

    private float startTime;
    private float bestTime = Mathf.Infinity;

    private void Start()
    {
        // Load the best time for this level from PlayerPrefs
        if (PlayerPrefs.HasKey(levelName))
        {
            bestTime = PlayerPrefs.GetFloat(levelName);
        }

        startTime = Time.time;
    }

    private void Update()
    {
        float currentTime = Time.time - startTime;

        // Update the current playthrough time and display it on the UI Text
        if (timerText != null)
        {
            timerText.text = FormatTime(currentTime);
        }
    }

    private void OnDisable()
    {
        // Save the best time for this level to PlayerPrefs only if the current time is better
        if (Time.time - startTime < bestTime)
        {
            bestTime = Time.time - startTime;
            PlayerPrefs.SetFloat(levelName, bestTime);
        }

        // Output debug information to the console
        Debug.Log("Current Playthrough Time: " + FormatTime(Time.time - startTime));
        Debug.Log("Player's Best Time: " + FormatTime(bestTime));
    }

    public void ResetStopwatch()
    {
        // Output debug information to the console before reset
        Debug.Log("Current Playthrough Time: " + FormatTime(Time.time - startTime));
        Debug.Log("Player's Best Time: " + FormatTime(bestTime));

        startTime = Time.time;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        // Check for collisions with objects tagged "Hoop"
        if (other.CompareTag("Hoop"))
        {
            ChangeScene();
        }
    }

    private void ChangeScene()
    {
        SceneManager.LoadScene(nextSceneName);
    }

    // Format time as a string in minutes:seconds.milliseconds format
    private string FormatTime(float time)
    {
        int minutes = Mathf.FloorToInt(time / 60f);
        int seconds = Mathf.FloorToInt(time % 60f);
        int milliseconds = Mathf.FloorToInt((time * 1000f) % 1000f);
        return string.Format("{0:00}:{1:00}.{2:000}", minutes, seconds, milliseconds);
    }
}
