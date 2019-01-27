using UnityEngine;
using UnityEngine.Events;

public class Fireplace : MonoBehaviour
{
    public UnityEvent onFireFed = new UnityEvent();

    public UnityEvent onFireBurntOut = new UnityEvent();

    public float initialTimeLeft = 50;
    public float timePerFuelValue = 10;

    public float bigFireValue = 50;

    public float _remainingTime;
    private bool isOut;

    public GameObject fire;

    public Light light;

    private void Awake()
    {
        _remainingTime = initialTimeLeft;
        UpdateFireState();
    }

    public void Feed(IFuel fuel)
    {
        if (_remainingTime <= 0)
            return;

        _remainingTime += timePerFuelValue * fuel.GetFuelValue();
        onFireFed.Invoke();
    }

    private void Update()
    {
        _remainingTime -= Time.deltaTime;

        UpdateFireState();
    }

    private void UpdateFireState()
    {
        if (_remainingTime <= 0 && !isOut)
        {
            Debug.Log("Flame is out");
            isOut = true;

            Destroy(fire);
            light.intensity = 0;

            onFireBurntOut.Invoke();
        }
        else if (_remainingTime > 0)
        {
            var fullSize = new Vector3(0.7f, 1.5f, 1);
            var fireFullness = Mathf.Min(_remainingTime / bigFireValue, 1f);

            fire.transform.localScale = fullSize * fireFullness;
            fire.GetComponent<AudioSource>().volume = fireFullness;
            light.intensity = fireFullness;
        }
    }
}