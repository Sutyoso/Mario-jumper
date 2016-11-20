using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

/// kelas ini untuk mengubah scene sesuai dengan pilihan dari user

public class MainScene : MonoBehaviour {

	/// <summary>
    /// method play ini terdapat pada scene 
    /// method ini berguna saat tombol play dipencet maka akan dialihkan ke scene game
    /// </summary>

    public void play() {
        SceneManager.LoadScene("Runner", LoadSceneMode.Single);
    }

    /// <summary>
    /// method play ini terdapat pada scene menu
    /// method ini berguna saat tombol play dipencet maka akan dialihkan ke scene game
    /// </summary>
    public void quit() {
        Application.Quit();
    }
}
