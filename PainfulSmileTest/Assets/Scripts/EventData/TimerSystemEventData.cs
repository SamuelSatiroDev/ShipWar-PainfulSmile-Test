using UnityEngine;


[CreateAssetMenu(fileName = "TimerSystemEventData", menuName = "Event Data/ Timer System Event")]
public sealed class TimerSystemEventData : ScriptableObject
{

    public delegate void EventHandler();
    public event EventHandler OnTimerOver;

    public delegate void EventTimerCountHandler(string Timer);
    public event EventTimerCountHandler OnTimerCount;

    public delegate void EventTimerValueHandler(float Value);
    public event EventTimerValueHandler OnSetMinutesOfTime;
    public event EventTimerValueHandler OnSetSecondsOfTime;


    public void TimerOverHandler()
    {
        this.OnTimerOver?.Invoke();
    }

    public void TimerCountHandler(string Timer)
    {
        this.OnTimerCount?.Invoke(Timer);
    }

    public void SetMinutesOfTimeHandler(float Minutes)
    {
        this.OnSetMinutesOfTime?.Invoke(Minutes);
    }

    public void SetSecondsOfTimeHandler(float Seconds)
    {
        this.OnSetSecondsOfTime?.Invoke(Seconds);
    }
}