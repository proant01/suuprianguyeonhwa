using UnityEngine;

public class EnableOnStart : MonoBehaviour
{
    public GameObject targetObject; // Inspector�� �Ҵ�
    public GameObject targetObject1; // Inspector�� �Ҵ�
    
    void Start()
    {
        targetObject.SetActive(true);
        targetObject1.SetActive(true);
    }
}
