using UnityEngine;
using TMPro;

public class BallTrailRecorder : MonoBehaviour
{
    public GameObject ghostPrefab;             // ������ �� ������
    public Transform targetObject;             // ��ġ ������ ������Ʈ
    public TMP_InputField intervalInputField;  // TMP �Է� �ʵ�� ���� �ֱ� �Է�

    private float spawnInterval = 1f; // ���� �ֱ� (��)
    private float timer = 0f;
    private bool isRecording = false; // ���� ��ư Ŭ�� ����

    void Start()
    {
        if (intervalInputField != null)
        {
            intervalInputField.onEndEdit.AddListener(OnIntervalInputChanged);
            OnIntervalInputChanged(intervalInputField.text);
        }
    }

    void Update()
    {
        if (!isRecording || targetObject == null || ghostPrefab == null) return;

        timer += Time.deltaTime;

        if (timer >= spawnInterval)
        {
            SpawnGhost();
            timer = 0f;
        }
    }

    void SpawnGhost()
    {
        GameObject ghost = Instantiate(ghostPrefab, targetObject.position, targetObject.rotation);

        Rigidbody2D rb = ghost.GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            rb.simulated = false; // ���� �ۿ� ����
        }

        SpriteRenderer sr = ghost.GetComponent<SpriteRenderer>();
        if (sr != null)
        {
            Color color = sr.color;
            color.a = 0.5f; // ������ �ܻ�
            sr.color = color;
        }

        Destroy(ghost, 10f); // 10�� �� �ڵ� ����
    }

    void OnIntervalInputChanged(string input)
    {
        if (float.TryParse(input, out float parsedValue) && parsedValue > 0f)
        {
            spawnInterval = parsedValue;
            Debug.Log($"���� �ֱ� ������: {spawnInterval}��");
        }
        //else
        //{
        //    Debug.LogWarning("�߸��� �Է�: ���� �ֱ�� 0���� Ŀ�� �մϴ�.");
        //}
    }

    // �ܺο��� ȣ���Ͽ� ��� ����
    public void StartRecording()
    {
        isRecording = true;
        timer = 0f;
        SpawnGhost();
    }

    public void StopRecording()
    {
        isRecording = false;
    }
}