using UnityEngine;

public class BallLandingDetector : MonoBehaviour
{
    public float R = 0f;

    Rigidbody2D rb;

    public BallController ballController;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.collider.CompareTag("Ground"))
        {
            float x = transform.position.x;
            Debug.Log("구슬이 땅에 도달! X좌표: " + x);

            R = x - ballController.projectileTriggerX;
            Debug.Log("(x좌표 측정) R 값: " + R);
        }
    }
}
