using UnityEngine;

public class Collector : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        var collectable = other.gameObject.GetComponent<Collectable>();
        if (collectable != null)
        {
            collectable.OnCollect();
        }
    }
}