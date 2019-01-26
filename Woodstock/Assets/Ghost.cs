using UnityEditor;
using UnityEngine;
using UnityEngine.Events;

public class Ghost : MonoBehaviour
{
    public float speed = 2f;

    public UnityEvent onPlayerCaught = new UnityEvent();

    private GameObject target;

    private Rigidbody _rigidbody;

    private void Start()
    {
        target = GameObject.FindWithTag("Player");
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == target)
        {
            onPlayerCaught.Invoke();
        }
    }

    private void Update()
    {
        if (targetSafe())
        {
            RunAway();
        }
        else
        {
            FollowTarget();
        }
    }

    private void RunAway()
    {
        _rigidbody.velocity = (Vector3.zero - transform.position).normalized * speed;
    }

    private void FollowTarget()
    {
        _rigidbody.velocity = (target.transform.position - transform.position).normalized * speed;
    }

    private bool targetSafe()
    {
        return false;
    }
}