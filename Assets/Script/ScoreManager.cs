using UnityEngine;
using System.Collections;
using UnityEngine.UI;

/// <summary>
/// kelas ini berfungsi untuk mengatur score dan high score
/// ketika game mulai maka highscore akan menjadi 0
/// tetapi pemain me-retry game highscore akan menjadi highscore yang didapatkan oleh user tersebut
/// </summary>
public class ScoreManager : MonoBehaviour
{

    public Text scoreText;
    public Text hiScoreText;
    [SerializeField]
    public float scoreCount;
    [SerializeField]
    public static float hiScoreCount;

    public float pointsPerSecond = 7;

    private bool scoreIncreasing=true;

    /// <summary>
    /// method ini berisi command untuk menambahkan score berdasarkan waktu dan attribut pointPerSecond
    /// </summary>
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
        if (Mathf.Round(scoreCount) % 100 == 0 && Mathf.Round(scoreCount) != 0)
        {
            GetComponent<AudioSource>().Play();
        }
    }

    /// <summary>
    /// mengembalikan score terakhir yang didapatkan oleh pemain
    /// </summary>
    /// <returns></returns>
    public float getCount()
    {
        return scoreCount;
    }
}
