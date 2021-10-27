using UnityEngine;


public sealed class Health : MonoBehaviour
{

    public delegate void EventHandler();
    public event EventHandler OnHealthIncrease;
    public event EventHandler OnHealthDecrease;
    public event EventHandler OnHealthMaximum;
    public event EventHandler OnHealthZero;

    public delegate void HealtCountEventHandler();
    public event HealtCountEventHandler OnHealtCount;


    [SerializeField] private int healthMaximum = 0;
    [SerializeField] private int healthCurrent = 0;

    public int _healthCurrent { get { return this.healthCurrent; } }
    public int _healthMaximum { get { return this.healthMaximum; } set { this.healthMaximum = value; } }


    private void Awake()
    {
        this.Initialize();
    }

    public void SetHealth(int SetHealth)
    {
        this.healthCurrent += SetHealth;

        if (this.healthCurrent >= this.healthMaximum)
        {
            this.healthCurrent = this.healthMaximum;
            this.OnHealthMaximum?.Invoke();
        }

        if (this.healthCurrent <= -1)
        {
            this.healthCurrent = -1;
            this.OnHealthZero?.Invoke();
        }


        if (SetHealth < 0)
            this.OnHealthDecrease?.Invoke();

        if (SetHealth > 0)
            this.OnHealthIncrease?.Invoke();

        this.OnHealtCount?.Invoke();
    }

    public void Initialize()
    {
        this.healthCurrent = this.healthMaximum;
        this.OnHealtCount?.Invoke();
    }
}