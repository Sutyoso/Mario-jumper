using UnityEngine;
using System.Collections;

public class MainScene : MonoBehaviour {

    public string playGame;

	/*
	 * method play ini terdapat pada scene menu
	 * method ini berguna saat tombol play dipencet maka akan dialihkan ke scene game
	 * method quit berguna untuk keluar dari game 
	*/

    public void play() {
        Application.LoadLevel(playGame);
    }

    public void quit() {
        Application.Quit();
    }
}
