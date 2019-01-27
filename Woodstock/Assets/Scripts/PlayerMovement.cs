using System;
using UnityEngine;
using UnityEngine.Events;

public class PlayerMovement : MonoBehaviour
{
    public UnityEvent onStepTaken = new UnityEvent();

    public float speed = 10;
    public float stepLength = 0.5f;
    public float stepHeight = 0.1f;

    public GameObject lamp;

    private Rigidbody _rigidbody;
    private MeshRenderer _renderer;

    private float stepProgress;

    private bool immobilized;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _renderer = GetComponentInChildren<MeshRenderer>();
    }

    public void Immobilize()
    {
        immobilized = true;
    }

    void FixedUpdate()
    {
        if (immobilized)
        {
            _rigidbody.velocity = Vector3.zero;
            return;
        }

        var horizontal = Input.GetAxis("Horizontal");
        var vertical = Input.GetAxis("Vertical");
        _rigidbody.velocity = new Vector3(speed * horizontal, 0, speed * vertical);

        var moveDistance = _rigidbody.velocity.magnitude;
        stepProgress += moveDistance * Time.deltaTime;
        var y = Mathf.Lerp(0, stepHeight, stepProgress / stepLength);
        transform.position = new Vector3(transform.position.x, y, transform.position.z);
        if (stepProgress > 0)
        {
            if (Math.Abs(moveDistance) < 0.01f || stepProgress >= stepLength)
            {
                stepProgress = 0;
                transform.position = new Vector3(transform.position.x, 0, transform.position.z);
                onStepTaken.Invoke();
            }
        }


        if (horizontal > 0)
        {
            transform.localScale = new Vector3(1, transform.localScale.y, transform.localScale.z);
            lamp.transform.localScale = new Vector3(Mathf.Abs(lamp.transform.localScale.x), lamp.transform.localScale.y,
                lamp.transform.localScale.z); //_renderer.material.SetTextureScale("_MainTex", new Vector2(1, 1));
        }
        else if (horizontal < 0)
        {
            transform.localScale = new Vector3(-1, transform.localScale.y, transform.localScale.z);
            lamp.transform.localScale = new Vector3(-Mathf.Abs(lamp.transform.localScale.x),
                lamp.transform.localScale.y, lamp.transform.localScale.z);
            //_renderer.material.SetTextureScale("_MainTex", new Vector2(-1, 1));
        }
    }
}