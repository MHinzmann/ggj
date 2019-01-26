using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Collector : MonoBehaviour
{
    [System.Serializable]
    public class OnCollect : UnityEvent<ICollectable>
    {
 
    }
    
    public float suckSpeed = 1;
    public float collectionRange = 0.5f;
    public OnCollect onCollect = new OnCollect();
    
    private SphereCollider _sphereCollider;
    private List<ICollectable> _collectablesInSuckRange;

    private void Awake()
    {
        _sphereCollider = GetComponent<SphereCollider>();
        _collectablesInSuckRange = new List<ICollectable>();
    }

    private void OnTriggerEnter(Collider other)
    {
        var collectable = other.gameObject.GetComponent<ICollectable>();
        if (collectable != null)
        {
            _collectablesInSuckRange.Add(collectable);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        var collectable = other.gameObject.GetComponent<ICollectable>();
        if (_collectablesInSuckRange.Contains(collectable))
        {
            _collectablesInSuckRange.Remove(collectable);
            var collectableRigidbody = collectable.GetRigidbody();
            collectableRigidbody.velocity = new Vector3();
        }
    }

    private void Update()
    {
        SuckCollectablesIn();
        CollectNearEnoughCollectables();
    }

    private void CollectNearEnoughCollectables()
    {
        new List<ICollectable>(_collectablesInSuckRange).ForEach(CollectIfNearEnough);
    }

    private void CollectIfNearEnough(ICollectable collectable)
    {
        var distance = gameObject.transform.position - collectable.GetRigidbody().position;
        if (distance.magnitude <= collectionRange)
        {
            _collectablesInSuckRange.Remove(collectable);
            onCollect.Invoke(collectable);
            collectable.OnCollect();
        }
    }

    private void SuckCollectablesIn()
    {
        _collectablesInSuckRange.ForEach(SuckCollectableIn);
    }

    private void SuckCollectableIn(ICollectable collectable)
    {
        var collectableRigidbody = collectable.GetRigidbody();
        var distance = gameObject.transform.position - collectableRigidbody.position;
        var suckDirection = distance.normalized;
        var interpolation = distance.magnitude / _sphereCollider.radius;
        collectableRigidbody.velocity = suckDirection * Mathf.Lerp(suckSpeed, 0, interpolation);
    }
}