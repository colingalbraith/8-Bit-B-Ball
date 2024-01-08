using UnityEngine;
using UnityEngine.UI;

public class DashCounterUI : MonoBehaviour
{
    public Text dashCounterText;

    private int remainingDashes;

    private void Start()
    {
        UpdateDashCounterText();
    }

    public void SetDashes(int dashCount)
    {
        remainingDashes = dashCount;
        UpdateDashCounterText();
    }

    public void DecreaseDash()
    {
        remainingDashes--;
        UpdateDashCounterText();
    }

    public void ResetDash()
    {
        remainingDashes = 1;
        UpdateDashCounterText();
    }

    private void UpdateDashCounterText()
    {
        dashCounterText.text = "Dashes Remaining: " + remainingDashes.ToString();
    }
}
