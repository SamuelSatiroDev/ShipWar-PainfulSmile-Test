using UnityEngine;
using UnityEngine.UI;
using TMPro;


[RequireComponent(typeof(TMP_Text))]
public sealed class TextGetSliderValue : MonoBehaviour
{

    [SerializeField] private Slider slider = null;
    private TMP_Text myText = null;


    private void Start()
    {
        this.Initialize();
    }

    private void GetValue(float SliderValue)
    {
        this.myText.text = string.Format("{00}", SliderValue);
    }

    private void Initialize()
    {
        this.myText = this.GetComponent<TMP_Text>();
        this.slider.onValueChanged.AddListener(this.GetValue);

        this.GetValue(this.slider.value);
    }
}