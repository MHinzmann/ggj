using UnityEngine;

public class MapGenerator : MonoBehaviour
{
    [Tooltip("Radius um 0/0 herum, in dem nichts generiert wird")]
    public float clearRadius = 8;

    public int treeDistance = 8;

    public GameObject[] treePrefabs;
    public GameObject logPrefab;

    void Start()
    {
        SpawnTrees();
        SpawnLogs();
    }

    private void SpawnTrees()
    {
      int treeCount = 0;
        for (int i = -5; i < 6; i++)
        {
            for (int j = -5; j < 6; j++)
            {
                var x = Random.Range(i * treeDistance, i * treeDistance + treeDistance);
                var z = Random.Range(j * treeDistance, j * treeDistance + treeDistance);
                if (IsInClearRadius(new Vector2(x, z))) continue;


                var tree = Instantiate(treePrefabs[treeCount%treePrefabs.Length], transform);
                tree.transform.position = new Vector3(x, 0, z);
                treeCount++;
            }
        }
    }

    private void SpawnLogs()
    {
        int logDistance = 16;
        for (int i = -2; i < 3; i++)
        {
            for (int j = -2; j < 3; j++)
            {
                var x = Random.Range(i * logDistance, i * logDistance + logDistance);
                var z = Random.Range(j * logDistance, j * logDistance + logDistance);

                if (IsInClearRadius(new Vector2(x, z))) continue;

                if (Random.Range(0, 2) != 1) continue;

                var log = Instantiate(logPrefab, transform);
                log.transform.position = new Vector3(x, 0, z);
            }
        }
    }

    private bool IsInClearRadius(Vector2 pos)
    {
        return pos.sqrMagnitude <= clearRadius * clearRadius;
    }
}
