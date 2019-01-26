using UnityEngine;

public class SpriteOrder : MonoBehaviour
{
    private SpriteRenderer _spriteRenderer;

    private void Start()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _spriteRenderer.transform.Rotate(Vector3.right, 50);
    }

    void LateUpdate()
    {
        _spriteRenderer.sortingOrder = (int) (_spriteRenderer.bounds.min.z * -100f);
    }
}