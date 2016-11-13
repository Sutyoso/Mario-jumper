using UnityEngine;
using System.Collections;

public class MainScene : MonoBehaviour {

    public string playGame;

    public void play() {
        Application.LoadLevel(playGame);
    }

    public void quit() {
        Application.Quit();
    }
}
