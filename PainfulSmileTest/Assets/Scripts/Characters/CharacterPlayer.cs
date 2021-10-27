using UnityEngine;
using ExtensionMethods;


namespace Characters
{
    [RequireComponent(typeof(CharacterPlayerInputs))]
    public sealed class CharacterPlayer : CharacterBase
    {

        private CharacterPlayerInputs characterPlayerInputs = null;
        public static Transform playerTransform = null;
        private Vector3 initialPosition = Vector3.zero;
        private Quaternion initialRotation = Quaternion.identity;
       

        protected override void Awake()
        {
            base.Awake();

            this.InitializeGetTransformValues();
            this.Initialize();       
        }

        private void Start()
        {
            this.bulletTag = TagManager.BulletEnemyTag;
        }

        private void Update()
        {
            if (this.stopAction)
                return;

            this.MoveForward();
            this.transform.KeepOnCamera();
        }

        protected override void OnEnable()
        {
            base.OnEnable();

            this.lifeState._health.OnHealthZero += this.gameManagerEventData.PlayerDeadHandler;
            this.gameManagerEventData.OnDefaultValues += this.Initialize;
            this.characterPlayerInputs.OnTurnLeft += this.Rotate;
            this.characterPlayerInputs.OnTurnRight += this.Rotate;
        }

        protected override void OnDisable()
        {
            base.OnDisable();

            this.lifeState._health.OnHealthZero -= this.gameManagerEventData.PlayerDeadHandler;
            this.gameManagerEventData.OnDefaultValues -= this.Initialize;
            this.characterPlayerInputs.OnTurnLeft -= this.Rotate;
            this.characterPlayerInputs.OnTurnRight -= this.Rotate;
        }

        private void MoveForward()
        {
            this.transform.position += this.transform.up * this.speedMove * Time.deltaTime;
        }

        private void Rotate(sbyte Direction)
        {
            if (this.stopAction)
                return;

            float speed = Direction * this.speedRotate * Time.deltaTime;
            this.transform.Rotate(-Vector3.forward * speed);
        }

        private void InitializeGetTransformValues()
        {
            this.initialPosition = this.transform.position;
            this.initialRotation = this.transform.rotation;
        }

        private void Initialize()
        {
            playerTransform = this.transform;
            this.characterPlayerInputs = this.GetComponent<CharacterPlayerInputs>();

            this.transform.position = this.initialPosition;
            this.transform.rotation = this.initialRotation;
        }
    }
}