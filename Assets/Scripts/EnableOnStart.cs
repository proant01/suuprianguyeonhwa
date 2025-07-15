using UnityEngine;

public class EnableOnStart : MonoBehaviour
{
    public GameObject targetObject; // Inspector¿¡ ÇÒ´ç

    void Start()
    {
        targetObject.SetActive(true);
    }
}
