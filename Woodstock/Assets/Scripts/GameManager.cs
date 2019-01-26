using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [Tooltip("The distance to the player in that the house won't disappear when the fire burns out")]
    public int disappearDistance = 16;
    
    public GameObject house;
    public GameObject character;
    
    public void FireBurntOut()
    {
        if (HouseOutOfSight())
        {
            house.SetActive(false);
        }

        // SceneManager.LoadScene("End");
    }

    private bool HouseOutOfSight()
    {
        var distanceToHouse = (house.transform.position - character.transform.position).magnitude;
        return distanceToHouse > disappearDistance;
    }
}