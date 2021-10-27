using UnityEngine;


namespace Characters
{
    [RequireComponent(typeof(SpriteRenderer))]
    public class CharacterBase : MonoBehaviour
    {

        public delegate void EventHandler();
        public event EventHandler OnCharacterDead;

        [SerializeField] protected GameManagerEventData gameManagerEventData = null;
        [SerializeField] protected float speedMove = 0.0f;
        [SerializeField] protected float speedRotate = 0.0f;

        protected bool stopAction = false;
        protected string bulletTag = string.Empty;
        protected LifeState lifeState = null;
        private SpawnObject spawnObject = null;


        protected virtual void Awake()
        {
            this.Initialize();
        }

        protected virtual void OnEnable()
        {
            if (this.lifeState._health)
                this.lifeState._health.OnHealthZero += this.DestroyCharacterHandler;

            this.gameManagerEventData.OnDefaultValues += this.Initialize;
            this.gameManagerEventData.OnPause += this.EnableActionStatus;

            this.Initialize();
        }

        protected virtual void OnDisable()
        {
            if (this.lifeState._health)
                this.lifeState._health.OnHealthZero -= this.DestroyCharacterHandler;

            this.gameManagerEventData.OnDefaultValues -= this.Initialize;
            this.gameManagerEventData.OnPause -= this.EnableActionStatus;
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (this.stopAction)
                return;

            if (collision.CompareTag(this.bulletTag))
            {
                this.TakeDamage(collision.transform);

                if(collision.GetComponent<Bullet>())
                    collision.gameObject.SetActive(false);
            }
        }

        private void TakeDamage(Transform ExplosionSpawn)
        {
            this.lifeState?.SetHealth(-1);
            this.spawnObject?.SpawnObjectHandler(this.transform.position, this.transform.rotation);
        }

        private void DestroyCharacterHandler()
        {
            this.stopAction = true;
            this.OnCharacterDead?.Invoke();
        }

        private void EnableActionStatus(bool state)
        {
            this.stopAction = state;
        }

        private void Initialize()
        {
            if (this.TryGetComponent(out this.lifeState))
                this.lifeState = this.GetComponent<LifeState>();

            if (this.TryGetComponent(out this.spawnObject))
                this.spawnObject = this.GetComponent<SpawnObject>();

            this.stopAction = false;
            this.lifeState.Initialize();
            this.lifeState._health.Initialize();
        }
    }
}