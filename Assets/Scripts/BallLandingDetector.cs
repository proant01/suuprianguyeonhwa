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
            Debug.Log("������ ���� ����! X��ǥ: " + x);

            R = x - ballController.projectileTriggerX;
            Debug.Log("(x��ǥ ����) R ��: " + R);
        }
    }
}
