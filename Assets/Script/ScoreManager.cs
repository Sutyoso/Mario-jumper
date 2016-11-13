using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour {
    
	public Text scoreText;
    public Text hiScoreText;

    public float scoreCount;
    public static float hiScoreCount;

    public float pointsPerSecond = 7;

    public bool scoreIncreasing;

    void Update()
    {
        if (scoreIncreasing)
        {
            scoreCount += pointsPerSecond * Time.deltaTime;
        }
        if (scoreCount > hiScoreCount)
        {
            hiScoreCount = scoreCount;
        }
        scoreText.text = "Score: " + Mathf.Round(scoreCount);
        hiScoreText.text = "High Score: " + Mathf.Round(hiScoreCount);
    }
}
