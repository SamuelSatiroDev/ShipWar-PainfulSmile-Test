using System.Collections.Generic;
using UnityEngine;
using ExtensionMethods;


public sealed class SpawnObject : MonoBehaviour
{

    public delegate void EventHandler();
    public event EventHandler OnSpawn;

    [SerializeField] private GameManagerEventData gameManagerEventData = null;

    [Header("GAME OBJECT")]

    [SerializeField] private GameObject prefab = null;
    public GameObject _prefab { get { return this.prefab; } set { this.prefab = value; }  }

    [Header("POOLING SETTINGS")]

    [SerializeField] private string contentName = "Content";
    [SerializeField] private byte poolingLimit = 10;
    [SerializeField] private bool startInstantiated = false;

    private Transform objectContent = null;
    private List<GameObject> generatedObjectList = new List<GameObject>();


    private void Awake()
    {
        this.Initialize();
    }

    private void OnEnable()
    {
        this.gameManagerEventData.OnDefaultValues += this.Initialize;
    }

    private void OnDisable()
    {
        this.gameManagerEventData.OnDefaultValues -= this.Initialize;
    }

    public void SpawnObjectHandler(Vector3 SpawnPosition, Quaternion ObjectSpawnRotation)
    {
        this.OnSpawn?.Invoke();
        this.generatedObjectList.Pooling(this.prefab, this.objectContent, SpawnPosition, ObjectSpawnRotation, this.startInstantiated, this.poolingLimit);    
    }

    private void CreateContent()
    {
        GameObject newGContent = null;

        if (GameObject.Find(this.contentName) != null)
            newGContent = GameObject.Find(this.contentName);

        if (newGContent == null)
        {
            newGContent = new GameObject();
            newGContent.name = this.contentName;    
        }

        this.objectContent = newGContent.transform;
    }

    private void Initialize()
    {
        this.CreateContent();

        for (int i = 0; i < this.generatedObjectList.Count; i++)
            this.generatedObjectList[i].SetActive(false);
    }
}