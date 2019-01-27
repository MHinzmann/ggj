using UnityEngine;

public class SafeZone : MonoBehaviour
{
    public int safeRadius = 3;

    private bool fireBurntOut;
    
    public bool IsInSafeZone()
    {
        return !fireBurntOut && transform.position.sqrMagnitude < safeRadius * safeRadius;
    }

    public void OnFireBurntOut()
    {
        fireBurntOut = true;
    }
}