using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleSpawner : MonoBehaviour
{
    public GameObject prefab;

    public bool spawnAtStart = false;

    // Start is called before the first frame update
    void Start()
    {
        if (spawnAtStart == true)
        {
            GameObject clone = Instantiate(prefab, transform.position, transform.rotation) as GameObject;
            clone.name = prefab.name;
        }
    }

    public void PerformSpawn()
	{
        GameObject clone = Instantiate(prefab, transform.position, transform.rotation) as GameObject;
        clone.name = prefab.name;
    }
}
