using System;
using UnityEngine;
using UnityEngine.Events;

public class Ghost : MonoBehaviour
{
    public float speed = 2f;
    public float hideDistance = 20;

    public UnityEvent onPlayerCaught = new UnityEvent();

    private GameObject target;

    private Rigidbody _rigidbody;

    private bool runningAway;
    private SafeZone _safeZone;

    private bool playerCaught;

    private void Start()
    {
        target = GameObject.FindWithTag("Player");
        Debug.Log(target);
        _rigidbody = GetComponent<Rigidbody>();
        _safeZone = target.GetComponent<SafeZone>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == target)
        {
            onPlayerCaught.Invoke();
            playerCaught = true;
        }
    }

    private void Update()
    {
        if (playerCaught)
        {
            Idle();
            return;
        }

        if (_safeZone.IsInSafeZone())
        {
            if (FarEnoughAway())
            {
                Idle();
            }
            else
            {
                RunAway();
            }
        }
        else
        {
            FollowTarget();
        }
    }

    private bool FarEnoughAway()
    {
        return (target.transform.position - transform.position).sqrMagnitude > hideDistance * hideDistance;
    }

    public void RunAway()
    {
        _rigidbody.velocity = (transform.position - target.transform.position).normalized * speed;
    }

    private void Idle()
    {
        _rigidbody.velocity = Vector3.zero;
    }

    private void FollowTarget()
    {
        _rigidbody.velocity = (target.transform.position - transform.position).normalized * speed;
    }
}