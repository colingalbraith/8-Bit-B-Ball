using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class LevelSelectBestTimeDisplay : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public string levelName; // Name of the level whose best time you want to display (set this in the Inspector)
    public GameObject bestTimeTextBox; // Reference to the best time text box (set this in the Inspector)

    private Text bestTimeText;

    private void Start()
    {
        bestTimeText = bestTimeTextBox.GetComponent<Text>();
        UpdateBestTimeText();
        SetBestTimeTextBoxVisibility(false);
    }

    private void UpdateBestTimeText()
    {
        // Fetch the best time for this level from PlayerPrefs
        float bestTime = PlayerPrefs.GetFloat(levelName, Mathf.Infinity);

        // Display the best time on the UI Text component
        bestTimeText.text = "Best Time: " + FormatTime(bestTime);
    }

    private void SetBestTimeTextBoxVisibility(bool isVisible)
    {
        bestTimeTextBox.SetActive(isVisible);
    }

    // Format time as a string in minutes:seconds.milliseconds format
    private string FormatTime(float time)
    {
        int minutes = Mathf.FloorToInt(time / 60f);
        int seconds = Mathf.FloorToInt(time % 60f);
        int milliseconds = Mathf.FloorToInt((time * 1000f) % 1000f);
        return string.Format("{0:00}:{1:00}.{2:000}", minutes, seconds, milliseconds);
    }

    // Implement the IPointerEnterHandler interface to detect mouse over
    public void OnPointerEnter(PointerEventData eventData)
    {
        SetBestTimeTextBoxVisibility(true);
    }

    // Implement the IPointerExitHandler interface to detect mouse exit
    public void OnPointerExit(PointerEventData eventData)
    {
        SetBestTimeTextBoxVisibility(false);
    }
}
