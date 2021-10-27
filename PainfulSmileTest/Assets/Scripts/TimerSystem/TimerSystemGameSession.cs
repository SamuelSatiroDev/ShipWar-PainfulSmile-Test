namespace TimerSystem
{
    public sealed class TimerSystemGameSession : TimerSystemBase
    {

        protected override void OnEnable()
        {
            base.OnEnable();
            timerSystemEventData.OnTimerOver += this.SetGameOverTrue;
        }

        protected override void OnDisable()
        {
            base.OnDisable();
            timerSystemEventData.OnTimerOver -= this.SetGameOverTrue;

        }

        private void SetGameOverTrue()
        {
            this.gameManagerEventData.GameOverHandler(true);
        }
    }
}