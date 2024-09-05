using UnityEngine;
using System.Collections.Generic;

public class CannonballPooler : MonoBehaviour
{
    public static CannonballPooler instance;
    private List<GameObject> cannonballPool;

    private GameObject cannonballPrefab => VariableManager.instance.cannonballPrefab;
    private int poolSize => VariableManager.instance.poolSize;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        cannonballPool = new List<GameObject>();

        for (int i = 0; i < poolSize; i++)
        {
            GameObject cannonball = Instantiate(cannonballPrefab);
            cannonball.SetActive(false);
            cannonballPool.Add(cannonball);
        }
    }

    public GameObject GetPooledObject()
    {
        foreach (GameObject cannonball in cannonballPool)
        {
            if (!cannonball.activeInHierarchy)
            {
                return cannonball;
            }
        }
        return null;
    }

    public void ReturnToPool(GameObject cannonball)
    {
        cannonball.SetActive(false);
    }
}