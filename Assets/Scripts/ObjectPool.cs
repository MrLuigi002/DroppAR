using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    public static ObjectPool SharedInstance;
    public List<GameObject> pooledCannons;
    public GameObject cannonToPool;
    public int amountCannonsToPool;

    public List<GameObject> pooledCoins;
    public GameObject coinToPool;
    public int amountCoinsToPool;

    [SerializeField] private Transform ballParent;

    private void Awake()
    {
        SharedInstance = this;
    }

    private void Start()
    {
        pooledCannons = new List<GameObject>();
        GameObject tmp1;
        for (int i = 0; i < amountCannonsToPool; i++)
        {
            tmp1 = Instantiate(cannonToPool, ballParent);
            tmp1.SetActive(false);
            pooledCannons.Add(tmp1);
        }

        pooledCoins = new List<GameObject>();
        GameObject tmp2;
        for (int i = 0; i < amountCoinsToPool; i++)
        {
            tmp2 = Instantiate(coinToPool, ballParent);
            tmp2.SetActive(false);
            pooledCoins.Add(tmp2);
        }
    }

    public GameObject GetPooledCannon()
    {
        for (int i = 0; i < amountCannonsToPool; i++)
        {
            if (!pooledCannons[i].activeInHierarchy)
            {
                return pooledCannons[i];
            }
        }

        return null;
    }

    public GameObject GetPooledCoin()
    {
        for (int i = 0; i < amountCoinsToPool; i++)
        {
            if (!pooledCoins[i].activeInHierarchy)
            {
                return pooledCoins[i];
            }
        }

        return null;
    }
}
