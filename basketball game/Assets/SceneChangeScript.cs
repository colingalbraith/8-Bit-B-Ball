using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChangeScript : MonoBehaviour
{
    public string sceneToLoad;   // The name of the scene to load

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Hoop"))
        {
            SceneManager.LoadScene(sceneToLoad);
        }
    }
}
