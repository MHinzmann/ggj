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

    public float _remainingTime;

    public GameObject fire;
    
    private FireState fireState;

    private void Awake()
    {
        _remainingTime = initialTimeLeft;
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
        if (_remainingTime <= 0)
        {
            if (fireState == FireState.Out) return;
            Debug.Log("Flame is out");

            fireState = FireState.Out;

            Destroy(fire);

            onFireBurntOut.Invoke();
        }
        else if (_remainingTime <= thresholdSmallFlame)
        {
            if (fireState == FireState.Small) return;
            Debug.Log("Flame is small");

            fireState = FireState.Small;
            fire.transform.localScale = new Vector3(0.33f, 0.33f, 1);
            // set Light
        }
        else if (_remainingTime <= thresholdNormalFlame)
        {
            if (fireState == FireState.Medium) return;
            
            Debug.Log("Flame is medium");
            
            fireState = FireState.Medium;
            fire.transform.localScale = new Vector3(0.66f, 0.66f, 1);
            // set Light
        }
        else if (_remainingTime > thresholdNormalFlame)
        {
            if (fireState == FireState.Big) return;
            Debug.Log("Flame is big");

            fireState = FireState.Big;
            fire.transform.localScale = new Vector3(1, 1, 1);
            // set Light
        }
    }
}