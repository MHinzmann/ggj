using UnityEngine;

public class Tilter : MonoBehaviour
{

    void Start()
    {
        GameObject pivot = new GameObject("Pivot");
        pivot.transform.position = new Vector3(transform.position.x, 0, transform.position.z);
        pivot.transform.SetParent(transform.parent);
        transform.SetParent(pivot.transform);
        pivot.transform.Rotate(Vector3.right, 50f);
    }

}
