using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PrintScore : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        int score = GameObject.Find("ScoreHolder").GetComponent<ScoreHolder>().score;
        Text text = GetComponent<Text>();
        text.text = score.ToString();
    }

    // Update is called once per frame
    void Update()
    {

    }
}
