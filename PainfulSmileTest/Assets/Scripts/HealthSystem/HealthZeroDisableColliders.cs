using UnityEngine;

public sealed class HealthZeroDisableColliders : MonoBehaviour
{

    [SerializeField] private GameManagerEventData gameManagerEventData = null;
    private Health health = null;


    private void Awake()
    {
        this.Initialize();
    }

    private void OnEnable()
    {
        this.SetStatusCollidersTrue();

        this.gameManagerEventData.OnDefaultValues += this.SetStatusCollidersTrue;
        this.health.OnHealthZero += this.SetStatusCollidersFalse;
    }

    private void OnDisable()
    {
        this.gameManagerEventData.OnDefaultValues -= this.SetStatusCollidersTrue;
        this.health.OnHealthZero -= this.SetStatusCollidersFalse;
    }

    private void SetStatusCollidersTrue()
    {

        Collider2D[] allColliders = this.GetComponents<Collider2D>();
        for (int i = 0; i < allColliders.Length; i++)
        {
            allColliders[i].enabled = true;
        }
    }

    private void SetStatusCollidersFalse()
    {
        Collider2D[] allColliders = this.GetComponents<Collider2D>();
        for (int i = 0; i < allColliders.Length; i++)
        {
            allColliders[i].enabled = false;
        }
    }

    private void Initialize()
    {
        this.health = this.GetComponent<Health>();
    }
}
