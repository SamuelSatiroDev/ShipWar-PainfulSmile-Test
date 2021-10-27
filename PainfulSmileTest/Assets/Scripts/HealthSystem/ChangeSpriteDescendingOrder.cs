using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(SpriteRenderer))]
public sealed class ChangeSpriteDescendingOrder : MonoBehaviour
{

    public delegate void EventHandler();
    public event EventHandler OnState;

    [SerializeField] private GameManagerEventData gameManagerEventData = null;
    [SerializeField] private Sprite defaultSprite = null;
    [SerializeField] private List<Sprite> states = new List<Sprite>();

    public List<Sprite> _states { get { return this.states; } }
    private SpriteRenderer mySpriteRenderer = null;


    private void Awake()
    {
        this.Initialize();
    }

    private void OnEnable()
    {
        this.gameManagerEventData.OnDefaultValues += this.Initialize;
    }

    private void OnDisable()
    {
        this.gameManagerEventData.OnDefaultValues -= this.Initialize;
        this.Initialize();
    }

    public void SetState(int IndexState)
    {
        this.mySpriteRenderer.sprite = this.states[IndexState];
        this.OnState?.Invoke();
    }

    public void Initialize()
    {
        this.mySpriteRenderer = this.GetComponent<SpriteRenderer>();
        this.mySpriteRenderer.sprite = this.defaultSprite;
    }
}