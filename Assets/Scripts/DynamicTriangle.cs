using UnityEngine;
using TMPro; // TextMeshPro 사용

[RequireComponent(typeof(PolygonCollider2D))]
[RequireComponent(typeof(MeshFilter))]
[RequireComponent(typeof(MeshRenderer))]
public class DynamicTriangle : MonoBehaviour
{
    public TMP_InputField angleInputField; // TextMeshPro용

    public float baseLength = 2f;        // 밑변 길이
    [Range(1, 89)] public float angle = 45f; // 직각 반대 각도

    private PolygonCollider2D poly;
    private MeshFilter meshFilter;

    void Start()
    {
        poly = GetComponent<PolygonCollider2D>();
        meshFilter = GetComponent<MeshFilter>();

        if (angleInputField != null)
            angleInputField.onEndEdit.AddListener(OnAngleInputChanged);

        UpdateShape();
    }

    void Update()
    {
        UpdateShape();
    }

    void OnAngleInputChanged(string input)
    {
        if (float.TryParse(input, out float parsedAngle))
        {
            angle = Mathf.Clamp(parsedAngle, 1f, 89f); // 범위 제한 적용
            Debug.Log("입력받은 각도: " + angle);
        }
        else
        {
            Debug.LogWarning("잘못된 입력");
        }
    }

    void UpdateShape()
    {
        // 각도 → 라디안 변환
        float rad = angle * Mathf.Deg2Rad;
        // 높이 = tan(angle) * baseLength
        float height = Mathf.Tan(rad) * baseLength;

        // 2D Collider용 점 설정
        Vector2[] colliderPoints = new Vector2[]
        {
            Vector2.zero,
            new Vector2(baseLength, 0),
            new Vector2(0, height)
        };
        poly.points = colliderPoints;

        // Mesh용 점 설정 (Vector3)
        Vector3[] vertices = new Vector3[]
        {
            colliderPoints[0],
            colliderPoints[1],
            colliderPoints[2]
        };

        // 삼각형 인덱스
        int[] triangles = new int[] { 0, 1, 2 };

        // Mesh 생성 & 설정
        Mesh mesh = new Mesh();
        mesh.vertices = vertices;
        mesh.triangles = triangles;
        mesh.RecalculateNormals();
        mesh.RecalculateBounds();

        // MeshFilter에 설정
        meshFilter.mesh = mesh;
    }
}
