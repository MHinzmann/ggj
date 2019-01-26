using UnityEngine;
using UnityEngine.Events;

public class Fireplace : MonoBehaviour
{
    private enum FireState
    {
        Out,
        Small,
        Medium,
        Big
    }

    public UnityEvent onFireBurntOut = new UnityEvent();

    public float initialTimeLeft = 50;
    public float timePerFuelValue = 10;

    public float thresholdNormalFlame = 60;
    public float thresholdSmallFlame = 30;

    public GameObject fire;
    
    public float _remainingTime;
    private FireState fireState;

    private MeshRenderer _renderer;
    private void Awake()
    {
        _remainingTime = initialTimeLeft;
        _renderer = GetComponent<MeshRenderer>();
        UpdateFireState();
    }

    public void Feed(IFuel fuel)
    {
        _remainingTime += timePerFuelValue * fuel.GetFuelValue();
    }

    private void Update()
    {
        _remainingTime -= Time.deltaTime;

        UpdateFireState();
    }

    private void UpdateFireState()
    {
        if (fireState != FireState.Out && _remainingTime <= 0)
        {
            fireState = FireState.Out;
            Destroy(fire);
            // remove fire
            // remove Light
            onFireBurntOut.Invoke();
        }
        else if (fireState != FireState.Small && _remainingTime <= thresholdSmallFlame)
        {
            fireState = FireState.Small;
            // switch texture to small flame instead
            
            // set Light
        }
        else if (fireState != FireState.Medium && _remainingTime <= thresholdNormalFlame)
        {
            fireState = FireState.Medium;
            // switch texture to normal flame
            // set Light
        }
        else if (fireState != FireState.Big && _remainingTime > thresholdNormalFlame)
        {
            fireState = FireState.Big;
            // switch texture to normal flame
            // set Light
        }
    }
}