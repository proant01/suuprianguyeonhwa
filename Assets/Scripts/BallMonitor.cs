using TMPro;
using UnityEngine;
using UnityEngine.UI;
using static UnityEditor.PlayerSettings;

public class BallMonitor : MonoBehaviour
{
    public Rigidbody2D rb;
    public TextMeshProUGUI velocityText;
    public TextMeshProUGUI accelerationText;

    private Vector2 lastVelocity;
    private float lastTime;

    public DynamicTriangle triangleRef;
    public BallController ballController;

    void Start()
    {
        lastVelocity = rb.linearVelocity;
        lastTime = Time.time;
    }

    void Update()
    {
        float theta = triangleRef.angle;
        float thetaRad = theta * Mathf.Deg2Rad;
        float sin = Mathf.Sin(thetaRad);
        float cos = Mathf.Cos(thetaRad);

        // �ǽð� �ӵ� ���
        float speed = rb.linearVelocity.magnitude;

        // ���ӵ� ���
        float deltaTime = Time.time - lastTime;
        float acceleration = ballController.g * (sin - ballController.frictionCoefficient * cos);

        // �ؽ�Ʈ ������Ʈ
        velocityText.text = $"�ӵ� v: {speed:F2} m/s";
        accelerationText.text = $"���ӵ� a: {acceleration:F2} m/s��";

        // �� ����
        lastVelocity = rb.linearVelocity;
        lastTime = Time.time;
    }
}
