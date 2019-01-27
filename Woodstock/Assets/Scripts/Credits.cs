using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Credits : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        Vector3 test = new Vector3(this.gameObject.transform.position.x, this.gameObject.transform.position.y , this.gameObject.transform.position.z);


        test.y += 1;
        this.gameObject.transform.position = test;
    }
}
