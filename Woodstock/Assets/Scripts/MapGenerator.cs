using UnityEngine;

public class MapGenerator : MonoBehaviour
{
    public int treeDistance = 8;

    public GameObject treePrefab;
    public GameObject logPrefab;

    void Start()
    {
        SpawnTrees();
        SpawnLogs();
    }

    private void SpawnTrees()
    {
        for (int i = -5; i < 6; i++)
        {
            for (int j = -5; j < 6; j++)
            {
                GameObject tree = Instantiate(treePrefab, transform);
                var x = Random.Range(i * treeDistance, i * treeDistance + treeDistance);
                var z = Random.Range(j * treeDistance, j * treeDistance + treeDistance);
                tree.transform.position = new Vector3(x, 0, z);
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
                GameObject log = Instantiate(logPrefab, transform);

                if (Random.Range(0, 2) == 1)
                {
                    var x = Random.Range(i * logDistance, i * logDistance + logDistance);
                    var z = Random.Range(j * logDistance, j * logDistance + logDistance);
                    log.transform.position = new Vector3(x, 0, z);
                }
            }
        }
    }
}