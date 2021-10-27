using UnityEngine;


namespace ShootManager
{
    public sealed class ShootModeInput : ShootModeBase
    {

        [SerializeField]
        private KeyCode shootInput = KeyCode.None;


        private void Update()
        {
            if (Input.GetKeyDown(this.shootInput))
                this.OnShootHandler();
        }
    }
}