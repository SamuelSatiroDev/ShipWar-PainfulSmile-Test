using UnityEngine;

public sealed class PauseGame : MonoBehaviour
{

    [SerializeField] private GameManagerEventData gameManagerEventData = null;


    private void Start()
    {
        this.Initialize();
    }

    public void Pause(bool Pause)
    {
        if(Pause)
            this.gameManagerEventData.PauseTrueHandler();
        else
            this.gameManagerEventData.PauseFalseHandler();
    }

    private void Initialize()
    {
        this.gameManagerEventData.PauseTrueHandler();
    }
}