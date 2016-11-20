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

    /// <summary>
    /// berfungsi untuk menampilkan text score yang didapat oleh player pada scene Runner beserta scoreCount
    /// </summary>
    public Text scoreText;
    /// <summary>
    /// menampilkan high score text yang didapat oleh player selama bermain
    /// </summary>
    public Text hiScoreText;
    /// <summary>
    /// attribut untuk mencatat score yang didapat oleh player
    /// </summary>
    [SerializeField]
    public float scoreCount;
    /// <summary>
    /// attribut untuk mencatat high score player selama bermain
    /// </summary>
    [SerializeField]
    public static float hiScoreCount;

    /// <summary>
    /// untuk menentukan jumlah score yang didapatkan oleh player per detik
    /// </summary>
    public float pointsPerSecond = 5;


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
