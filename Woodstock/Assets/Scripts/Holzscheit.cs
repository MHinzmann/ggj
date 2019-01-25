using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Holzscheit : MonoBehaviour, Collectable
{
    public void OnCollect()
    {
        Destroy(gameObject);
    }
    
}
