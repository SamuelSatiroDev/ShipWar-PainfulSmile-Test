using UnityEngine;


[RequireComponent(typeof(Health))]
public sealed class IncreaseScoreWhenLifeZero : MonoBehaviour
{

    [SerializeField] private GameManagerEventData gameManagerEventData = null;
    private Health health = null;
    

    private void Awake()
    {
        Initialize();
    }

    private void OnEnable()
    {
        this.health.OnHealthZero += this.IncreaseScore;
    }

    private void OnDisable()
    {
        this.health.OnHealthZero -= this.IncreaseScore;
    }

    private void IncreaseScore()
    {
        this.gameManagerEventData.ScoreCountHandler(1);
    }

    private void Initialize()
    {
        this.health = this.GetComponent<Health>();
    }
}