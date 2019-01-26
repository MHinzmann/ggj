using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private int score = 0;

    [Tooltip("The distance to the player in that the house won't disappear when the fire burns out")]
    public int disappearDistance = 16;
    public int scorePerTime = 13;
    public int scoreEvery = 3;

    public GameObject house;
    public GameObject character;

    private float lastScoreTime = 0;

    public void FireBurntOut()
    {
        if (HouseOutOfSight())
        {
            house.SetActive(false);
        }
        // SceneManager.LoadScene("End");
    }

    public void OnPlayerCaughtByGhost()
    {
        SceneManager.LoadScene("End");
    }

    private bool HouseOutOfSight()
    {
        var distanceToHouse = (house.transform.position - character.transform.position).magnitude;
        return distanceToHouse > disappearDistance;
    }

    public void FixedUpdate() {
      Debug.Log(score);
      //check for required score addition
      if(Time.fixedTime - lastScoreTime >= scoreEvery) {
        lastScoreTime = Time.fixedTime;
        AddScore(scorePerTime);
      }
    }

    public void AddScore(int s) {
      score+=s;
    }
}
