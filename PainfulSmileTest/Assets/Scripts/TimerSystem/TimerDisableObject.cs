namespace TimerSystem
{
    public sealed class TimerDisableObject : TimerSystemBase
    {

        protected override void OnEnable()
        {
            base.OnEnable();
            this.OnTimerOver += this.DisableObject;
            this.startTimer = false;
        }

        protected override void OnDisable()
        {
            base.OnDisable();
            this.OnTimerOver -= this.DisableObject;
        }

        private void DisableObject()
        {
            this.SetStartTimer(false);
            this.gameObject.SetActive(false);
        }
    }
}