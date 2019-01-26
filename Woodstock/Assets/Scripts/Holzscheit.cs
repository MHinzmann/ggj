using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Holzscheit : MonoBehaviour, ICollectable
{
    private Rigidbody _rigidbody;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    public void OnCollect()
    {
        // play sound or something
        Destroy(gameObject);
    }

    public Rigidbody GetRigidbody()
    {
        return _rigidbody;
    }
}