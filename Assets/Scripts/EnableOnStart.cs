using UnityEngine;

public class EnableOnStart : MonoBehaviour
{
    public GameObject targetObject; // Inspector에 할당
    public GameObject targetObject1; // Inspector에 할당
    
    void Start()
    {
        targetObject.SetActive(true);
        targetObject1.SetActive(true);
    }
}
