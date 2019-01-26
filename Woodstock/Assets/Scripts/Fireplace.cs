using UnityEngine;

public class Fireplace : MonoBehaviour
{
    public float feedValue;

    private float _remainingTime;

    public void Feed(IFuel fuel)
    {
        _remainingTime += feedValue * fuel.GetFuelValue();
    }

    private void Update()
    {
        _remainingTime -= Time.deltaTime;
    }
}