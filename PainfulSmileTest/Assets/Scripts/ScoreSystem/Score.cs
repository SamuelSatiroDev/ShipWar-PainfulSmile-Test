using UnityEngine;


[RequireComponent(typeof(ScoreUI))]
public sealed class Score : MonoBehaviour
{

    [SerializeField] private GameManagerEventData gameManagerEventData = null;
    [SerializeField] private int scoreCount = 0;
    private ScoreUI scoreUI = null;


    private void Awake()
    {
        this.Initialize();
    }

    private void OnEnable()
    {
        this.gameManagerEventData.OnDefaultValues += this.Initialize;
        this.gameManagerEventData.OnScoreCount += this.IncreaseScore;      
    }

    private void OnDisable()
    {
        this.gameManagerEventData.OnDefaultValues -= this.Initialize;
        this.gameManagerEventData.OnScoreCount -= this.IncreaseScore;
    }

    public void IncreaseScore(int Value)
    {
        this.scoreCount += Value;
        this.scoreUI.SetValueScoreText(this.scoreCount);
    }

    private void Initialize()
    {
        this.scoreCount = 0;
        this.scoreUI = this.GetComponent<ScoreUI>();
        this.scoreUI.Initialize();
    }
}