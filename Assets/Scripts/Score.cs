using UnityEngine;

public class Score : MonoBehaviour
{
    TMPro.TextMeshProUGUI _scoreText;
    public static int ScoreCount { get; set; }

    void Awake()
    {
        _scoreText = GetComponent<TMPro.TextMeshProUGUI>();
    }

    void Update()
    {
        _scoreText.text = ScoreCount.ToString();
    }
}
