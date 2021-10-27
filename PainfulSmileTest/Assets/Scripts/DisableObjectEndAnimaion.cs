using System.Collections;
using UnityEngine;
using ExtensionMethods;


[RequireComponent(typeof(Animator))]
public sealed class DisableObjectEndAnimaion : MonoBehaviour
{

    public delegate void EventHandler();
    public event EventHandler OnDisableStart;
    public event EventHandler OnAnimationEnd;

    [SerializeField] private AnimationClip animationClip = null;

    private Animator myAnimator = null;
    private string animationParameter = string.Empty;
    public string _animationParameter { set { this.animationParameter = value; } }


    private void Awake()
    {
        this.Initialize();
    }

    private void OnEnable()
    {
        this.DisableGameObject();
    }

    public void DisableGameObject()
    {
        this.myAnimator.SetAnim(this.animationParameter);
        this.OnDisableStart?.Invoke();
        StartCoroutine(this.AnimationTimer());    
    }

    private IEnumerator AnimationTimer()
    {
        yield return new WaitForSeconds(this.animationClip.length);

        this.gameObject.SetActive(false);
        this.OnAnimationEnd?.Invoke();
    }

    private void Initialize()
    {
        this.myAnimator = this.GetComponent<Animator>();     
    }
}