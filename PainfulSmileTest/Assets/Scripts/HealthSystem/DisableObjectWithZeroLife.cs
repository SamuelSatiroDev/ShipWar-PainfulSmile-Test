using UnityEngine;
using Characters;
using TimerSystem;


[RequireComponent(typeof(CharacterBase))]
[RequireComponent(typeof(TimerDisableObject))]
[RequireComponent(typeof(Health))]
public sealed class DisableObjectWithZeroLife : MonoBehaviour
{

    private TimerDisableObject timerDisableObject = null;
    private Health health = null;


    private void Awake()
    {
        this.Initialize();
    }

    private void OnEnable()
    {
        this.health.OnHealthZero += this.StartTimerDisable;
    }

    private void OnDisable()
    {
        this.health.OnHealthZero -= this.StartTimerDisable;
    }

    private void StartTimerDisable()
    {
        this.timerDisableObject._startTimer = true;
        this.timerDisableObject.Initialize();
    }

    private void Initialize()
    {
        this.timerDisableObject = this.GetComponent<TimerDisableObject>();
        this.health = this.GetComponent<Health>();
    }
}