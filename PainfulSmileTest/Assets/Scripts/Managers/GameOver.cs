using UnityEngine;

public sealed class GameOver : MonoBehaviour
{

    [SerializeField] private GameObject gameOverMenu = null;
    [SerializeField] private GameManagerEventData gameManagerEventData = null;


    private void OnEnable()
    {
        this.gameManagerEventData.OnGameOver += this.SetActiveGameOverMenu;
    }

    private void OnDisable()
    {
        this.gameManagerEventData.OnGameOver -= this.SetActiveGameOverMenu;
    }

    private void SetActiveGameOverMenu(bool Status)
    {
        this.gameOverMenu.gameObject.SetActive(Status);
    }
}