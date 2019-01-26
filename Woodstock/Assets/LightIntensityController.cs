using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightIntensityController : MonoBehaviour
{
    private Light light;
    private float initIntensity;
    private float strengthPercent = 100f;
    // Start is called before the first frame update
    void Start()
    {
        light = GetComponentInChildren<Light>();
        initIntensity = light.intensity;
    }

    // Update is called once per frame
    void Update()
    {
        GameObject fireplace = GameObject.Find("Fireplace");
        strengthPercent = 100 / fireplace.GetComponent<Fireplace>().initialTimeLeft * fireplace.GetComponent<Fireplace>()._remainingTime;
        Debug.Log(strengthPercent);
        float newIntensity = initIntensity / 100 * strengthPercent;
        light.intensity = newIntensity;
    }
}
