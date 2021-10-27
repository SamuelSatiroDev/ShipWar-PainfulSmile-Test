using UnityEngine;
using TMPro;


public sealed class ScoreUI : MonoBehaviour
{

    [SerializeField] private GameManagerEventData gameManagerEventData = null;
    [SerializeField] private TMP_Text scoreText = null;


    public void SetValueScoreText(int Score)
    {
        this.scoreText.text = string.Format("{0}{1}","Score: ", Score);
    }

    public void Initialize()
    {
        this.SetValueScoreText(0);
    }
}