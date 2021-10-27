using UnityEngine;
using UnityEngine.AI;
using ShootManager;
using ExtensionMethods;


namespace Characters
{
    [RequireComponent(typeof(NavMeshAgent))]
    public sealed class CharacterEnemy : CharacterBase
    {

        [SerializeField] private float minDistancePlayer = 0;
        private NavMeshAgent navMeshAgent = null;


        protected override void Awake()
        {
            base.Awake();          
        }

        private void Start()
        {
            this.bulletTag = TagManager.BulletPlayerTag;
            this.Initialize();
        }

        private void Update()
        {
            this.navMeshAgent.isStopped = this.stopAction;

            if (this.stopAction)
                return;

            this.navMeshAgent.SetDestination(CharacterPlayer.playerTransform.position);
            this.transform.LookAt2D(CharacterPlayer.playerTransform, EnumManager.Direction.Up);
        }

        private void InitializeAgent()
        {
            this.navMeshAgent = this.GetComponent<NavMeshAgent>();

            this.navMeshAgent.updateRotation = false;
            this.navMeshAgent.updateUpAxis = false;

            this.navMeshAgent.speed = this.speedMove;
            this.navMeshAgent.angularSpeed = this.speedRotate;
            this.navMeshAgent.stoppingDistance = this.minDistancePlayer;
        }

        private void Initialize()
        {
            this.InitializeAgent();

            ShootModeCloseTarget[] shootModeCloseTargetAllChildren = this.GetComponentsInChildren<ShootModeCloseTarget>();
            for (int i = 0; i < shootModeCloseTargetAllChildren.Length; i++)
                shootModeCloseTargetAllChildren[i]._target = CharacterPlayer.playerTransform;
        }
    }
}