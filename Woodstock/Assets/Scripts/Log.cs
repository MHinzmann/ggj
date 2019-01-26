using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(AudioSource))]
public class Log : MonoBehaviour, ICollectable, IFuel
{
    private Rigidbody _rigidbody;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    public void OnCollect()
    {
        gameObject.SetActive(false);
    }

    public Rigidbody GetRigidbody()
    {
        return _rigidbody;
    }

    public int GetFuelValue()
    {
        return 3;
    }
}