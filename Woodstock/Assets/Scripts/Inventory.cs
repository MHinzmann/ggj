using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{

    private List<ICollectable> _storedCollectables;

    private void Awake()
    {
        _storedCollectables = new List<ICollectable>();
    }

    public void Store(ICollectable collectable)
    {
        _storedCollectables.Add(collectable);
    }

    public List<ICollectable> GetCollectables()
    {
        return _storedCollectables;
    }

    public void Clear()
    {
        _storedCollectables.Clear();
    }

    public void Remove(ICollectable collectable)
    {
        _storedCollectables.Remove(collectable);
    }
}
