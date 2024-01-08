using UnityEngine;
using UnityEngine.UI;

public class DisplayTime : MonoBehaviour
{
    public Text timeText;

    void Start()
    {
        

        float finalTime = Timer.GetFinalTime();
        Debug.Log("gotfinaltime: " + finalTime);
        int minutes = (int)(finalTime / 60);
        int seconds = (int)(finalTime % 60);
        int milliseconds = (int)((finalTime * 1000) % 1000);

        string timerString = string.Format("{0:00}:{1:00}:{2:000}", minutes, seconds, milliseconds);
        timeText.text = "Your Time: " + timerString;
    }
}
