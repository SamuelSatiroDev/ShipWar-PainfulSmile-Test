using UnityEngine;

namespace TimerSystem
{
    [RequireComponent(typeof(SpawnObject))]
    public sealed class TimerSystemSpawmEnemy : TimerSystemBase
    {

        private SpawnObject spawnObject = null;


        protected override void Awake()
        {
            base.Awake();
            this.Initialize();
        }

        protected override void OnEnable()
        {
            this.timerSystemEventData.OnTimerOver += this.SpawnEnemys;
            base.OnEnable();
        }

        protected override void OnDisable()
        {
            this.timerSystemEventData.OnTimerOver -= this.SpawnEnemys;
            base.OnDisable();
        }

        private void SpawnEnemys()
        {
            this.spawnObject.SpawnObjectHandler(new Vector3(0, -10, 0), Quaternion.identity);
        }

        public override void Initialize()
        {
            base.Initialize();
            this.spawnObject = this.GetComponent<SpawnObject>();
        }
    }
}