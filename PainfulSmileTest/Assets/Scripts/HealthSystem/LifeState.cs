using UnityEngine;


[RequireComponent(typeof(Health))]
[RequireComponent(typeof(ChangeSpriteDescendingOrder))]
public sealed class LifeState : MonoBehaviour
{

    [SerializeField] private GameManagerEventData gameManagerEventData = null;
    private ChangeSpriteDescendingOrder changeSpriteDescendingOrder = null;
    private Health health = null;

    public Health _health { get { return this.health; } }
   

    private void Awake()
    {
        this.Initialize();
    }

    private void OnEnable()
    {
        this.gameManagerEventData.OnDefaultValues += this.Initialize;

        this.health.OnHealthZero += this.SetObjectState;
        this.health.OnHealthIncrease += this.SetObjectState;
        this.health.OnHealthDecrease += this.SetObjectState;
        
    }

    private void OnDisable()
    {
        this.gameManagerEventData.OnDefaultValues -= this.Initialize;

        this.health.OnHealthZero -= this.SetObjectState;
        this.health.OnHealthIncrease -= this.SetObjectState;
        this.health.OnHealthDecrease -= this.SetObjectState;
    }

    public void SetHealth(int SetHealth)
    {
        this.health.SetHealth(SetHealth);
    }

    private void SetObjectState()
    {
        if(this.health._healthCurrent >= 0)
            this.changeSpriteDescendingOrder.SetState(this.health._healthCurrent);
    }

    public void Initialize()
    {
        this.health = this.GetComponent<Health>();
        this.changeSpriteDescendingOrder = this.GetComponent<ChangeSpriteDescendingOrder>();

        this.health._healthMaximum = this.changeSpriteDescendingOrder._states.Count - 1;
        this.health.Initialize();
    }
}