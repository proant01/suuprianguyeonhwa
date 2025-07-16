using UnityEngine;

public class EnableOnStart : MonoBehaviour
{
    public GameObject targetObject1; // Inspector¿¡ ÇÒ´ç
    
    void Start()
    { 
        targetObject1.SetActive(true);
    }
}
