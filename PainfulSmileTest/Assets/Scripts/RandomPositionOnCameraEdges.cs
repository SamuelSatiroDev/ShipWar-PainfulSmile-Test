using UnityEngine;
using ExtensionMethods;


public sealed class RandomPositionOnCameraEdges : MonoBehaviour
{

    public delegate void EventHandler();
    public event EventHandler OnRandomPositionOnCameraEdges;

    [Tooltip("X = LEFT, Y = RIGHT, Z = UP, W = DOWN")]
    [SerializeField] private Vector4 offsetSize = Vector4.zero;


    private void Start()
    {
        this.Initialize();
    }

    private void OnEnable()
    {
        this.Initialize();
    }

    private void RandomPositionOnCameraEdgesHandler()
    {
        int enumScreenEdgeLength = System.Enum.GetValues(typeof(EnumManager.ScreenEdge)).Length;
        int random = Random.Range(0, enumScreenEdgeLength);

        this.transform.RandomPositionOnCameraEdges(this.offsetSize, (EnumManager.ScreenEdge)random);

        this.OnRandomPositionOnCameraEdges?.Invoke();
    }

    private void Initialize()
    {
        this.transform.rotation = Quaternion.identity;
        this.RandomPositionOnCameraEdgesHandler();
    }
}