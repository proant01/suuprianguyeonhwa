using UnityEngine;

public class BallController : MonoBehaviour
{
    public float frictionCoefficient = 0f; // 마찰계수

    public void SetFriction(float value)
    {
        frictionCoefficient = value;
        Debug.Log("마찰계수 설정됨: " + frictionCoefficient);
    }

    // 이후 이 값을 물리 계산에 사용하면 됨
}
