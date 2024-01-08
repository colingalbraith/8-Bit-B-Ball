using UnityEngine;
using UnityEngine.UI;

public class JumpCounterUI : MonoBehaviour
{
    public Text jumpCounterText;

    private int remainingJumps;

    private void Start()
    {
        UpdateJumpCounterText();
    }

    public void DecreaseJump()
    {
        remainingJumps--;
        UpdateJumpCounterText();
    }

    public void IncreaseJump(int maxJumps)
    {
        remainingJumps = maxJumps;
        UpdateJumpCounterText();
    }

    private void UpdateJumpCounterText()
    {
        jumpCounterText.text = "Jumps Remaining: " + remainingJumps.ToString();
    }
}
