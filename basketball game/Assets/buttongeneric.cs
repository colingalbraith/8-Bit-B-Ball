using UnityEngine;
using UnityEngine.SceneManagement;

public class buttongeneric : MonoBehaviour
{
    public string sceneToLoad;

    public void LoadScene()
    {
        Debug.Log("Button clicked. Loading scene: " + sceneToLoad);
        SceneManager.LoadScene(sceneToLoad);
    }
}
