using UnityEngine;

public class SpriteOrder : MonoBehaviour
{
    private SpriteRenderer _spriteRenderer;

    private void Start()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        GameObject pivot = new GameObject();
        pivot.transform.position = new Vector3(transform.position.x, 0, transform.position.z);
        pivot.transform.SetParent(transform.parent);
        transform.SetParent(pivot.transform);
        pivot.transform.Rotate(Vector3.right, 50);
    }

    void LateUpdate()
    {
        _spriteRenderer.sortingOrder = (int) (_spriteRenderer.bounds.min.z * -100f);
    }
}