using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(AudioSource))]
public class Log : MonoBehaviour, ICollectable, IFuel
{
    private Rigidbody _rigidbody;
    int score = 7;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    public void OnCollect()
    {
        GameObject.Find("GameManager").GetComponent<GameManager>().AddScore(score);
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
