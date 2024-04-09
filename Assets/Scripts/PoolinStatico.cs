using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolinStatico : MonoBehaviour
{
    public GameObject obstaculoPrefab;
    public int poolSize = 10;

    private List<GameObject> obstaculosPool = new List<GameObject>();

    void Start()
    {
        for (int i = 0; i < poolSize; i++)
        {
            GameObject obstaculo = Instantiate(obstaculoPrefab);
            obstaculo.SetActive(false);
            obstaculosPool.Add(obstaculo);
        }
    }

    public GameObject GetObstaculoFromPool()
    {
        foreach (GameObject obstaculo in obstaculosPool)
        {
            if (!obstaculo.activeInHierarchy)
            {
                obstaculo.SetActive(true);
                return obstaculo;
            }
        }
        return null;
    }
}
