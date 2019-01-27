using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightIntensityController : MonoBehaviour
{
    private Light light;
    private float initIntensity;
    private float strengthPercent = 100f;

    private Fireplace _fireplace;

    void Start()
    {
        light = GetComponentInChildren<Light>();
        initIntensity = light.intensity;

        GameObject fireplace = GameObject.Find("Fireplace");
        fireplace.GetComponent<Fireplace>();
    }

    void Update()
    {
        if (_fireplace == null)
        {
            return;
        }

        strengthPercent = 100 / _fireplace.initialTimeLeft * _fireplace._remainingTime;
        float newIntensity = initIntensity / 100 * strengthPercent;
        light.intensity = newIntensity;
    }
}