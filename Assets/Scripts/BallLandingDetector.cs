using UnityEngine;

public class BallLandingDetector : MonoBehaviour
{
    public string groundTag = "Ground"; // Ground 오브젝트에 이 태그를 설정
    public float R = 0f;

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag(groundTag))
        {
            float x = transform.position.x;
            //Debug.Log("구슬이 땅에 도달! X좌표: " + x);

            R = x - 4.75f;
            Debug.Log("(x좌표 측정) R 값: " + R);
        }
    }
}
