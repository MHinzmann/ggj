using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Credits : MonoBehaviour
{
    void Update()
    {
        var transform = gameObject.transform;
        Vector3 test = new Vector3(transform.position.x, transform.position.y , transform.position.z);
        test.y += 1;

        transform.position = test;
    }
}
