using UnityEngine;

public class BallLandingDetector : MonoBehaviour
{
    public string groundTag = "Ground"; // Ground ������Ʈ�� �� �±׸� ����
    public float R = 0f;

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag(groundTag))
        {
            float x = transform.position.x;
            //Debug.Log("������ ���� ����! X��ǥ: " + x);

            R = x - 4.75f;
            Debug.Log("(x��ǥ ����) R ��: " + R);
        }
    }
}
