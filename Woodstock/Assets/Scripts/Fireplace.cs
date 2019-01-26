using UnityEngine;

public class Fireplace : MonoBehaviour
{
    public float initialTimeLeft;
    public float feedValue;

    private float _remainingTime;

    private void Awake()
    {
        _remainingTime = initialTimeLeft;
    }

    public void Feed(IFuel fuel)
    {
        _remainingTime += feedValue * fuel.GetFuelValue();
    }

    private void Update()
    {
        _remainingTime -= Time.deltaTime;
    }
}