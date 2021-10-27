using UnityEngine;


public sealed class SetDefaultGameValues : MonoBehaviour
{

    [SerializeField] private GameManagerEventData gameManagerEventData = null;

    public void SetDefaultGame()
    {
        this.gameManagerEventData.SetDefaultValuesHandler();
    }
}