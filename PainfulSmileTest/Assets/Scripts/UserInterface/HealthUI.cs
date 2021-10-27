using UnityEngine;
using UnityEngine.UI;


[RequireComponent(typeof(Image))]
public sealed class HealthUI : MonoBehaviour
{
   
    [SerializeField] private Health health = null;
    private Image healthImage = null;


    private void Awake()
    {
        this.Initialize();
    }

    private void OnEnable()
    {
        this.health.OnHealtCount += this.SetHealthImageFill;
        this.SetHealthImageFill();
    }

    private void OnDisable()
    {
        this.health.OnHealtCount -= this.SetHealthImageFill;
    }

    private void SetHealthImageFill()
    {
        float healthCurrent = this.health._healthCurrent;
        float healthMaximum = this.health._healthMaximum;
        float healthValue = healthCurrent / healthMaximum;
        this.healthImage.fillAmount = healthValue;
    }

    private void Initialize()
    {
        this.healthImage = this.GetComponent<Image>();
        this.SetHealthImageFill();
    }
}