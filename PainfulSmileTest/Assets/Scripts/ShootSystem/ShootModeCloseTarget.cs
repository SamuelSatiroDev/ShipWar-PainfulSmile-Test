using UnityEngine;


namespace ShootManager
{
    public sealed class ShootModeCloseTarget : ShootModeBase
    {

        [SerializeField] private float minDistanceTarget = 0.0f;
        [SerializeField] private Transform target = null;
        public Transform _target { set { this.target = value; } }


        private void Update()
        {
            float distance = Vector2.Distance(this.transform.position, this.target.position);
            if (distance <= this.minDistanceTarget)
                this.OnShootHandler();
        }
    }
}