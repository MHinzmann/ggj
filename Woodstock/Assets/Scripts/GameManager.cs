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

    public AudioSource gameOverSound;

    private bool _playerCaught;
    private float lastScoreTime = 0;

    public void FireBurntOut()
    {
        if (HouseOutOfSight())
        {
            house.SetActive(false);
        }
    }

    private void Update()
    {
        if (_playerCaught && !gameOverSound.isPlaying)
        {
            SceneManager.LoadScene("StoryEnd");
        }
    }

    public void OnPlayerCaughtByGhost()
    {
        if (_playerCaught)
            return;

        character.GetComponent<PlayerMovement>().Immobilize();
        _playerCaught = true;
        gameOverSound.Play();
    }

    private bool HouseOutOfSight()
    {
        var distanceToHouse = (house.transform.position - character.transform.position).magnitude;
        return distanceToHouse > disappearDistance;
    }

    public void FixedUpdate()
    {
        //check for required score addition
        if (Time.fixedTime - lastScoreTime >= scoreEvery)
        {
            lastScoreTime = Time.fixedTime;
            AddScore(scorePerTime);
        }
    }

    public void AddScore(int s)
    {
        score += s;
        GameObject.Find("ScoreHolder").GetComponent<ScoreHolder>().score = score;
    }

    public int GetScore() {
      return score;
    }
}
