using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour
{
    public Text timerText;
    public string endSceneName; // Name of the end scene

    private float startTime;
    private bool isTimerRunning = true;

    private static float finalTime; // Variable to store the final time

    private BestTimeManager bestTimeManager; // Reference to the BestTimeManager script

    void Start()
    {
        startTime = Time.time;
        bestTimeManager = FindObjectOfType<BestTimeManager>(); // Find the BestTimeManager script in the scene
    }

    void Update()
    {
        if (isTimerRunning)
        {
            float t = Time.time - startTime;

            int minutes = (int)(t / 60);
            int seconds = (int)(t % 60);
            int milliseconds = (int)((t * 1000) % 1000);

            string timerString = string.Format("{0:00}:{1:00}:{2:000}", minutes, seconds, milliseconds);
            timerText.text = timerString;
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Hoop"))
        {
            isTimerRunning = false;
            Debug.Log("Timer stopped!");

            finalTime = Time.time - startTime; // Store the final time

            Debug.Log("Final Time: " + finalTime);

            bestTimeManager.UpdateBestTime(finalTime); // Update the best time using the BestTimeManager script

            ChangeToEndScene(); // Call the method to change the scene
        }
    }

    void ChangeToEndScene()
    {
        SceneManager.LoadScene(endSceneName);
    }

    public static float GetFinalTime()
    {
        return finalTime;
    }
}
