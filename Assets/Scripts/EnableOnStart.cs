using UnityEngine;

public class EnableOnStart : MonoBehaviour
{
    public GameObject targetObject; // Inspector�� �Ҵ�

    void Start()
    {
        targetObject.SetActive(true);
    }
}
