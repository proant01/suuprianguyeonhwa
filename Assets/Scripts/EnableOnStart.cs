using UnityEngine;

public class EnableOnStart : MonoBehaviour
{
    public GameObject targetObject1; // Inspector�� �Ҵ�
    
    void Start()
    { 
        targetObject1.SetActive(true);
    }
}
