using UnityEngine;

namespace TimerSystem
{
    public class TimerSystemBase : MonoBehaviour
    {

        public delegate void EventHandler();
        public event EventHandler OnTimerOver;

        [SerializeField] protected GameManagerEventData gameManagerEventData = null;
        [SerializeField] protected TimerSystemEventData timerSystemEventData = null;

        [Space(10)]

        [Range(0, 60)]
        [SerializeField] protected byte minutes = 0;
     
        [Range(0, 60)]
        [SerializeField] protected byte seconds = 0;  

        [SerializeField] protected bool startTimer = false;
        [SerializeField] protected bool resetTimer = false;

        [Space(10)]

        [SerializeField] private float currentTime = 0.0f;

        public TimerSystemEventData _timerSystemEventData { get { return this.timerSystemEventData; } }
        public byte _seconds { get { return this.seconds; } }
        public byte _minutes { get { return this.minutes; } }
        public bool _startTimer { set { this.startTimer = value; } }



        protected virtual void Awake()
        {
            this.Initialize();
        }

        protected virtual void OnEnable()
        {
            if (this.resetTimer)
                this.timerSystemEventData.OnTimerOver += this.Initialize;

            this.gameManagerEventData.OnDefaultValues += this.Initialize;

            this.gameManagerEventData.OnPause += this.SetStartTimer;
            this.timerSystemEventData.OnSetMinutesOfTime += this.SetMinutesOfTime;
            this.timerSystemEventData.OnSetSecondsOfTime += this.SetSecondsOfTime;
        }

        protected virtual void OnDisable()
        {
            if (this.resetTimer)
                this.timerSystemEventData.OnTimerOver -= this.Initialize;

            this.gameManagerEventData.OnDefaultValues -= this.Initialize;

            this.gameManagerEventData.OnPause -= this.SetStartTimer;
            this.timerSystemEventData.OnSetMinutesOfTime -= this.SetMinutesOfTime;
            this.timerSystemEventData.OnSetSecondsOfTime -= this.SetSecondsOfTime;
        }

        private void Update()
        {
            if (this.startTimer)
                this.Stopwatch();
        }

        private void Stopwatch()
        {
            if (this.currentTime <= 0)
                return;

            this.currentTime = this.currentTime > 0 ? this.currentTime -= Time.deltaTime : 0;
            int minutes = Mathf.FloorToInt(this.currentTime / 60F);
            int seconds = Mathf.FloorToInt(this.currentTime - minutes * 60);

            string timer = string.Format("{0:0}:{1:00}", minutes, seconds);


            if (this.currentTime <= 0)
            {
                this.OnTimerOver?.Invoke();
                this.timerSystemEventData.TimerOverHandler();

                timer = string.Format("{0:0}:{1:00}", 0, 0);
            }

            this.timerSystemEventData.TimerCountHandler(timer);
        }

        private void SetMinutesOfTime(float Minutes)
        {
            this.minutes = (byte)Minutes;
        }

        private void SetSecondsOfTime(float Seconds)
        {
            this.seconds = (byte)Seconds;
        }

        protected void SetStartTimer(bool SetStartTimer)
        {
            this.startTimer = !SetStartTimer;
        }

        public virtual void Initialize()
        {
            this.currentTime = (this.minutes * 60) + this.seconds;
        }
    }
}