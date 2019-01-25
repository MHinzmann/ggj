using UnityEngine;

public interface ICollectable
{
    void OnCollect();

    Rigidbody GetRigidbody();
}