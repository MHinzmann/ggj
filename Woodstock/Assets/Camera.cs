using UnityEngine;

public class Camera : MonoBehaviour
{
    public GameObject target;

    private Vector3 _initialPosition;

    private void Awake()
    {
        _initialPosition = transform.position;
    }

    void FixedUpdate()
    {
        FollowTarget();
    }

    private void FollowTarget()
    {
        float interpolation = 2f * Time.deltaTime;

        var targetPosition = target.transform.position;
        var currentFocusPosition = transform.position - _initialPosition;
        var pos = new Vector3
        {
            x = Mathf.Lerp(currentFocusPosition.x, targetPosition.x, interpolation),
            z = Mathf.Lerp(currentFocusPosition.z, targetPosition.z, interpolation)
        };

        transform.position = pos + _initialPosition;
    }
}