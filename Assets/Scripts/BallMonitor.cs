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

        // 실시간 속도 계산
        float speed = rb.linearVelocity.magnitude;

        // 가속도 계산
        float deltaTime = Time.time - lastTime;
        float acceleration = ballController.g * (sin - ballController.frictionCoefficient * cos);

        // 텍스트 업데이트
        velocityText.text = $"속도 v: {speed:F2} m/s";
        accelerationText.text = $"가속도 a: {acceleration:F2} m/s²";

        // 값 갱신
        lastVelocity = rb.linearVelocity;
        lastTime = Time.time;
    }
}
