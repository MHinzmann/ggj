using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GhostSpawner : MonoBehaviour
{
    public UnityEvent onPlayerCaught = new UnityEvent();

    public GameObject ghostPrefab;

    public void SpawnFireOutGhosts()
    {
        SpawnGhost();
    }
    
    public void SpawnGhost()
    {
        var ghost = Instantiate(ghostPrefab, new Vector3(), Quaternion.identity);
        ghost.GetComponent<Ghost>().onPlayerCaught = onPlayerCaught;
    }
}
