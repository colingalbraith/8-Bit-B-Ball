using UnityEngine;
using UnityEngine.SceneManagement;

public class ReturnToPreviousScene : MonoBehaviour
{
    public void ReturnToPrevious()
    {
        int previousSceneIndex = SceneManager.GetActiveScene().buildIndex - 1;
        SceneManager.LoadScene(previousSceneIndex);
    }
}
