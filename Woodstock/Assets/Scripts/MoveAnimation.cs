using UnityEngine;

public class MoveAnimation : MonoBehaviour
{
    private Rigidbody _rigidbody;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (_rigidbody.velocity.x > 0)
        {
            
        }
        else if(_rigidbody.velocity.x < 0)
        {
            
        }
    }
}