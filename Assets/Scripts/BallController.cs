using System.Collections;
using UnityEngine;
using static TMPro.SpriteAssetUtilities.TexturePacker_JsonArray;

public class BallController : MonoBehaviour
{
    public float frictionCoefficient = 0f;
    public float g = 9.8f;
    public float baseLength = 6f;
    //public float height = 0f;
    public float R = 0f;

    private float v_actual = 0f;
    private bool velocityMeasured = false;

    public float projectileTriggerX = 3.25f; // 발사각 계산할 기준 x좌표

    private float a, f, v;
    private Rigidbody2D rb;

    public DynamicTriangle triangleRef; // 에디터에서 연결

    private enum MotionState { FreeFall, OnSlope, OnGround }
    private MotionState currentState = MotionState.OnSlope;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.simulated = false;
        rb.gravityScale = 0f;
    }

    private void Update()
    {
        SetPosition();

        if (rb.simulated && transform.position.x >= projectileTriggerX)
        {
            SpeedMeasurement();
            CalculationOfR();
        }
    }

    void FixedUpdate()
    {
        if (!rb.simulated || triangleRef == null) return;

        float theta = triangleRef.angle;
        float thetaRad = theta * Mathf.Deg2Rad;
        float sin = Mathf.Sin(thetaRad);
        float cos = Mathf.Cos(thetaRad);
        //float tan = Mathf.Tan(thetaRad);
        float m = rb.mass;

        switch (currentState)
        {
            case MotionState.OnSlope:
                a = g * (sin - frictionCoefficient * cos);
                f = m * a;
                Vector2 slopeDir = new Vector2(sin, -cos).normalized;
                rb.AddForce(slopeDir * f, ForceMode2D.Force);

                float L = baseLength / cos;
                float x = 2f * g * L * (sin - frictionCoefficient * cos);
                v = x >= 0 ? Mathf.Sqrt(x) : 0f;

                Debug.Log($"[경사면] 힘: {f:F2}, 최종 순간 속도(이론): {v:F2}, 가속도: {a:F2}");
                break;

            case MotionState.OnGround:
                //Debug.Log("[평면] 접지 상태 - 물리력 없음");
                break;

            case MotionState.FreeFall:
                float f_g = m * g;
                Vector2 freeFallDir = new Vector2(0f, -1f); // 수직 낙하
                rb.AddForce(f_g * freeFallDir, ForceMode2D.Force);
                //Debug.Log("[자유낙하] 중력 작용 중");
                break;
        }
    }


    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.collider.CompareTag("Slope"))
        {
            currentState = MotionState.OnSlope;
            rb.gravityScale = 0f;
        }
        else if (col.collider.CompareTag("Ground"))
        {
            currentState = MotionState.OnGround;
            rb.gravityScale = 0f;
        }
    }


    void OnCollisionExit2D(Collision2D col)
    {
        if (col.collider.CompareTag("Slope") || col.collider.CompareTag("Ground"))
        {
            currentState = MotionState.FreeFall;
        }
    }


    public void SetFriction(float value)
    {
        frictionCoefficient = value;
        Debug.Log("마찰계수 설정됨: " + frictionCoefficient);
    }

    public void SetPosition()
    {
        if (rb.simulated) return;

        Height();
    }

    public void StartSimulation()
    {
        rb.simulated = true;
        velocityMeasured = false;
    }

    public void Height()
    {
        if (triangleRef == null) return;

        float scaledHeight = triangleRef.height * triangleRef.transform.lossyScale.y;
        Vector3 topPos = triangleRef.transform.position + new Vector3(0f, scaledHeight + 0.25f, 0f);
        transform.position = topPos;
    }

    public void SpeedMeasurement()
    {
        if (!velocityMeasured)
        {
            v_actual = rb.linearVelocity.magnitude;
            velocityMeasured = true;

            float errorPercent = Mathf.Abs(v_actual - v) / v * 100f;

            Debug.Log($"최종 속도 측정 완료:");
            Debug.Log($"실제 속도: {v_actual:F2} m/s");
            Debug.Log($"이론 속도: {v:F2} m/s");
            Debug.Log($"오차율: {errorPercent:F2} %");
        }
    }

    public void CalculationOfR()
    {
        float theta = triangleRef.angle;
        float thetaRad = theta * Mathf.Deg2Rad;
        float vx = v * Mathf.Cos(thetaRad);
        R = vx * Mathf.Sqrt((2 * 20) / g);
        Debug.Log($"(공식 이론값) R 값: {R:F2} m");
    }
}
