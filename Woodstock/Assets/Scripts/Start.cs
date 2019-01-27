using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Start : MonoBehaviour
{
    public string scence;
    void Update()
    {
        if (Input.anyKey)
        {
            SceneManager.LoadScene(scence);
        }
    }


}
