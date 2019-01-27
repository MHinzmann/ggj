using UnityEngine;
using UnityEngine.Events;

public class GhostSpawner : MonoBehaviour
{
    public UnityEvent onPlayerCaught = new UnityEvent();

    public GameObject haunted;
    public GameObject ghostPrefab;

    public int spawnDistance = 10;

    private void Start()
    {
        SpawnGhost();
    }

    public void SpawnFireOutGhosts()
    {
        SpawnGhost().speed = 4;
        SpawnGhost().speed = 4;
        SpawnGhost().speed = 4;
    }

    public Ghost SpawnGhost()
    {
        var x = Random.Range(-1f, 1f);
        var z = Random.Range(-1f, 1f);
        var randomDirection = new Vector3(x, 0, z).normalized;
        var spawnPoint = haunted.transform.position + (randomDirection * spawnDistance);
        Debug.Log("Spawn Ghost at " + spawnPoint);

        var ghost = Instantiate(ghostPrefab, spawnPoint, Quaternion.identity);
        var ghostComp = ghost.GetComponent<Ghost>();
        ghostComp.onPlayerCaught = onPlayerCaught;
        return ghostComp;
    }
}