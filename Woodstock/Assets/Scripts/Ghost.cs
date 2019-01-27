using System;
using UnityEngine;
using UnityEngine.Events;
using Random = UnityEngine.Random;

public class Ghost : MonoBehaviour
{
    public float speed = 2f;
    public float hideDistance = 5;
    public float hauntTime = 5;

    public UnityEvent onPlayerCaught = new UnityEvent();

    private GameObject target;

    private Rigidbody _rigidbody;

    private bool runningAway;
    private SafeZone _safeZone;

    private bool playerCaught;

    private float _timePassed;

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

        _timePassed += Time.deltaTime;
        
        if (_safeZone.IsInSafeZone() || _safeZone.IsInSafeZone(transform.position))
        {
            _timePassed = hauntTime;
        }

        if (_timePassed >= hauntTime)
        {
            RunAway();
            if (FarEnoughAway())
            {
                if (_safeZone.IsInSafeZone())
                {
                    Idle();
                }
                else
                {
                    Teleport();
                }
            }
        }
        else
        {
            FollowTarget();
        }
    }

    private bool FarEnoughAway()
    {
        return (target.transform.position - transform.position).magnitude > hideDistance;
    }

    public void RunAway()
    {
        _rigidbody.velocity = (transform.position - target.transform.position).normalized * speed;
    }

    private void Idle()
    {
        _rigidbody.velocity = Vector3.zero;
    }

    private void Teleport()
    {
        var x = Random.Range(-1f, 1f);
        var z = Random.Range(-1f, 1f);
        var randomDirection = new Vector3(x, 0, z).normalized;
        var spawnPoint = target.transform.position + (randomDirection * hideDistance);
        transform.position = spawnPoint;
        _timePassed = 0;
    }

    private void FollowTarget()
    {
        _rigidbody.velocity = (target.transform.position - transform.position).normalized * speed;
    }
}