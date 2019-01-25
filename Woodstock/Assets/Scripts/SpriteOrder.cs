using UnityEngine;

public class SpriteOrder : MonoBehaviour
{
    private SpriteRenderer _spriteRenderer;

    private void Start()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void LateUpdate()
    {
        _spriteRenderer.sortingOrder = (int) Camera.main.WorldToScreenPoint(_spriteRenderer.bounds.min).y * -1;
    }
}