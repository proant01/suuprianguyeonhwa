using UnityEngine;
using TMPro;

public class BallTrailRecorder : MonoBehaviour
{
    public GameObject ghostPrefab;             // 복사할 공 프리팹
    public Transform targetObject;             // 위치 참조용 오브젝트
    public TMP_InputField intervalInputField;  // TMP 입력 필드로 복사 주기 입력

    private float spawnInterval = 1f; // 복사 주기 (초)
    private float timer = 0f;
    private bool isRecording = false; // 시작 버튼 클릭 여부

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
            rb.simulated = false; // 물리 작용 없음
        }

        SpriteRenderer sr = ghost.GetComponent<SpriteRenderer>();
        if (sr != null)
        {
            Color color = sr.color;
            color.a = 0.5f; // 반투명 잔상
            sr.color = color;
        }

        Destroy(ghost, 10f); // 10초 후 자동 삭제
    }

    void OnIntervalInputChanged(string input)
    {
        if (float.TryParse(input, out float parsedValue) && parsedValue > 0f)
        {
            spawnInterval = parsedValue;
            Debug.Log($"복사 주기 설정됨: {spawnInterval}초");
        }
        //else
        //{
        //    Debug.LogWarning("잘못된 입력: 복사 주기는 0보다 커야 합니다.");
        //}
    }

    // 외부에서 호출하여 기록 시작
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