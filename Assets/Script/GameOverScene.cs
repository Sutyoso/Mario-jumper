using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

/// <summary>
/// kelas ini berguna untuk mengubah scene dari scene game Over menjadi scene lainnya
/// </summary>

public class GameOverScene : MonoBehaviour
{

    /// <summary>
    /// untuk mengubah menjadi scene Runner
    /// </summary>
    public void playB()
    {
        SceneManager.LoadScene("Runner", LoadSceneMode.Single);
    }

    /// <summary>
    /// untuk mengubah dari scene game Over menjadi scene Main
    /// </summary>
    public void menuB()
    {
        SceneManager.LoadScene("Main", LoadSceneMode.Single);
    }
}
