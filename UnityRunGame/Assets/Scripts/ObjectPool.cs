using System.Collections.Generic;
using UnityEngine;

public class ObjectPool
{
    private List<GameObject> pool;
    private GameObject prefab;

    public ObjectPool(GameObject prefab, int prewarmSize = 0)
    {
        this.prefab = prefab;
        pool = new List<GameObject>();

        for (int i = 0; i < prewarmSize; i++)
        {
            pool.Add(GameObject.Instantiate(prefab));
            pool[i].SetActive(false);
        }
    }

    public GameObject Get()
    {
        if (pool.Count == 0)
        {
            pool.Add(GameObject.Instantiate(prefab));
        }

        int lastIndex = pool.Count - 1;
        GameObject instance = pool[lastIndex];
        pool.RemoveAt(lastIndex);
        return instance;
    }

    public void Put(GameObject instance)
    {
        instance.SetActive(false);
        pool.Add(instance);
    }
}