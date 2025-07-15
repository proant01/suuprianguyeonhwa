using UnityEngine;

[RequireComponent(typeof(PolygonCollider2D))]
[RequireComponent(typeof(MeshFilter))]
[RequireComponent(typeof(MeshRenderer))]
public class DynamicTriangle : MonoBehaviour
{
    public float baseLength = 2f;        // �غ� ����
    [Range(1, 89)] public float angle = 45f; // ���� �ݴ� ����

    private PolygonCollider2D poly;
    private MeshFilter meshFilter;

    void Start()
    {
        poly = GetComponent<PolygonCollider2D>();
        meshFilter = GetComponent<MeshFilter>();
        UpdateShape();
    }

    void Update()
    {
        UpdateShape();
    }

    void UpdateShape()
    {
        // ���� �� ���� ��ȯ
        float rad = angle * Mathf.Deg2Rad;
        // ���� = tan(angle) * baseLength
        float height = Mathf.Tan(rad) * baseLength;

        // 2D Collider�� �� ����
        Vector2[] colliderPoints = new Vector2[]
        {
            Vector2.zero,
            new Vector2(baseLength, 0),
            new Vector2(0, height)
        };
        poly.points = colliderPoints;

        // Mesh�� �� ���� (Vector3)
        Vector3[] vertices = new Vector3[]
        {
            colliderPoints[0],
            colliderPoints[1],
            colliderPoints[2]
        };

        // �ﰢ�� �ε���
        int[] triangles = new int[] { 0, 1, 2 };

        // Mesh ���� & ����
        Mesh mesh = new Mesh();
        mesh.vertices = vertices;
        mesh.triangles = triangles;
        mesh.RecalculateNormals();
        mesh.RecalculateBounds();

        // MeshFilter�� ����
        meshFilter.mesh = mesh;
    }
}
