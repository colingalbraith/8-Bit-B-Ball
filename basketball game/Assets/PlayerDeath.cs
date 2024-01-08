using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerDeath : MonoBehaviour
{
    public float minSpeed = 1f; // Minimum speed required to stay alive
    public float speedCheckTime = 0.5f; // Time required to be under minimum speed
    public float initialWaitTime = 2f; // Time to wait at the beginning of the game
    public string deathSceneName; // Name of the scene to transition to upon death

    private float speedTimer; // Timer for tracking speed check duration
    private bool canDie; // Flag indicating if the player can die

    private void Start()
    {
        canDie = false;
        Invoke(nameof(EnableDeath), initialWaitTime);
    }

    private void Update()
    {
        if (canDie)
        {
            if (GetComponent<Rigidbody2D>().velocity.magnitude < minSpeed)
            {
                speedTimer += Time.deltaTime;
                if (speedTimer >= speedCheckTime)
                {
                    Die();
                }
            }
            else
            {
                speedTimer = 0f;
            }
        }
    }

    private void EnableDeath()
    {
        canDie = true;
    }

    private void Die()
    {
        SceneManager.LoadScene(deathSceneName);
    }
}
