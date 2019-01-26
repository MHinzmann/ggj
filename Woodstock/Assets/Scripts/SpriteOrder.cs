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
        transform.rotation = Camera.main.transform.rotation;
        transform.Rotate(Vector3.right, -30);
    }
}