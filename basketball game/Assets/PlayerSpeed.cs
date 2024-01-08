using UnityEngine;
using UnityEngine.UI;

public class PlayerSpeed : MonoBehaviour
{
    public Text speedText;
    private Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float speed = rb.velocity.magnitude;
        speedText.text = "Speed: " + speed.ToString("F2");
    }
}
