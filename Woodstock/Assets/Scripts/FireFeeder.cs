using System.Collections.Generic;
using UnityEngine;

public class FireFeeder : MonoBehaviour
{
    public Inventory _inventory;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Fireplace"))
        {
            var fireplace = other.gameObject.GetComponent<Fireplace>();
            FeedFireplace(fireplace);
        }
    }

    private void FeedFireplace(Fireplace fireplace)
    {
        foreach (var collectable in new List<ICollectable>(_inventory.GetCollectables()))
        {
            if (collectable is IFuel)
            {
                fireplace.Feed((IFuel) collectable);
                _inventory.Remove(collectable);
            }
        }
    }
}