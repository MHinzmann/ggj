using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 10;
    
    private Rigidbody _rigidbody;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    void Update()
    {
        var horizontal = Input.GetAxis("Horizontal");
        var vertical = Input.GetAxis("Vertical");
        _rigidbody.velocity = new Vector3(speed * horizontal, 0, speed * vertical);
    }
}