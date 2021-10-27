using UnityEngine;
using TMPro;
using UnityEngine.UI;
using TimerSystem;


public sealed class TimerSystemUI : MonoBehaviour
{
    [SerializeField] private TMP_Text timerText = null;
    [SerializeField] private Slider minutesSlider = null;
    [SerializeField] private Slider secondsSlider = null;

    [SerializeField] private TimerSystemBase timerSystemBase = null;


    private void Awake()
    {
        this.Initialize();
    }

    private void OnEnable()
    {
        this.timerSystemBase._timerSystemEventData.OnTimerCount += this.SetValueSessionDurationText;
    }

    private void OnDisable()
    {
        this.timerSystemBase._timerSystemEventData.OnTimerCount -= this.SetValueSessionDurationText;
    }

    private void SetValueSessionDurationText(string Timer)
    {
        if(this.timerText)
            this.timerText.text = Timer;
    }

    private void Initialize()
    {
        if (this.minutesSlider)
        {
            this.minutesSlider.value = this.timerSystemBase._minutes;
            this.minutesSlider.onValueChanged.AddListener(this.timerSystemBase._timerSystemEventData.SetMinutesOfTimeHandler);
        }

        if (this.secondsSlider)
        {
            this.secondsSlider.value = this.timerSystemBase._seconds;
            this.secondsSlider.onValueChanged.AddListener(this.timerSystemBase._timerSystemEventData.SetSecondsOfTimeHandler);
        }
    }
}