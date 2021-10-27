using UnityEngine;


public sealed class SetChildrensPositionRandomly : MonoBehaviour
{

    [SerializeField] private Vector2 randomPositionArea = Vector2.zero;


    private void Awake()
    {
        this.Initialize();
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(this.transform.position, this.randomPositionArea.x);

        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(this.transform.position, this.randomPositionArea.y);
    }

    public void SetRandomPosition()
    {
        for (int i = 0; i < this.transform.childCount; i++)
        {
            Vector2 newPosition = this.RandomPositionInCircle(this.transform.position, this.randomPositionArea.x, this.randomPositionArea.y);
            this.transform.GetChild(i).gameObject.SetActive(true);
            this.transform.GetChild(i).position = newPosition;
        }
    }

    private Vector2 RandomPositionInCircle(Vector2 origin, float minRadius, float maxRadius)
    {
        var randomDirection = (Random.insideUnitCircle * origin).normalized;
        var randomDistance = Random.Range(minRadius, maxRadius);
        var point = origin + randomDirection * randomDistance;

        return point;
    }

    public void Initialize()
    {
        for (int i = 0; i < this.transform.childCount; i++)
            this.transform.GetChild(i).gameObject.SetActive(false);
    }
}