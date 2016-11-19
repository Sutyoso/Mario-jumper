using UnityEngine;
using System.Collections;

/// <summary>
/// kelas ini berguna untuk mengubah scene dari scene game Over menjadi scene lainnya
/// </summary>

public class GameOverScene : MonoBehaviour
{

    /// <summary>
    /// untuk mengubah menjadi scene Runner
    /// </summary>
    public void playB (){
        Application.LoadLevel("Runner");

    }

    /// <summary>
    /// untuk mengubah dari scene game Over menjadi scene Main
    /// </summary>
   public void menuB()
    {
        Application.LoadLevel("Main");
    }


}
