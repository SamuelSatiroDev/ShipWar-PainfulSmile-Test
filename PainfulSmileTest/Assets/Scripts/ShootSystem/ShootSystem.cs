using System.Collections;
using UnityEngine;


namespace ShootManager
{
    public sealed class ShootSystem : MonoBehaviour
    {

        [SerializeField] private float fireRate = 0.0f;

        private bool canShoot = true;
        private ShootModeBase shootModeBase = null;
        private SpawnObject spawnObject = null;


        private void Awake()
        {
            this.Initialize();
        }

        private void OnEnable()
        {
            this.shootModeBase.OnShoot += this.Fire;
        }

        private void OnDisable()
        {
            this.shootModeBase.OnShoot -= this.Fire;
        }

        private void OnDrawGizmos()
        {
            Gizmos.color = Color.blue;
            Gizmos.DrawSphere(this.transform.position, 0.1f);
            Gizmos.DrawLine(this.transform.position, this.transform.up * 0.5f + this.transform.position);
        }

        private void Fire()
        {
            if (!this.canShoot)
                return;

            this.spawnObject?.SpawnObjectHandler(this.transform.position, this.transform.rotation);
            StartCoroutine(this.FireRate());
        }

        private IEnumerator FireRate()
        {
            this.canShoot = false;
            yield return new WaitForSeconds(this.fireRate);
            this.canShoot = true;
        }

        private void Initialize()
        {
            this.shootModeBase = this.GetComponentInParent<ShootModeBase>();
            this.spawnObject = this.GetComponentInParent<SpawnObject>();
        }
    }
}