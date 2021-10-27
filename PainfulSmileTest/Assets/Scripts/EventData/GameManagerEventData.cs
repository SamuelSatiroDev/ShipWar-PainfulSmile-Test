using UnityEngine;


[CreateAssetMenu(fileName = "GameManagerEventData", menuName = "Event Data/ Game Manager Event")]
public sealed class GameManagerEventData : ScriptableObject
{

    public delegate void PauseEventHandler(bool Status);
    public event PauseEventHandler OnPause;

    public delegate void EventHandler();
    public event EventHandler OnDefaultValues;

    public event EventHandler OnPlayerDead;


    public delegate void ScoreHandler(int Score);
    public event ScoreHandler OnScoreCount;

    public delegate void GameOverEventHandler(bool Status);
    public event GameOverEventHandler OnGameOver;


    public void PauseTrueHandler()
    {
        this.OnPause?.Invoke(true);
    }

    public void PauseFalseHandler()
    {
        this.OnPause?.Invoke(false);
    }

    public void SetDefaultValuesHandler()
    {
        this.GameOverHandler(false);
        this.PauseFalseHandler();
        this.OnDefaultValues?.Invoke();
    }

    public void PlayerDeadHandler()
    {
        this.PauseTrueHandler();
        this.GameOverHandler(true);

        this.OnPlayerDead?.Invoke();
    }

    public void ScoreCountHandler(int Score)
    {
        this.OnScoreCount?.Invoke(Score);
    }

    public void GameOverHandler(bool Status)
    {
        this.OnGameOver?.Invoke(Status);
        this.OnPause?.Invoke(Status);
    }
}