using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneObjectsSpawner : MonoBehaviour
{
    [SerializeField]
    private List<Transform> fishSpawnPoints;
    
    [SerializeField]
    private List<Transform> minesSpawnPoints;
    
    [SerializeField]
    private List<Transform> coinsSpawnPoints;

    [SerializeField]
    private int fishesToSpawn;
    
    [SerializeField]
    private int minesToSpawn;
    
    [SerializeField]
    private int coinsToSpawn;
    
    void Start()
    {
        SpawnObjects();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void SpawnObjects()
    {
        SpawnObjectsInSpawnPoints(fishesToSpawn, fishSpawnPoints, "Fish");
        SpawnObjectsInSpawnPoints(minesToSpawn, minesSpawnPoints, "Mine");
        SpawnObjectsInSpawnPoints(coinsToSpawn, coinsSpawnPoints, "Coin");
    }

    public void SpawnObjectsInSpawnPoints(int numberToSpawn, List<Transform> spawnPoints,string tag)
    {
        List<int> listNumbersToSpawn = new List<int>();
        int num;

        if (spawnPoints.Count - 1 < numberToSpawn)
        {
            Debug.LogWarning($"{tag} trying spawn more than is spawn points");
            
            return;
        }
        
        while (listNumbersToSpawn.Count != numberToSpawn)
        {
            num = Random.Range(0, spawnPoints.Count - 1);
            
            if (!listNumbersToSpawn.Contains(num))
            {
                listNumbersToSpawn.Add(num);
            }
        }

        Transform tran;
        
        foreach (int number in listNumbersToSpawn)
        {
            tran = spawnPoints[number];
            ObjectPooler.Instance.SpawnFromPool(tag, tran.position, tran.rotation);
        }
    }
}
