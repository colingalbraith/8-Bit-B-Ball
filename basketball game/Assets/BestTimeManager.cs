using UnityEngine;

public class BestTimeManager : MonoBehaviour
{
    public float bestTime = Mathf.Infinity;

    private void Start()
    {
        // Load the best time from PlayerPrefs
        if (PlayerPrefs.HasKey("BestTime"))
        {
            bestTime = PlayerPrefs.GetFloat("BestTime");
        }
        else
        {
            bestTime = Mathf.Infinity;
        }
    }

    public void UpdateBestTime(float newTime)
    {
        // Compare the new time with the current best time
        if (newTime < bestTime)
        {
            bestTime = newTime;

            // Save the new best time to PlayerPrefs
            PlayerPrefs.SetFloat("BestTime", bestTime);
            PlayerPrefs.Save();
        }
    }
}
