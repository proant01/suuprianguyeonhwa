using UnityEngine;

public class BallController : MonoBehaviour
{
    public float frictionCoefficient = 0f; // �������

    public void SetFriction(float value)
    {
        frictionCoefficient = value;
        Debug.Log("������� ������: " + frictionCoefficient);
    }

    // ���� �� ���� ���� ��꿡 ����ϸ� ��
}
