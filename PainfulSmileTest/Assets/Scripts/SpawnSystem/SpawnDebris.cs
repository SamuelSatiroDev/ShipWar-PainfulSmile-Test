using UnityEngine;
using Characters;


[RequireComponent(typeof(SetChildrensPositionRandomly))]
public sealed class SpawnDebris : MonoBehaviour
{
    [SerializeField] private GameManagerEventData gameManagerEventData = null;
    [SerializeField] private Health health = null;
    [SerializeField] private CharacterBase characterBase = null;

    private SetChildrensPositionRandomly setChildrensPositionRandomly = null;


    private void Awake()
    {
        this.Initialize();
    }

    private void OnEnable()
    {
        if(this.health)
            this.health.OnHealthZero += this.setChildrensPositionRandomly.SetRandomPosition;

        this.gameManagerEventData.OnDefaultValues += this.Initialize;    
    }

    private void OnDisable()
    {
        if (this.health)
            this.health.OnHealthZero -= this.setChildrensPositionRandomly.SetRandomPosition;

         this.gameManagerEventData.OnDefaultValues -= this.Initialize;
        this.Initialize();
    }

    public void Initialize()
    {
        this.setChildrensPositionRandomly = this.GetComponent<SetChildrensPositionRandomly>();
        this.setChildrensPositionRandomly.Initialize();
    }
}