using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    [SerializeField] private TextMeshProUGUI scoreText;

    private int score = 0;

    private void Start()
    {
        instance = this;
    }


    public void AddScore(int point)
    {
        score += point;
        scoreText.text = "Score: " + score;
    }
}
