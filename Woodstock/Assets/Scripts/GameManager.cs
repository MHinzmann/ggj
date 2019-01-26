using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [Tooltip("The distance to the player in that the house won't disappear when the fire burns out")]
    public int disappearDistance = 16;

    public GameObject house;
    public GameObject character;

    public AudioSource gameOverSound;

    private bool _playerCaught;

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
            SceneManager.LoadScene("End");
        }
    }

    public void OnPlayerCaughtByGhost()
    {
        _playerCaught = true;
        gameOverSound.Play();
    }

    private bool HouseOutOfSight()
    {
        var distanceToHouse = (house.transform.position - character.transform.position).magnitude;
        return distanceToHouse > disappearDistance;
    }
}