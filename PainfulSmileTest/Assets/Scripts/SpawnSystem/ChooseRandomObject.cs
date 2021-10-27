using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(SpawnObject))]
public class ChooseRandomObject : MonoBehaviour
{

    [SerializeField] List<GameObject> prefabsList = new List<GameObject>();

    private SpawnObject spawnObject = null;
    private GameObject oldPrefab = null;


    private void Awake()
    {
        this.Initialize();
    }

    private void OnEnable()
    {
        this.spawnObject.OnSpawn += this.RandomPrefab;
    }

    private void OnDisable()
    {
        this.spawnObject.OnSpawn -= this.RandomPrefab;
    }

    private void RandomPrefab()
    {
        int newPrefabIndex = Random.Range(0, this.prefabsList.Count);
        this.spawnObject._prefab = this.prefabsList[newPrefabIndex];

        if (this.spawnObject._prefab != this.oldPrefab)
            this.oldPrefab = this.spawnObject._prefab;
        else
        {
            newPrefabIndex = Random.Range(0, this.prefabsList.Count);
            this.spawnObject._prefab = this.prefabsList[newPrefabIndex];
        }
    }

    private void Initialize()
    {
        this.spawnObject = this.GetComponent<SpawnObject>();
    }
}