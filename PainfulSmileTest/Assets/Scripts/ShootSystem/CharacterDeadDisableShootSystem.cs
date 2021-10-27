using UnityEngine;
using Characters;
using ShootManager;


[RequireComponent(typeof(ShootModeBase))]
public sealed class CharacterDeadDisableShootSystem : MonoBehaviour
{
    
    [SerializeField] private CharacterBase characterBase = null;
    private ShootModeBase shootModeBase = null;


    private void Awake()
    {
        this.Initialize();
    }

    private void OnEnable()
    {
        this.EnableShootSystem();
        this.characterBase.OnCharacterDead += this.DisableShootSystem;     
    }

    private void OnDisable()
    {
        this.characterBase.OnCharacterDead -= this.DisableShootSystem;
    }

    private void DisableShootSystem()
    {
        this.shootModeBase.enabled = false;
    }

    private void EnableShootSystem()
    {
        this.shootModeBase.enabled = true;
    }

    private void Initialize()
    {
        this.shootModeBase = this.GetComponent<ShootModeBase>();
    }
}