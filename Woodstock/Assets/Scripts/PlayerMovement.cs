using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 10;

    private Rigidbody _rigidbody;
    private MeshRenderer _renderer;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _renderer = GetComponentInChildren<MeshRenderer>();
    }

    void Update()
    {
        var horizontal = Input.GetAxis("Horizontal");
        var vertical = Input.GetAxis("Vertical");
        _rigidbody.velocity = new Vector3(speed * horizontal, 0, speed * vertical);

        if (horizontal > 0)
        {
            _renderer.material.SetTextureScale("_MainTex", new Vector2(1, 1));
        }
        else if (horizontal < 0)
        {
            _renderer.material.SetTextureScale("_MainTex", new Vector2(-1, 1));
        }
    }
}