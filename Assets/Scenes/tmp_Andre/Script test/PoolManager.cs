using System.Collections.Generic;
using UnityEngine;

public class PoolManager : MonoBehaviour
{
    public GameObject cannonballPrefab;
    public int maxPoolSize = 7;
    private List<GameObject> cannonballPool = new List<GameObject>();

    void Start()
    {
        CreatePool();
    }

    void CreatePool()
    {
        for (int i = 0; i < maxPoolSize; i++)
        {
            GameObject cannonball = Instantiate(cannonballPrefab, Vector3.zero, Quaternion.identity);
            cannonball.SetActive(false);
            cannonballPool.Add(cannonball);
        }
    }

    public GameObject GetPooledCannonball()
    {
        for (int i = 0; i < cannonballPool.Count; i++)
        {
            if (!cannonballPool[i].activeInHierarchy)
            {
                return cannonballPool[i];
            }
        }
        return null;
    }

    public void ResetPool()
    {
        foreach (GameObject cannonball in cannonballPool)
        {
            cannonball.SetActive(false);
        }
    }

    void Update()
    {
        bool allActive = true;
        foreach (var cannonball in cannonballPool)
        {
            if (!cannonball.activeInHierarchy)
            {
                allActive = false;
                break;
            }
        }

        if (allActive)
        {
            ResetPool();
        }
    }
}
