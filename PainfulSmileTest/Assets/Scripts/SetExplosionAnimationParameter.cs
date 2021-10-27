using UnityEngine;


[RequireComponent(typeof(DisableObjectEndAnimaion))]
public sealed class SetExplosionAnimationParameter : MonoBehaviour
{

    private DisableObjectEndAnimaion disableObjectEndAnimaion = null;


    private void Awake()
    {
        this.Initialize();
    }

    private void Initialize()
    {
        this.disableObjectEndAnimaion = this.GetComponent<DisableObjectEndAnimaion>();
        this.disableObjectEndAnimaion._animationParameter = AnimationManager.ExplosionParameter;
    }
}