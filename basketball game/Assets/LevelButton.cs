using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class LevelButton : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
{
    public string levelName; // Name of the level (set this in the Inspector)
    public GameObject oneTimer; // Reference to the oneTimer GameObject (set this in the Inspector)
    public string sceneToLoad; // Scene name to load when clicking on the button (set this in the Inspector)

    private Text oneTimerText;
    private bool isHovering = false;

    private void Start()
    {
        oneTimerText = oneTimer.GetComponent<Text>();
        SetOneTimerVisibility(false);
    }

    private void Update()
    {
        if (isHovering)
        {
            UpdateOneTimerText();
        }
    }

    private void SetOneTimerVisibility(bool isVisible)
    {
        oneTimer.SetActive(isVisible);
    }

    private void UpdateOneTimerText()
    {
        // Fetch the best time for this level from PlayerPrefs
        float bestTime = PlayerPrefs.GetFloat(levelName, Mathf.Infinity);

        // Display the best time on the UI Text component
        oneTimerText.text = "Best Time: " + FormatTime(bestTime);
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
        isHovering = true;
        SetOneTimerVisibility(true);
    }

    // Implement the IPointerExitHandler interface to detect mouse exit
    public void OnPointerExit(PointerEventData eventData)
    {
        isHovering = false;
        SetOneTimerVisibility(false);
    }

    // Implement the IPointerClickHandler interface to detect mouse click
    public void OnPointerClick(PointerEventData eventData)
    {
        // Load the specified scene when clicking on the "Levelone" GameObject
        SceneManager.LoadScene(sceneToLoad);
    }
}
