using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{

    public int items;
    private List<ICollectable> _storedCollectables;

    private void Awake()
    {
        _storedCollectables = new List<ICollectable>();
    }

    public void Store(ICollectable collectable)
    {
        _storedCollectables.Add(collectable);
        items++;
    }

    public List<ICollectable> GetCollectables()
    {
        return _storedCollectables;
    }

    public void Clear()
    {
        _storedCollectables.Clear();
        items = 0;
    }

    public void Remove(ICollectable collectable)
    {
        _storedCollectables.Remove(collectable);
        items--;
    }
}
