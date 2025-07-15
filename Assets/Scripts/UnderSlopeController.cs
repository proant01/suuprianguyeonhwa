using UnityEngine;

public class SlopeColorController : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;

    void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public void SetSlopeColor(Color color)
    {
        spriteRenderer.color = color;
    }
}

