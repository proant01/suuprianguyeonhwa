using UnityEngine;

public class SlopeController : MonoBehaviour
{
    private MeshRenderer meshRenderer;

    void Awake()
    {
        meshRenderer = GetComponent<MeshRenderer>();
    }

    public void SetSlopeColor(Color color)
    {
        // material.color ����
        meshRenderer.material.color = color;
    }
}
