using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonClickHandler : MonoBehaviour
{
    public void LoadLevelSelectScene()
    {
        Debug.Log("Button clicked. Loading LevelSelect scene...");
        SceneManager.LoadScene("LevelSelect");
    }
}
