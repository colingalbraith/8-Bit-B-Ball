using UnityEngine;
using UnityEngine.SceneManagement;

public class KillPlayer : MonoBehaviour
{
    public string deathSceneName; // Name of the scene to transition to upon killing the player

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Kill();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Kill();
        }
    }

    private void Kill()
    {
        SceneManager.LoadScene(deathSceneName);
    }
}
