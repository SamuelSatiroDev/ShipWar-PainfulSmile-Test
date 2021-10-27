using UnityEngine;


namespace ShootManager
{
    [RequireComponent(typeof(SpawnObject))]
    public class ShootModeBase : MonoBehaviour
    {

        public delegate void EventHandler();
        public event EventHandler OnShoot;

        [SerializeField] private GameManagerEventData gameManagerEventData = null;
        [SerializeField] private bool canShoot = false;


        private void Awake()
        {
            this.canShoot = true;
        }

        private void OnEnable()
        {
            this.gameManagerEventData.OnPause += this.SetCanShoot;
        }

        private void OnDisable()
        {
            this.gameManagerEventData.OnPause -= this.SetCanShoot;
        }

        public void OnShootHandler()
        {
            if (this.canShoot)
                this.OnShoot?.Invoke();
        }

        public void SetCanShoot(bool Set)
        {
            this.canShoot = !Set;
        }
    }
}